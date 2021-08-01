using System;
using System.IO;
using System.Text;

namespace Criptografia.RSA.Test.Helpers
{
    public class KeysHelper
    {
        private const string _EXTENSION_KEY = ".pem";
        private static string PathKeys =  Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Keys");
        public static readonly string PrivateKeyFile =  Path.Combine(PathKeys, $"private-key{_EXTENSION_KEY}");
        public static readonly string PublicKeyFile = Path.Combine(PathKeys, $"public-key{_EXTENSION_KEY}");
        public static readonly System.Security.Cryptography.RSA _rsa = System.Security.Cryptography.RSA.Create("RSA");

        public static string GenerateKeys(string path)
        {
            // gerando valor de chave privada
            var privateKey = ExportPrivateKey();
            // gerando valor de chave publica
            var publicKey = ExportPublicKey();

            ////////////////////
            
            /// salvando arquivos no diretório
            
            PathKeys = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            // criando diretorio
            if (!Directory.Exists(PathKeys))
                Directory.CreateDirectory(PathKeys);

            // limpando arquivos do diretorio
            foreach (var file in Directory.GetFiles(PathKeys))
                File.Delete(file);

            // criando arquivo de chave privada
            using (StreamWriter stream = new StreamWriter(PrivateKeyFile))
                stream.Write(privateKey);

            // criando arquivo de chave publica
            using (StreamWriter stream = new StreamWriter(PublicKeyFile))
                stream.Write(publicKey);

            if (File.Exists(PrivateKeyFile) && File.Exists(PublicKeyFile))
                return PathKeys;

            return null;
        }

        private static string ExportPrivateKey()
        {
            var privateKeyBytes = _rsa.ExportRSAPrivateKey();
            var builder = new StringBuilder("-----BEGIN RSA PRIVATE KEY");
            builder.AppendLine("-----");

            var base64PrivateKeyString = Convert.ToBase64String(privateKeyBytes);
            var offset = 0;
            const int LINE_LENGTH = 64;

            while (offset < base64PrivateKeyString.Length)
            {
                var lineEnd = Math.Min(offset + LINE_LENGTH, base64PrivateKeyString.Length);
                builder.AppendLine(base64PrivateKeyString.Substring(offset, lineEnd - offset));
                offset = lineEnd;
            }

            builder.Append("-----END RSA PRIVATE KEY");
            builder.AppendLine("-----");
            return builder.ToString();
        }

        private static string ExportPublicKey()
        {
            var privateKeyBytes = _rsa.ExportRSAPublicKey();
            var builder = new StringBuilder("-----BEGIN RSA PUBLIC KEY");
            builder.AppendLine("-----");

            var base64PrivateKeyString = Convert.ToBase64String(privateKeyBytes);
            var offset = 0;
            const int LINE_LENGTH = 64;

            while (offset < base64PrivateKeyString.Length)
            {
                var lineEnd = Math.Min(offset + LINE_LENGTH, base64PrivateKeyString.Length);
                builder.AppendLine(base64PrivateKeyString.Substring(offset, lineEnd - offset));
                offset = lineEnd;
            }

            builder.Append("-----END RSA PUBLIC KEY");
            builder.AppendLine("-----");
            return builder.ToString();
        }
    }
}
