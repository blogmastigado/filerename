using System;
using System.Collections.Generic;
using System.IO;
using FileRenamer.Aplicacao;
//using System.IO.Path;
//using static System.Net.Mime.MediaTypeNames;

namespace FileRename
{
    public class Program
    {        
        public static String extensao_arquivos { get; set; }
        public static String termo_a_substituir { get; set; }
        public static String termo_removido { get; set; }
        public static String termo_referencia { get; set; }

		public static String termo_referencia_esquerda { get; set; }
		public static String termo_referencia_direita { get; set; }
		public static String termo_anterior_a_referencia { get; set; }
        public static String termo_referencia_anterior { get; set; }
        public static String termo_posterior_a_referencia { get; set; }
        public static String termo_referencia_posterior { get; set; }
		public static int numero_referencia { get; set; }

		public static void Main(string[] args)
        {
            bool sair = false;

            ExecutarConfiguracaoInicialDoPrograma();

            while (!sair)
            {
                ExibirMenuPrincipalDoSistema();

                int escolha = RetornarEscolhaParaSubMenuDeEscolhas();

                if (escolha == 0)
                {
                    if (RetornarConfirmacaoDeSaidaDoSistema(escolha) == 0)
                    {
                        sair = true;
                    }
                }
            }

            Console.Clear();

            Console.WriteLine("O sistema foi finalizado.");

            Console.ReadKey();            
        }

        public static void ExecutarConfiguracaoInicialDoPrograma()
        {
            extensao_arquivos = "";
            termo_a_substituir = "";            
            termo_removido = "";
            termo_referencia = "";
			termo_referencia_esquerda = "";
			termo_referencia_direita = "";
			termo_anterior_a_referencia = "";
            termo_referencia_anterior = "";
            termo_posterior_a_referencia = "";
            termo_referencia_posterior = "";
			numero_referencia = 0;
		}

        public static int ExecutarLoopDeEscolhas(int escolha)
        {
            while (escolha != 0)
            {
                ExibirMenuPrincipalDoSistema();

                try
                {
                    escolha = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Digite apenas números.");
                }

                Console.ReadKey();
            }

            return escolha;
        }

        public static void ExibirMenuPrincipalDoSistema()
        {            
            Console.WriteLine("O que deseja fazer?: ");
            Console.WriteLine("");
            Console.WriteLine("Pressione 1 caso queira escolher qual o tipo (EXTENSÃO) de arquivos deseja RENOMEAR.");            
            Console.WriteLine("***********");
            Console.WriteLine("Pressione 2 para NOMEAR um termo (TERMO de REFERÊNCIA) que deseja SUBSTITUIR por outro nos nomes dos arquivos.");            
            Console.WriteLine("***********");
			Console.WriteLine("Pressione 3 para NOMEAR termo(s) (TERMO de REFERÊNCIA à ESQUERDA/DIREITA) que será(ão) usado(s) para identificar uma zona de renumeração descendente nos nome(s) do(s) arquivo(s) (só tem efeito para renumerar arquivos).");
			Console.WriteLine("***********");
			Console.WriteLine("Pressione 4 para INSERIR um termo antes de um TERMO de REFERÊNCIA nos nome(s) do(s) arquivo(s).");
            Console.WriteLine("***********");
            Console.WriteLine("Pressione 5 para INSERIR um termo depois de um TERMO de REFERÊNCIA nos nome(s) do(s) arquivo(s).");            
            Console.WriteLine("***********");
            Console.WriteLine("Pressione 6 para INFORMAR qual termo deseja REMOVER nos nomes dos arquivos, se desejar.");            
			Console.WriteLine("***********");
			Console.WriteLine("Pressione 7 para VER as configurações que serão usadas na execução do programa.");
            Console.WriteLine("***********");
            Console.WriteLine("Pressione 8 para VISUALIZAR todo os arquivos de seu diretório.");
            Console.WriteLine("***********");
            Console.WriteLine("Pressione 9 para RENOMEAR os arquivos do diretório conforme CONFIGURAÇÃO FEITA PREVIAMENTE.");
            Console.WriteLine("***********");
			Console.WriteLine("Pressione 10 para RENUMERAR de forma descendente os arquivos do diretório conforme NÚMERO de REFERÊNCIA após o TERMO de REFERÊNCIA.");
			Console.WriteLine("***********");
			Console.WriteLine("Pressione 0 para FINALIZAR o programa.");
            Console.WriteLine("***********");
            Console.WriteLine("");
            Console.WriteLine("**************** Observação 1 ********************  **************** Observação 2 ********************");            
            Console.WriteLine("* Caso não tenha sido informada a extensão dos   *  * Caso tenha sido informado qual é o termo que   *");
            Console.WriteLine("* arquivos que deseja ALTERAR, serão alterados   *  * deseja SUBSTITUIR nos nomes dos arquivos, é    *");
            Console.WriteLine("* todos os nomes de arquivos do diretório.       *  * preciso informar qual termo deseja INSERIR     *");
            Console.WriteLine("**************************************************  * no lugar, caso contrário nada será substituído.*");          
            Console.WriteLine("                                                    **************************************************");            
            Console.WriteLine("");            
        }

