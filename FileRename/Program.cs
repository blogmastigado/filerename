using System;
//using System.IO.Path;
//using static System.Net.Mime.MediaTypeNames;

namespace FileRename
{
    class Program
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
            string diretorio = "";

            Console.WriteLine("Hello World!");
            
            diretorio = System.IO.Directory.GetCurrentDirectory();

            Console.WriteLine("O diretório que você executou o app é este: " + diretorio);

            Console.ReadKey();
            //Console.ReadLine(env.)
        }

        //protected
    }
}
