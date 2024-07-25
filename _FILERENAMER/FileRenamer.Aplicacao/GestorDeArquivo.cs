using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer.Aplicacao
{
    public static class GestorDeArquivo
    {
        public static List<String> ObterTodosOsNomesDeArquivosDoDiretorioAtualComCaminhoCompleto()
        {
            // Inicializa uma lista de String para guardar os nomes dos arquivos
            List<String> nomes_de_arquivos = new List<String>();

            // Nome do diretório atual (com caminho completo)
            string nome_diretorio_atual = ObterNomeDoDiretorioAtualComCaminhoCompleto();

            try
            {
                if (Directory.GetFiles(nome_diretorio_atual) != null)
                {
                    // Armazena em um array de String os caminhos dos arquivos contidos no diretório
                    string[] nomes_arquivos_do_diretorio = Directory.GetFiles(nome_diretorio_atual);

                    // Percorre o array de String
                    foreach (string nome_arquivo in nomes_arquivos_do_diretorio)
                    {
                        // Se o registro for diferente a String abaixo é porque está pegando um arquivo oculto de diretório
                        // e não deve ser incrementado na lista
                        if (nome_arquivo != nome_diretorio_atual + "\\Thumbs.db")
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

        public static List<String> ObterTodosOsNomesDeArquivosDoDiretorioAtualComCaminhoCompletoPorExtensao(String extensao_arquivo)
        {
            // Nome do diretório atual (com caminho completo)
            string nome_diretorio_atual = ObterNomeDoDiretorioAtualComCaminhoCompleto();

            // Inicializa uma lista de String para guardar os nomes dos arquivos completos
            List<String> nomes_de_arquivos = ObterTodosOsNomesDeArquivosDoDiretorioAtualComCaminhoCompleto();

            // Inicializa uma lista de String para guardar os nomes dos arquivos completos filtrados por extensão
            List<String> nomes_de_arquivos_filtrados_por_extensao = new List<String>();

            try
            {
                if (Directory.GetFiles(nome_diretorio_atual) != null)
                {
                    // Armazena em um array de String os caminhos dos arquivos contidos no diretório
                    string[] nomes_arquivos_do_diretorio = Directory.GetFiles(nome_diretorio_atual);

                    // Percorre o array de String
                    foreach (string nome_arquivo in nomes_arquivos_do_diretorio)
                    {
                        // Se o registro for diferente a String abaixo é porque está pegando um arquivo oculto de diretório
                        // e não deve ser incrementado na lista
                        if (nome_arquivo != nome_diretorio_atual + "\\Thumbs.db")
                        {
                            string apenas_nome_arquivo = GestorDeArquivo.ObterApenasNomeDoArquivo(nome_arquivo);    

                            string[] nome_arquivo_separado = apenas_nome_arquivo.Split(".");

                            string extensao_arquivo_diretorio = nome_arquivo_separado[nome_arquivo_separado.Length - 1];

                            if (extensao_arquivo.ToLower().Equals(extensao_arquivo_diretorio.ToLower()))
                            {
                                // Incrementa na lista de String cada caminho de determinado arquivo que está contido no diretório
                                nomes_de_arquivos_filtrados_por_extensao.Add(nome_arquivo);
                            }
                        }
                    }
                }
            }
            catch (System.IO.DirectoryNotFoundException e)
            {

            }

            return nomes_de_arquivos_filtrados_por_extensao;
        }

        public static string ObterExtensaoDeUmArquivo(string apenas_nome_arquivo)
        {
            string extensao_arquivo = "";

			string[] nome_arquivo_separado = apenas_nome_arquivo.Split(".");

			extensao_arquivo = nome_arquivo_separado[nome_arquivo_separado.Length - 1];

			return extensao_arquivo;
        }

        public static string ObterNomeDoDiretorioAtualComCaminhoCompleto()
        {
            string nome_diretorio = "";

            try
            {
                nome_diretorio = System.IO.Directory.GetCurrentDirectory();
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                nome_diretorio = "";
            }

            return nome_diretorio;
        }

        public static void ExibirApenasOsNomesDosArquivosDoDiretorioAtual()
        {
            List<String> nomes_arquivos = new List<String>();

            // Nome do diretório atual (com caminho completo)
            string nome_diretorio_atual = ObterNomeDoDiretorioAtualComCaminhoCompleto();

            nomes_arquivos = ObterTodosOsNomesDeArquivosDoDiretorioAtualComCaminhoCompleto();

            foreach (String nome_arquivo in nomes_arquivos)
            {
                string nomeoriginal = ObterApenasNomeDoArquivo(nome_arquivo);

                Console.WriteLine(nomeoriginal);
            }
        }

        public static int SubstituirTermoEmArquivosDeDiretorioAtual(string termo_referencia, string termo_a_substituir, string extensao_arquivos)
        {
            int nao_processados = 0;

            List<String> nomes_arquivos = new List<String>();

            // Nome do diretório atual (com caminho completo)
            string nome_diretorio_atual = ObterNomeDoDiretorioAtualComCaminhoCompleto();

            if (!String.IsNullOrEmpty(extensao_arquivos))
            {
                nomes_arquivos = ObterTodosOsNomesDeArquivosDoDiretorioAtualComCaminhoCompletoPorExtensao(extensao_arquivos);
            }
            else
            {
                nomes_arquivos = ObterTodosOsNomesDeArquivosDoDiretorioAtualComCaminhoCompleto();
            }

            foreach(string nome_arquivo in nomes_arquivos)
            {
                string nome_arquivo_atual = ObterApenasNomeDoArquivo(nome_arquivo);

                try
                {
                    if (nome_arquivo_atual.ToLower().Contains(termo_a_substituir.ToLower()))
                    {
                        string termo_ja_substituido = nome_arquivo_atual.Replace(termo_a_substituir, termo_referencia);

                        if (!AlterarNomeDeUmArquivoNoDiretorioAtual(nome_arquivo_atual, termo_ja_substituido))
                        {
                            nao_processados++;
                        }
                    }
                }
                catch(Exception e)
                {
                    string erro = e.Message;
                    nao_processados++;
                }
            }

            return nao_processados;
        }

		public static int SubstituirNumeracaoEmArquivosDeDiretorioAtual(string termo_referencia_esquerda, string termo_referencia_direita, int numero_referencia)
		{
			int nao_processados = 0;

			List<String> nomes_arquivos = new List<String>();

			// Nome do diretório atual (com caminho completo)
			string nome_diretorio_atual = ObterNomeDoDiretorioAtualComCaminhoCompleto();

			nomes_arquivos = ObterTodosOsNomesDeArquivosDoDiretorioAtualComCaminhoCompleto();

            nomes_arquivos = nomes_arquivos.OrderByDescending(x => x).ToList(); 

			foreach (string nome_arquivo in nomes_arquivos)
			{
				string nome_arquivo_atual = ObterApenasNomeDoArquivo(nome_arquivo);

				try
				{
                    if(!String.IsNullOrEmpty(termo_referencia_esquerda) && String.IsNullOrEmpty(termo_referencia_direita))
                    {
                        int indice_termo_a_esquerda = nome_arquivo_atual.ToLower().IndexOf(termo_referencia_esquerda.ToLower());

						if (indice_termo_a_esquerda >= 0)
                        {
							string string_antes_da_referencia = nome_arquivo_atual.Substring(0, indice_termo_a_esquerda);

							string extensao_arquivo = ObterExtensaoDeUmArquivo(nome_arquivo_atual);

							string termo_ja_substituido = string_antes_da_referencia + termo_referencia_esquerda + numero_referencia.ToString() + "." + extensao_arquivo;

							if (!AlterarNomeDeUmArquivoNoDiretorioAtual(nome_arquivo_atual, termo_ja_substituido))
							{
								nao_processados++;
							}
							else
							{
								numero_referencia--;
							}
						}
						else
						{
							nao_processados++;
						}
					}
                    else
                    {
						if (String.IsNullOrEmpty(termo_referencia_esquerda) && !String.IsNullOrEmpty(termo_referencia_direita))
                        {							
							int indice_termo_a_direita = nome_arquivo_atual.ToLower().IndexOf(termo_referencia_direita.ToLower());

							if (indice_termo_a_direita >= 0)
                            {
								string string_a_partir_da_referencia_da_direita = nome_arquivo_atual.Substring(indice_termo_a_direita);

								string termo_ja_substituido = numero_referencia.ToString() + string_a_partir_da_referencia_da_direita;

								if (!AlterarNomeDeUmArquivoNoDiretorioAtual(nome_arquivo_atual, termo_ja_substituido))
								{
									nao_processados++;
								}
								else
								{
									numero_referencia--;
								}
							}
                            else
                            {
								nao_processados++;
							}
						}
                        else
                        {
							if (!String.IsNullOrEmpty(termo_referencia_esquerda) && !String.IsNullOrEmpty(termo_referencia_direita))
                            {
								int indice_termo_a_esquerda = nome_arquivo_atual.ToLower().IndexOf(termo_referencia_esquerda.ToLower());

								int indice_termo_a_direita = nome_arquivo_atual.ToLower().IndexOf(termo_referencia_direita.ToLower());

                                if(indice_termo_a_esquerda >= 0 && indice_termo_a_direita >=0 ) 
                                {
									string string_antes_da_referencia = nome_arquivo_atual.Substring(0, indice_termo_a_esquerda);

									string string_a_partir_da_referencia_da_direita = nome_arquivo_atual.Substring(indice_termo_a_direita);

									string termo_ja_substituido = string_antes_da_referencia + termo_referencia_esquerda + numero_referencia.ToString() + string_a_partir_da_referencia_da_direita;

									if (!AlterarNomeDeUmArquivoNoDiretorioAtual(nome_arquivo_atual, termo_ja_substituido))
									{
										nao_processados++;
									}
                                    else
                                    {
										numero_referencia--;
									}
								}
                                else
                                {
									nao_processados++;
								}								
							}
						}
					}
				}
				catch (Exception e)
				{
					string erro = e.Message;
					nao_processados++;
				}
			}

			return nao_processados;
		}

		public static Boolean AlterarNomeDeUmArquivoNoDiretorioAtual(string nome_atual, string novo_nome)
        {
            Boolean resultado = false;

            if (VerificaSeExisteDeterminadoArquivoExisteNoDiretorioAtual(nome_atual))
            {
                try
                {
                    // Nome do diretório atual (com caminho completo)
                    string nome_diretorio_atual = ObterNomeDoDiretorioAtualComCaminhoCompleto();

                    string nome_atual_com_caminho_completo = nome_diretorio_atual + "\\" + nome_atual;

                    string novo_nome_com_caminho_completo = nome_diretorio_atual + "\\" + novo_nome;

                    //System.IO.Directory.Move(@"D:\movie", @"D:\movies");
                    System.IO.Directory.Move(nome_atual_com_caminho_completo, novo_nome_com_caminho_completo);

                    resultado = true;
                }
                catch (Exception e)
                {
                    string erro = e.Message;
                }
            }

            return resultado;
        }

        public static List<string> ObterNomesDosArquivosDoDiretorioAtual()
        {
            List<String> nomes_completos_dos_arquivos = new List<String>();
            List<String> nomes_originais_dos_arquivos = new List<String>();

            // Nome do diretório atual (com caminho completo)
            string nome_diretorio_atual = ObterNomeDoDiretorioAtualComCaminhoCompleto();

            nomes_completos_dos_arquivos = ObterTodosOsNomesDeArquivosDoDiretorioAtualComCaminhoCompleto();

            foreach (String nome_arquivo in nomes_completos_dos_arquivos)
            {
                string nomeoriginal = ObterApenasNomeDoArquivo(nome_arquivo);

                nomes_originais_dos_arquivos.Add(nomeoriginal);
            }

            return nomes_originais_dos_arquivos;
        }

        public static List<String> ObterNomesDosArquivosDoDiretorioAtualPorExtensao(string extensao_arquivo)
        {
            List<String> listaarquivos = ObterNomesDosArquivosDoDiretorioAtual();
            List<String> listaarquivosretorno = new List<String>();

            Boolean encontrou = false;
            int posicao = 0;

            foreach (String nome_arquivo in listaarquivos)
            {
                string[] nome_arquivo_separado = nome_arquivo.Split(".");

                string extensao_arquivo_diretorio = nome_arquivo_separado[nome_arquivo_separado.Length - 1];

                if (extensao_arquivo.ToLower().Equals(extensao_arquivo_diretorio.ToLower()))
                {
                    listaarquivosretorno.Add(nome_arquivo);
                }
            }

            return listaarquivosretorno;
        }

        public static string ObterApenasNomeDoArquivo(string caminho_com_arquivo_e_diretorio)
        {
            string nomeoriginalarquivo = "";

            string[] nomes = caminho_com_arquivo_e_diretorio.Split("\\");

            nomeoriginalarquivo = nomes[nomes.Length - 1];

            return nomeoriginalarquivo;
        }

        public static Boolean VerificaSeExisteDeterminadaExtensaoEmAlgumArquivoNoDiretorioAtual(string extensao_arquivo)
        {
            List<String> listaarquivos = ObterNomesDosArquivosDoDiretorioAtual();

            Boolean encontrou = false;
            int posicao = 0;

            while (!encontrou && posicao != listaarquivos.Count() - 1)
            {
                string[] nome_arquivo_separado = listaarquivos[posicao].Split(".");

                string extensao_arquivo_diretorio = nome_arquivo_separado[nome_arquivo_separado.Length - 1];

                if (extensao_arquivo.ToLower().Equals(extensao_arquivo_diretorio.ToLower()))
                {
                    encontrou = true;
                }

                posicao++;
            }

            return encontrou;
        }

        public static Boolean VerificaSeExisteDeterminadaExtensaoDeUmArquivoInformado(string arquivo_atual, string extensao_arquivo)
        {
            Boolean encontrou = false;

            while (!encontrou)
            {
                string[] nome_arquivo_separado = arquivo_atual.Split(".");

                string extensao_arquivo_diretorio = nome_arquivo_separado[nome_arquivo_separado.Length - 1];

                if (extensao_arquivo.ToLower().Equals(extensao_arquivo_diretorio.ToLower()))
                {
                    encontrou = true;
                }
            }

            return encontrou;
        }

        public static Boolean VerificaSeExisteDeterminadoArquivoExisteNoDiretorioAtual(string arquivo_atual)
        {
            Boolean encontrou = false;

            List<String> arquivos_diretorio_atual = ObterNomesDosArquivosDoDiretorioAtual();

            int posicao = 0;

            while (!encontrou && posicao != arquivos_diretorio_atual.Count() - 1)
            {
                if (arquivos_diretorio_atual[posicao].ToLower().Equals(arquivo_atual.ToLower()))
                {
                    encontrou = true;
                }

                posicao++;
            }

            return encontrou;
        }
    }
}