        public static int RetornarEscolhaParaSubMenuDeEscolhas()
        {
            int escolha = 0;

            try
            {
                escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha)
                {
                    // Sair do Programa
                    case 0:
                        Console.WriteLine("O programa será finalizado");
                        break;
                    // Escolha da extensão do arquivo
                    case 1:
                        Console.WriteLine("Digite qual a extensão dos arquivos que sofrerão alteração.");
                        ArmazenarExtensaoDosArquivosQueSeraoRenomeados();
                        break;
                    // Armazenar termo que será usado para referência na inserção ou substituição de outro termo nos arquivos
                    case 2:
                        ArmazenarNovoTermoParaInsercao();
                        break;
					// Armazenar termo de referência da direita e número que será usado para inserir ou substituir números nos arquivos entre ele e o de referência
					case 3:
						ArmazenarNovoTermoADireitaParaAlteracaoDeNumerosEntreTermosDeReferencia();
						break;
					// Armazenar termo para inserido antes de uma referência
					case 4:
                        ArmazenarTermoParaInserirAntesDeUmaReferencia();
                        break;
                    // Armazenar termo para inserido depois de uma referência
                    case 5:
                        ArmazenarTermoParaInserirDepoisDeUmaReferencia();
                        break;
                    // Armazenar termo para ser removido
                    case 6:
                        ArmazenarTermoParaSerRemovido();
                        break;
					// Visualizar as configurações que serão executadas no sistema
					case 7:
                        VisualizarConfiguracoesDeExecucaoDoSistema();
                        break;
                    // Visualizar todos os arquivos de seu diretório
                    case 8:
                        VisualizarArquivosDoDiretorioAtual();
                        break;
                    // Renomear arquivos conforme regras pré configuradas
                    case 9:
                        RenomearArquivos();
                        break;
					// Renumerar arquivos conforme regras pré configuradas (Termo de Referência 
					case 10:
						RenumerarArquivos();
						break;					
					default:
                        Console.WriteLine("Opção Incorreta. Escolha uma das opções a seguir.");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Opção incorreta!");
            }

            return escolha;
        }

        public static int RetornarConfirmacaoDeSaidaDoSistema(int escolha)
        {
            Console.Clear();

            if (escolha == 0)
            {
                int opcao = 2;

                while (opcao != 0 && opcao != 1)
                {
                    Console.WriteLine("Digite 1 para continuar ou 0 para finalizar o programa.");

                    try
                    {
                        opcao = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Opção Inválida.");
                    }
                }

                escolha = opcao;
            }

            return escolha;
        }

