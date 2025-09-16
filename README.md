# Codespace example of a C# implemented Symmetric-Keytool

## 1) Open this as a Codespace:
      1) Click the Code drop-down menu.
      2) Click on the Codespaces tab.
      3) Click Create codespace on codeSpaceRoot
         (or on the specific branch of interest).

## 2) Create and Build a Console App, for your Codespace
      From the TERMINAL (Shell window) execute the following commands while in the *codeSpaceRoot folder:
        1) Make sure you are currently in the *codeSpaceRoot folder
           (*codeSpaceRoot = /workspaces/Codespace-for_CSharp_Symmetric-Keytool)
        2) mkdir -p ./Symmetric_Keytool_Project/consoleApp
        3) cd ./Symmetric_Keytool_Project
        4) The following commands create the Console App
          - dotnet new console --language "C#" --name symmetric_keytool --output ./consoleApp --project ./consoleApp
            (NOTE: a dotnet command to create a new console App, scaffolding)
          - cd ./consoleApp
            (NOTE: a command that navigates the path to consoleApp folder)
        5) Open up the file named Program.cs
           (./Codespace-for_CSharp_Symmetric-Keytool/Symmetric_Keytool_Project/consoleApp/Program.cs)
           and wait for the "SOLUTION EXPLORER" extension to be activated.

## 3) Implement the application using SOLUTION EXPLORER
      1) Goto SOLUTION EXPLORER and open the Symmetric-Keytool Project
           - click on folder blazor_web_api
             (Symmetric_Keytool_Project/consoleApp/symmetric_keytool.csproj)
      2) Add the Encryptor Class
          - click on folder (namespace) symmetric_keytool
          - add New File...
             - a Class named Encryptor.cs
             - copy src_templates/Encryptor.cs.template content and paste
               copied content into symmetric_keytool/Encryptor.cs
      3) Add the Encryptor Class
          - click on folder (namespace) symmetric_keytool
          - add New File...
             - a Class named Decryptor.cs
             - copy src_templates/Decryptor.cs.template content and paste
               copied content into symmetric_keytool/Decryptor.cs
      4) Update Program.cs
          - open Program.cs file
          - copy src_templates/Program.cs.template content and paste
            copied content into Program.cs

## 4) Initial Test of the Console App
      1) Goto SOLUTION EXPLORER (if not already there)
      2) Click on Program.cs
      3) Upper right hand corner find and click either:
          - Run project associated with this file
          - Debug project associated with this file

Based on:
   - Milan Jovanović
   - Implementing AES Encryption With C#
   - https://www.milanjovanovic.tech/blog/implementing-aes-encryption-with-csharp
