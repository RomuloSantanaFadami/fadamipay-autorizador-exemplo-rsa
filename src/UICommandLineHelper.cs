using System;
using System.IO;
using CommandLine;
using Criptografia.RSA.Test.Helpers;

namespace Criptografia.RSA.Test
{
    public class UICommandLineHelper
    {
        public static void RunWithOptions(CommandLineOpts opts)
        {
            System.Console.WriteLine("-----------------------------------------------");
            System.Console.WriteLine("\tFADAMI - Apoio Criptografia RSA");
            System.Console.WriteLine("-----------------------------------------------");

            // Validando se precisa criar chaves
            if (opts.generateKeys || !ValidKeys())
            {
                System.Console.WriteLine("Gerando chaves privada e publica...");
                var pathCreatedKeys = KeysHelper.GenerateKeys(opts.pathKeys);
                if (!string.IsNullOrEmpty(pathCreatedKeys))
                {
                    System.Console.WriteLine("Chaves criadas no diretório com sucesso!");
                    System.Console.WriteLine($"Path: {pathCreatedKeys}");
                }
                else
                {
                    System.Console.WriteLine("Falha ao criar chaves!");
                }
            }

            // Testando criptografia

            System.Console.WriteLine($"Texto a ser criptografado .: {opts.value}");
            var encryptText = CriptHelper.EncryptText(opts.value);

            System.Console.WriteLine($"Texto criptografado .......: {encryptText}");
            var decryptText = CriptHelper.DecryptText(encryptText);
            System.Console.WriteLine($"Texto decriptografado .....: {decryptText}");

            System.Console.WriteLine("\n\n");
            System.Console.WriteLine("... Fim do processamento!");
            System.Console.WriteLine("\n\n");
        }

        private static bool ValidKeys()
        {
            return File.Exists(KeysHelper.PrivateKeyFile) && File.Exists(KeysHelper.PublicKeyFile);
        }
    }

    public class CommandLineOpts
    {
        [Option('v', "valor", Default = "Esse texto será usado como exemplo de criptografia", Required = false, HelpText = "Valor a ser criptografado para teste")]
        public string value { get; set; }

        [Option('k', "gerar-chaves", Default = false, HelpText = "Informativo se deve criar chave privada e publica")]
        public bool generateKeys { get; set; }

        /// Path de onde trabalhará com as chaves
        [Option('p', "path-chaves", Default = "Keys", Required = false, HelpText = "Path onde será disponibilizado/lido chaves privadas e publicas")]
        public string pathKeys { get; set; }
    }
}