        public static void ArmazenarExtensaoDosArquivosQueSeraoRenomeados()
        {
            Console.Clear();

            Console.WriteLine("Informe qual é a extensão dos arquivos que deseja renomear. Se não informar todos os arquivos do diretório sofrerão alterações.");

            extensao_arquivos = Console.ReadLine();

            if (!String.IsNullOrEmpty(extensao_arquivos))
            {
                Console.WriteLine("A extensão informada foi " + extensao_arquivos + ". Caso deseja alterá-la retorne neste menu.");
            }
            else
            {
                Console.WriteLine("A extensão permnacerá vazia.");
            }

            LimparTelaParaProximaInstrucao();
        }

        public static void ArmazenarNovoTermoParaInsercao()
        {
            Console.Clear();

            Console.WriteLine("Informe qual é o termo que deseja inserir nos nomes dos arquivos do diretório. Se não informar não ocorrerão alterações.");

            termo_referencia = Console.ReadLine();

            if (!String.IsNullOrEmpty(termo_referencia))
            {
                Console.WriteLine("Informe qual é o termo a ser substituído que deseja indicar para ser usada antes do termo informado nos nomes dos arquivos do diretório. Se não informar não ocorrerão alterações.");

                termo_a_substituir = Console.ReadLine();

                if (!String.IsNullOrEmpty(termo_a_substituir))
                {
                    Console.WriteLine("O termo a ser substituído informado foi " + termo_a_substituir + " e " + termo_referencia + " entrará em seu lugar. Caso deseja alterá-lo retorne neste menu.");
                }
                else
                {
                    termo_referencia = "";
                    termo_a_substituir = "";

                    Console.WriteLine("O termo a ser inserido ou a ser substituído permanece vazio e o programa não inserirá nenhum termo adicional no(s) arquivo(s) do diretório.");
                }
            }
            else
            {
                termo_referencia = "";
                termo_a_substituir = "";

                Console.WriteLine("O termo a ser inserido ou a ser substituído permanece vazio e o programa não inserirá nenhum termo adicional no(s) arquivo(s) do diretório.");
            }

            Console.WriteLine("");
            Console.WriteLine("Pressione uma tecla para continuar.");
            Console.ReadKey();
        }

		public static void ArmazenarNovoTermoADireitaParaAlteracaoDeNumerosEntreTermosDeReferencia()
		{
			Console.Clear();

			Console.WriteLine("Informe qual é o termo à esquerda do atual número de referência que deseja inserir nos nomes dos arquivos do diretório. Se não informar não ocorrerão alterações neste termo.");

			termo_referencia_esquerda = Console.ReadLine();

			if (!String.IsNullOrEmpty(termo_referencia_esquerda))
			{
				Console.WriteLine("Informe qual é o termo à direita que deseja indicar para ser usada depois do número de referência informado nos nomes dos arquivos do diretório. Se não informar não ocorrerão alterações neste termo.");

				termo_referencia_direita = Console.ReadLine();

				if (String.IsNullOrEmpty(termo_referencia_direita))
				{
					termo_referencia_direita = "";
				}
			}
            else
            {
				Console.WriteLine("Informe qual é o termo à direita que deseja indicar para ser usada depois do número de referência informado nos nomes dos arquivos do diretório. Se não informar não ocorrerão alterações neste termo.");

				termo_referencia_direita = Console.ReadLine();

				if (String.IsNullOrEmpty(termo_referencia_direita))
				{
					termo_referencia_esquerda = "";
					termo_referencia_direita = "";
				}
			}

			if (String.IsNullOrEmpty(termo_referencia_esquerda) && String.IsNullOrEmpty(termo_referencia_direita))
            {
				termo_referencia_esquerda = "";
				termo_referencia_direita = "";
				numero_referencia = 0;

				Console.WriteLine("O termos de referência para realizar a renumeração permanecem vazios e o programa não inserirá nenhum termo adicional no(s) arquivo(s) do diretório.");
			}
            else
            {
				try
				{
					Console.WriteLine("Informe qual é o número de referência deseja indicar para inserir ou substituir os números de forma descendente no arquivos do diretório. Se não informar não ocorrerão alterações neste termo.");

					numero_referencia = Int32.Parse(Console.ReadLine());

					Console.WriteLine("O número de referência informado foi " + numero_referencia + " e será armazenado de forma descendente entre a o termo de refereência da esquerda e da direita. Caso deseja alterá-lo retorne neste menu.");
				}
				catch (Exception ex)
				{
					Console.WriteLine("O número permanece vazio e já que não foi informado adequadamente, ele permanecerá sendo 0 (zero).");
				}
				finally
				{
					LimparTelaParaProximaInstrucao();
				}
			}


			Console.WriteLine("");
			Console.WriteLine("Pressione uma tecla para continuar.");
			Console.ReadKey();
		}

