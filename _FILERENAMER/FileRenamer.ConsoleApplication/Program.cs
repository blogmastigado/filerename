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
        public static String extensao_arquivos { get; set; }
        public static String termo_substituido { get; set; }
        public static String termo_removido { get; set; }
        public static String termo_novo { get; set; }
        public static String termo_referencia { get; set; }
        public static Boolean posicao_anterior_a_termo { get; set; }

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
            termo_substituido = "";
            termo_novo = "";
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
            Console.WriteLine("********************************");
            Console.WriteLine("O que deseja fazer?: ");
            Console.WriteLine("Pressione 1 caso queira escolher qual o tipo (EXTENSÃO) de arquivos deseja RENOMEAR.");            
            Console.WriteLine("********************************");
            Console.WriteLine("Pressione 2 para definir qual termo deseja INSERIR ou INSERIR para SUBSTITUIR outro nos nomes dos arquivos.");
            Console.WriteLine("********************************");
            Console.WriteLine("Pressione 3 caso também queira informar um termo para INSERIR no INÍCIO dos nomes dos arquivos.");
            Console.WriteLine("********************************");
            Console.WriteLine("Pressione 4 caso também queira informar um termo para INSERIR no FIM dos nomes dos arquivos.");
            Console.WriteLine("********************************");            
            Console.WriteLine("Pressione 5 se quer informar algum termo para ser SUBSTITUIDO nos nomes dos arquivos.");
            Console.WriteLine("********************************");
            Console.WriteLine("Pressione 6 para informar qual termo deseja REMOVER dos nomes dos arquivos, se desejar.");
            Console.WriteLine("********************************");
            Console.WriteLine("Pressione 7 para ver as configurações que serão usadas na execução do programa.");
            Console.WriteLine("********************************");
            Console.WriteLine("Pressione 0, para finalizar o programa.");
            Console.WriteLine("********************************");
            Console.WriteLine("");
            Console.WriteLine("**************** Observação 1 ********************  **************** Observação 2 ********************");            
            Console.WriteLine("* Caso não tenha sido informada a extensão dos   *  * Caso tenha sido informado qual é o termo que   *");
            Console.WriteLine("* arquivos que deseja ALTERAR, serão alterados   *  * deseja SUBSTITUIR nos nomes dos arquivos, é    *");
            Console.WriteLine("* todos os nome de arquivos do diretório.        *  * preciso ter informar qual termo deseja         *");
            Console.WriteLine("**************************************************  * INSERIR no lugar, caso contrário nada será     *");
            Console.WriteLine("                                                    * substituído.                                   *");
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
                    // Armazenar termo que será usando para inserir ou substituir nos arquivos
                    case 2:
                        ArmazenarNovoTermoParaInsercao();
                        break;
                    // Visualizar as configurações que serão executadas no sistema
                    case 3:
                        VisualizarConfiguracoesDeExecucaoDoSistema();
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

            Console.WriteLine("");

            //Console.ReadKey();
        }

        public static void ArmazenarNovoTermoParaInsercao()
        {
            Console.Clear();

            Console.WriteLine("Informe qual é o termo que deseja inserir nos nomes dos arquivos do diretório. Se não informar não ocorrerão alterações.");

            extensao_arquivos = Console.ReadLine();

            if (!String.IsNullOrEmpty(termo_novo))
            {
                Console.WriteLine("O novo termo informado foi " + termo_novo + ". Caso deseja alterá-lo retorne neste menu.");
            }
            else
            {
                Console.WriteLine("O termo permanece vazio e o programa não inserirá nenhum termo adicional no(s) arquivo(s) do diretório.");
            }

            Console.WriteLine("");

            //Console.ReadKey();
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

            // Visualizar se termo a ser substuído foi definido
            if (!String.IsNullOrEmpty(termo_substituido))
            {
                Console.WriteLine("********* Termo a ser Substituído Definido *********");
                Console.WriteLine("O termo a ser substituído é " + termo_substituido + "");
                Console.WriteLine("Nessa configuração somente os arquivos que ");
                Console.WriteLine("possuem esse termo sofrerão alterações.");
                Console.WriteLine("*************************************************");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("********* Termo a ser Substituído NÃO Definido *********");
                Console.WriteLine("Não há termo algum a ser substituído. ");
                Console.WriteLine("tipo de filtro e por isso todos os arquivos ");
                Console.WriteLine("do diretório atual sofrerão alterações.");
                Console.WriteLine("");
            }

            Console.WriteLine("");

            //Console.ReadKey();
        }

        

    }
}
