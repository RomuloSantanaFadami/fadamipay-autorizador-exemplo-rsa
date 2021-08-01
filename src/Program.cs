using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CommandLine;

namespace Criptografia.RSA.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineOpts opts = new CommandLineOpts();
            ParserResult<CommandLineOpts> result = CommandLine.Parser.Default.ParseArguments<CommandLineOpts>(args)
                .WithParsed<CommandLineOpts>(options => UICommandLineHelper.RunWithOptions(options))
                .WithNotParsed<CommandLineOpts>(options => System.Console.WriteLine("Falha ao obter parametrôs informado!"));
        }
    }
}