		public static void ArmazenarTermoParaInserirAntesDeUmaReferencia()
        {
            Console.Clear();

            Console.WriteLine("Informe qual é o termo que deseja inserir antes de uma referência nos nomes dos arquivos do diretório. Se não informar não ocorrerão alterações.");

            termo_anterior_a_referencia = Console.ReadLine();

            if (!String.IsNullOrEmpty(termo_anterior_a_referencia))
            {
                Console.WriteLine("Informe qual é a referência que deseja indicar para ser usada antes do termo informado nos nomes dos arquivos do diretório. Se não informar não ocorrerão alterações.");

                termo_referencia_anterior = Console.ReadLine();

                if (!String.IsNullOrEmpty(termo_referencia_anterior))
                {
                    Console.WriteLine("A referência informado foi " + termo_referencia_anterior + " e o termo informado é " + termo_anterior_a_referencia + ". Caso deseja alterá-los retorne neste menu.");
                }
                else
                {
                    termo_anterior_a_referencia = "";
                    termo_referencia_anterior = "";

                    Console.WriteLine("Nenhum termo pode permanecer vazio e por isso o programa não substituirá nenhum termo adicional no(s) arquivo(s) do diretório nessa modalidade.");
                }
            }
            else
            {
                termo_anterior_a_referencia = "";
                termo_referencia_anterior = "";

                Console.WriteLine("Os termos permanecem vazios e o programa não substituirá nenhum termo adicional no(s) arquivo(s) do diretório.");
            }

            LimparTelaParaProximaInstrucao();
        }

        public static void ArmazenarTermoParaInserirDepoisDeUmaReferencia()
        {
            Console.Clear();

            Console.WriteLine("Informe qual é o termo que deseja inserir depois de uma referência nos nomes dos arquivos do diretório. Se não informar não ocorrerão alterações.");

            termo_posterior_a_referencia = Console.ReadLine();

            if (!String.IsNullOrEmpty(termo_posterior_a_referencia))
            {
                Console.WriteLine("Informe qual é a referência que deseja indicar para ser usada depois do termo informado nos nomes dos arquivos do diretório. Se não informar não ocorrerão alterações.");

                termo_referencia_posterior = Console.ReadLine();

                if (!String.IsNullOrEmpty(termo_referencia_posterior))
                {
                    Console.WriteLine("A referência informado foi " + termo_referencia_posterior + " e o termo informado é " + termo_posterior_a_referencia + ". Caso deseja alterá-los retorne neste menu.");
                }
                else
                {
                    termo_posterior_a_referencia = "";
                    termo_referencia_posterior = "";

                    Console.WriteLine("Nenhum termo pode permanecer vazio e por isso o programa não substituirá nenhum termo adicional no(s) arquivo(s) do diretório nessa modalidade.");
                }
            }
            else
            {
                termo_posterior_a_referencia = "";
                termo_referencia_posterior = "";

                Console.WriteLine("Os termos permanecem vazios e o programa não substituirá nenhum termo adicional no(s) arquivo(s) do diretório.");
            }

            LimparTelaParaProximaInstrucao();
        }

