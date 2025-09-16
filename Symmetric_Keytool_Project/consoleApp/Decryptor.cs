using System.Security.Cryptography;

namespace symmetric_keytool;

public class Decryptor
{
    public string OutputPhrase { get; set; }

    public Decryptor(string phrase, byte[] masterKey, int keySize, int ivSize)
    {
        OutputPhrase = Decrypt(phrase, masterKey, keySize, ivSize);
    }

    private static string Decrypt(string encryptedPhrase, byte[] masterKey, int keySize, int iVSize)
    {
        try
        {
            byte[] phraseAsBytes = Convert.FromBase64String(encryptedPhrase);
            if (phraseAsBytes.Length < iVSize)
            {
                throw new InvalidOperationException("Invalid decrypted text format.");
            }

            byte[] iv = new byte[iVSize];
            byte[] encryptedData = new byte[phraseAsBytes.Length - iVSize];

            Buffer.BlockCopy(phraseAsBytes, 0, iv, 0, iVSize);
            Buffer.BlockCopy(phraseAsBytes, iVSize, encryptedData, 0, encryptedData.Length);

            using var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = masterKey;
            aes.IV = iv;

            using MemoryStream memoryStream = new(encryptedData);
            using var decryptor = aes.CreateDecryptor();
            using CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new(cryptoStream);

            return streamReader.ReadToEnd();
        }
        catch (CryptographicException ce)
        {
            throw new InvalidOperationException("Decryption failed", ce);
        }
    }
}

