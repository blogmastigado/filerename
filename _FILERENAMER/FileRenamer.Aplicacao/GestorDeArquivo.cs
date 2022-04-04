using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRename.Aplicacao
{
    public static class GestorDeArquivo
    {
        public static List<String> ObterTodosOsNomesDeArquivosDeUmDiretorio(String nome_diretorio)
        {
            // Inicializa uma lista de String para guardar os nomes dos arquivos
            List<String> nomes_de_arquivos = new List<String>();

            try
            {
                if (Directory.GetFiles(nome_diretorio) != null)
                {
                    // Armazena em um array de String os caminhos dos arquivos contidos no diretório
                    string[] nomes_arquivos_do_diretorio = Directory.GetFiles(nome_diretorio);

                    // Percorre o array de String
                    foreach (string nome_arquivo in nomes_arquivos_do_diretorio)
                    {
                        // Se o registro for diferente a String abaixo é porque está pegando um arquivo oculto de diretório
                        // e não deve ser incrementado na lista
                        if (nome_arquivo != nome_diretorio + "\\Thumbs.db")
                        {
                            // Incrementa na lista de String cada caminho de determinado arquivo que está contido no diretório
                            nomes_de_arquivos.Add(nome_arquivo);
                        }
                    }
                }
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                
            }
            
            return nomes_de_arquivos;
        }

        public static string ObterNomeDoDiretorioAtual()
        {
            string nome_diretorio = "";

            try
            {
                nome_diretorio = System.IO.Directory.GetCurrentDirectory();
            }
            catch(System.IO.DirectoryNotFoundException e)
            {
                nome_diretorio = "";
            }

            return nome_diretorio;
        }

        public static void ExibirNomesDosArquivosDoDiretorioAtual()
        {
            List<String> nomes_arquivos = new List<String>();

            nomes_arquivos = ObterTodosOsNomesDeArquivosDeUmDiretorio(ObterNomeDoDiretorioAtual());

            foreach(String nome_arquivo in nomes_arquivos)
            {
                Console.WriteLine(nome_arquivo);
            }
        }
    }
}