        public static void ArmazenarTermoParaSerRemovido()
        {
            Console.Clear();

            Console.WriteLine("Informe qual é o termo que deseja remover nos nomes dos arquivos do diretório. Se não informar não ocorrerão alterações.");

            termo_removido = Console.ReadLine();

            if (!String.IsNullOrEmpty(termo_removido))
            {
                Console.WriteLine("O termo a ser removido informado foi " + termo_removido + ". Caso deseja alterá-lo retorne neste menu.");
            }
            else
            {
                Console.WriteLine("O termo permanece vazio e o programa não removerá nenhum termo adicional no(s) arquivo(s) do diretório.");
            }

            LimparTelaParaProximaInstrucao();
        }

		public static void VisualizarConfiguracoesDeExecucaoDoSistema()
        {
            Console.Clear();

            // Visualizar se extensão de arquivos a serem alterados foi definida
            if (!String.IsNullOrEmpty(extensao_arquivos))
            {
                Console.WriteLine("********* Extensão de Arquivos Definida *********");
                Console.WriteLine("A extensão informada é " + extensao_arquivos + ".");
                Console.WriteLine("Nessa configuração somente os arquivos que ");
                Console.WriteLine("possuem essa extensão sofrerão alterações.");
                Console.WriteLine("*************************************************");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("********* Extensão de Arquivos NÃO Definida *********");
                Console.WriteLine("Não há extensão de arquivo para fazer algum ");
                Console.WriteLine("tipo de filtro e por isso todos os arquivos ");
                Console.WriteLine("do diretório atual sofrerão alterações.");
                Console.WriteLine("");
            }

            // Visualizar se termo a ser inserido foi definido
            if (!String.IsNullOrEmpty(termo_referencia))
            {
                Console.WriteLine("********* Termo a Substituir outro Definido *********");
                Console.WriteLine("O termo a ser substituido " + termo_a_substituir + " ");
                Console.WriteLine("e " + termo_referencia + " entrará em seu lugar");                
                Console.WriteLine("Nessa configuração somente os arquivos que ");
                Console.WriteLine("possuem esse termo sofrerão alterações.");
                Console.WriteLine("*************************************************");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("********* Termo a ser Substituir outro NÃO Definido *********");
                Console.WriteLine("Não há termo algum a ser inserido. ");
                Console.WriteLine("tipo de filtro e por isso todos os arquivos ");
                Console.WriteLine("do diretório atual sofrerão alterações.");
                Console.WriteLine("");
            }

            // Visualizar se termo a ser inserido antes de uma referência foi definido
            if (!String.IsNullOrEmpty(termo_anterior_a_referencia))
            {
                Console.WriteLine("********* Termo a ser Inserido Antes de uma Referência Definido *********");                
                Console.WriteLine("O termo a ser inserido antes de uma referência é " + termo_anterior_a_referencia + " ");
                Console.WriteLine("e o termo referência é " + termo_referencia_anterior);
                Console.WriteLine("Nessa configuração somente os arquivos que ");
                Console.WriteLine("possuem esse termo sofrerão alterações.");
                Console.WriteLine("*************************************************");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("********* Termo a ser Inserido Antes de uma Referência NÃO Definido *********");
                Console.WriteLine("Não há termo algum a ser inserido antes de uma referência. ");
                Console.WriteLine("tipo de filtro e por isso todos os arquivos ");
                Console.WriteLine("do diretório atual sofrerão alterações.");
                Console.WriteLine("");
            }

            // Visualizar se termo a ser inserido depois de uma referência foi definido
            if (!String.IsNullOrEmpty(termo_posterior_a_referencia))
            {
                Console.WriteLine("********* Termo a ser Inserido Depois de uma Referência Definido *********");                
                Console.WriteLine("O termo a ser inserido depois de uma referência é " + termo_posterior_a_referencia + " ");
                Console.WriteLine("e o termo referência é " + termo_referencia_posterior);
                Console.WriteLine("Nessa configuração somente os arquivos que ");
                Console.WriteLine("possuem esse termo sofrerão alterações.");
                Console.WriteLine("*************************************************");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("********* Termo a ser Inserido Depois de uma Referência NÃO Definido *********");
                Console.WriteLine("Não há termo algum a ser depois antes de uma referência. ");
                Console.WriteLine("tipo de filtro e por isso todos os arquivos ");
                Console.WriteLine("do diretório atual sofrerão alterações.");
                Console.WriteLine("");
            }

            // Visualizar se termo a ser removido foi definido
            if (!String.IsNullOrEmpty(termo_removido))
            {
                Console.WriteLine("********* Termo a ser Removido Definido *********");
                Console.WriteLine("O termo a ser removido é " + termo_removido + "");
                Console.WriteLine("Nessa configuração somente os arquivos que ");
                Console.WriteLine("possuem esse termo sofrerão alterações.");
                Console.WriteLine("*************************************************");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("********* Termo a ser Removido NÃO Definido *********");
                Console.WriteLine("Não há termo algum a ser removido. ");
                Console.WriteLine("tipo de filtro e por isso todos os arquivos ");
                Console.WriteLine("do diretório atual sofrerão alterações.");
                Console.WriteLine("");
            }

            LimparTelaParaProximaInstrucao();
        }

