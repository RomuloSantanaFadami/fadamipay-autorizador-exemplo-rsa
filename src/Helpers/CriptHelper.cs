using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

namespace Criptografia.RSA.Test.Helpers
{
    public class CriptHelper
    {
        public static string EncryptText(string text)
        {
            var rsa = CreateRSA(KeysHelper.PublicKeyFile);

            var buffer = Encoding.UTF8.GetBytes(text);
            var cript = rsa.Encrypt(buffer, RSAEncryptionPadding.Pkcs1);
            return Convert.ToBase64String(cript);
        }

        public static string DecryptText(string text)
        {
            var rsa = CreateRSA(KeysHelper.PrivateKeyFile);

            var buffer = Convert.FromBase64String(text);
            var cript = rsa.Decrypt(buffer, RSAEncryptionPadding.Pkcs1);
            return Encoding.UTF8.GetString(cript);
        }

        private static System.Security.Cryptography.RSA CreateRSA(string fileKey)
        {
            System.Security.Cryptography.RSA rsa = System.Security.Cryptography.RSA.Create();

            using (StreamReader reader = File.OpenText(fileKey))
            {
                char[] key = reader.ReadToEnd().ToCharArray();
                rsa.ImportFromPem(key);
            }

            return rsa;
        }
    }
}
