using System.Security.Cryptography;

namespace symmetric_keytool;

public class Encryptor
{
    public string OutputPhrase { get; set; }
    public byte[] Key { get; set; }
    public int IvSize { get; set; }

    public Encryptor(string secretText, int keySize)
    {
        var encryptInfo = Encrypt(secretText, keySize);
        OutputPhrase = encryptInfo.encryptedData;
        Key = encryptInfo.generatedKey;
        IvSize = encryptInfo.ivSize;
    }

    static private int BLOCK_SIZE = 128;
    
    private static
    (string encryptedData, byte[] generatedKey, int ivSize)
    Encrypt(string secretText, int keySize)
    {
        try
        {
            // Generate a random key and IV
            using var aes = Aes.Create();

            //For AES, the legal key sizes are 128, 192, and 256 bits.
            aes.KeySize = keySize;
            //Console.WriteLine($"aes.LegalKeySizes={aes.LegalKeySizes}");
            //Console.WriteLine($"aes.LegalBlockSizes={aes.LegalBlockSizes}");

            aes.BlockSize = BLOCK_SIZE;

            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            aes.GenerateIV();
            aes.GenerateKey();

            using var memoryStream = new MemoryStream();
            memoryStream.Write(aes.IV, 0, aes.IV.Length);

            using (var encryptor = aes.CreateEncryptor())
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            using (var streamWriter = new StreamWriter(cryptoStream))
            {
                streamWriter.Write(secretText);
            }

            return (Convert.ToBase64String(memoryStream.ToArray()), aes.Key, aes.IV.Length);
        }
        catch (CryptographicException ce)
        {
            throw new InvalidOperationException("Decryption failed", ce);
        }
    }
}