        public static void VisualizarArquivosDoDiretorioAtual()
        {
            Console.Clear();

            List<String> nomes_originais_arquivos = GestorDeArquivo.ObterNomesDosArquivosDoDiretorioAtual();

            Console.WriteLine("Estes são os atuais aqui deste diretório:");
            Console.WriteLine("");

            foreach (String nome_arquivo in nomes_originais_arquivos)
            {
                Console.WriteLine(nome_arquivo);
            }

            LimparTelaParaProximaInstrucao();
        }

        public static void RenomearArquivos()
        {
            int nao_processados = 0;

            // Verifica se é possível substituir termos de arquivos por um novo termo e executar se for possível
            if (!String.IsNullOrEmpty(termo_referencia) && (!String.IsNullOrEmpty(termo_a_substituir)))
            {
                if (!String.IsNullOrEmpty(extensao_arquivos))
                {
                    nao_processados = GestorDeArquivo.SubstituirTermoEmArquivosDeDiretorioAtual(termo_referencia, termo_a_substituir, extensao_arquivos);
                }
                else
                {
                    nao_processados = GestorDeArquivo.SubstituirTermoEmArquivosDeDiretorioAtual(termo_referencia, termo_a_substituir,"");
                }

                Console.WriteLine("O termo : " + termo_a_substituir + " foi substuído nos arquivos por " + termo_referencia);
                Console.WriteLine("A quantidade de arquivos que não foram processados no diretório foi de : " +  nao_processados);
                VisualizarArquivosDoDiretorioAtual();

                nao_processados = 0;
            }

            // Verifica se é possível inserir novos termos antes de algum termo de referência e executar se for possível
            if (!String.IsNullOrEmpty(termo_anterior_a_referencia) && (!String.IsNullOrEmpty(termo_referencia_anterior)))
            {
                string novo_termo = termo_anterior_a_referencia + " " + termo_referencia_anterior;

                if (!String.IsNullOrEmpty(extensao_arquivos))
                {
                    nao_processados = GestorDeArquivo.SubstituirTermoEmArquivosDeDiretorioAtual(novo_termo, termo_referencia_anterior, extensao_arquivos);
                }
                else
                {
                    nao_processados = GestorDeArquivo.SubstituirTermoEmArquivosDeDiretorioAtual(novo_termo, termo_referencia_anterior, "");
                }

                Console.WriteLine("O termo : " + termo_anterior_a_referencia + " foi inserido nos arquivos antes de " + termo_referencia_anterior);
                Console.WriteLine("A quantidade de arquivos que não foram processados no diretório foi de : " + nao_processados);
                VisualizarArquivosDoDiretorioAtual();

                nao_processados = 0;
            }

            // Verifica se é possível inserir novos termos depois de algum termo de referência e executar se for possível
            if (!String.IsNullOrEmpty(termo_posterior_a_referencia) && (!String.IsNullOrEmpty(termo_referencia_posterior)))
            {
                string novo_termo = termo_referencia_posterior + " " + termo_posterior_a_referencia;

                if (!String.IsNullOrEmpty(extensao_arquivos))
                {
                    nao_processados = GestorDeArquivo.SubstituirTermoEmArquivosDeDiretorioAtual(novo_termo, termo_referencia_posterior, extensao_arquivos);
                }
                else
                {
                    nao_processados = GestorDeArquivo.SubstituirTermoEmArquivosDeDiretorioAtual(novo_termo, termo_referencia_posterior, "");
                }

                Console.WriteLine("O termo : " + termo_posterior_a_referencia + " foi inserido nos arquivos depois de " + termo_referencia_posterior);
                Console.WriteLine("A quantidade de arquivos que não foram processados no diretório foi de : " + nao_processados);
                VisualizarArquivosDoDiretorioAtual();

                nao_processados = 0;
            }

            // Verifica se é possível remover termos de arquivos por um novo termo e executar se for possível
            if (!String.IsNullOrEmpty(termo_removido))
            {
                string novo_termo = " " + termo_removido;

                if (!String.IsNullOrEmpty(extensao_arquivos))
                {
                    nao_processados = GestorDeArquivo.SubstituirTermoEmArquivosDeDiretorioAtual(novo_termo, termo_removido, extensao_arquivos);
                }
                else
                {
                    nao_processados = GestorDeArquivo.SubstituirTermoEmArquivosDeDiretorioAtual(novo_termo, termo_removido, "");
                }

                Console.WriteLine("O termo : " + termo_removido + " foi removido nos arquivos.");
                Console.WriteLine("A quantidade de arquivos que não foram processados no diretório foi de : " + nao_processados);
                VisualizarArquivosDoDiretorioAtual();

                nao_processados = 0;
            }
        }

