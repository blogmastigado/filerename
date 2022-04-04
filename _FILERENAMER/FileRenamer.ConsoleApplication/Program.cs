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

            Console.WriteLine("O sistema foi finalizado.");

            Console.ReadKey();            
        }

        public static void ExecutarConfiguracaoInicialDoPrograma()
        {
            extensao_arquivos = "";
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
            Console.WriteLine("Pressione 1, caso queira escolher quais tipos de arquivos deseja renomear.");
            Console.WriteLine("********************************");
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
                    // Sair do Programa
                    case 1:
                        Console.WriteLine("Digite qual a extensão dos arquivos que sofrerão alteração.");
                        ArmazenarExtensaoDosArquivosQueSeraoRenomeados();
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

    }
}
