using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;

namespace LogArquivoCore
{
    public static class Log
    {
        private static readonly object obj = new object();
        private static readonly IConfiguration config;

        static Log()
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", true, true);

            config = builder.Build();
        }

        private static void GravarArquivo(string conteudo)
        {
            lock (obj)
            {
                File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}Log.txt", $"{DateTime.Now} - {conteudo}\r\n", Encoding.UTF8);
            }
        }

        private static string ExtrairConteudo(Exception ex)
        {
            string conteudo = "";
            if (ex.InnerException != null) conteudo += ExtrairConteudo(ex.InnerException);

            return $"{conteudo}{ex.Message}\r\n{ex.StackTrace}\r\n";
        }

        public static void Excecao(Exception ex)
        {
            if (config["GerarLog"] != "True") return;

            var conteudo = ExtrairConteudo(ex);
            GravarArquivo(conteudo);
        }

        public static void Erro(string conteudo)
        {
            if (config["GerarLog"] != "True") return;
            GravarArquivo($"{conteudo}\r\n");
        }
    }
}