		public static void RenumerarArquivos()
		{
			int nao_processados = 0;

			nao_processados = GestorDeArquivo.SubstituirNumeracaoEmArquivosDeDiretorioAtual(termo_referencia_esquerda, termo_referencia_direita, numero_referencia);

			if (String.IsNullOrEmpty(termo_referencia_esquerda) && !String.IsNullOrEmpty(termo_referencia_direita))
			{
				Console.WriteLine("O termo : " + numero_referencia + " foi substuído de forma descendente nos arquivos com referência à direita chamada " + termo_referencia_direita);
			}
			else
			{
				if (!String.IsNullOrEmpty(termo_referencia_esquerda) && String.IsNullOrEmpty(termo_referencia_direita))
				{
					Console.WriteLine("O termo : " + numero_referencia + " foi substuído de forma descendente nos arquivos com referência à esquerda chamada " + termo_referencia_esquerda);
				}
				else
				{
					if (!String.IsNullOrEmpty(termo_referencia_esquerda) && !String.IsNullOrEmpty(termo_referencia_direita))
					{
						Console.WriteLine("O termo : " + numero_referencia + " foi substuído de forma descendente nos arquivos entre " + termo_referencia_esquerda + " e " + termo_referencia_direita);
					}
				}
			}


			Console.WriteLine("A quantidade de arquivos que não foram processados no diretório foi de : " + nao_processados);
			VisualizarArquivosDoDiretorioAtual();

			nao_processados = 0;
		}

		protected static void LimparTelaParaProximaInstrucao()
        {
            Console.WriteLine("");
            Console.WriteLine("Pressione uma tecla para continuar.");
            Console.ReadKey();
        }

    }
}
