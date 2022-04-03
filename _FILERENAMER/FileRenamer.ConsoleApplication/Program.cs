using System;
using System.Collections.Generic;
using System.IO;
using FileRename.Aplicacao;
//using System.IO.Path;
//using static System.Net.Mime.MediaTypeNames;

namespace FileRename
{
    public class Program
    {
        /* O que este programa faz:
         * - Permite identificar a extensão dos arquivos que deseja renomear ou não;
         * - Permite colocar um índice automático (no início ou no final) para os arquivos (aleatórios) que deseja renomear;
         * - Permite inserir um termo no lugar do nome original do arquivo;
         * - Permite substituir um termo;
         * - Permite substituir ou inserir um termo no início, no final;
         * 
         */

        static void Main(string[] args)
        {
            GestorDeArquivo GestorDeArquivo = new GestorDeArquivo();

            Console.WriteLine("Hello World!");
            
            Console.WriteLine("O diretório que você executou o app é este: " + GestorDeArquivo.ObterNomeDoDiretorioAtual());

            Console.WriteLine("Os arquivos contidos no diretório atual são estes: ");

            GestorDeArquivo.ExibirNomesDosArquivosDoDiretorioAtual();

            Console.ReadKey();
            //Console.ReadLine(env.)
        }

    }
}
