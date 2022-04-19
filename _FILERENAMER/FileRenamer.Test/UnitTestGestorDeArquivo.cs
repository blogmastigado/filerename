using FileRenamer.Aplicacao;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileRename.Test
{
    public class UnitTestGestorDeArquivo
    {
        public string nome_diretorio_atual { get; set; }

        public UnitTestGestorDeArquivo()
        {
            nome_diretorio_atual = GestorDeArquivo.ObterNomeDoDiretorioAtualComCaminhoCompleto();
        }

        [Fact]
        public void ExibirNomeDoDiretorioAtual()
        {
            GestorDeArquivo.ExibirApenasOsNomesDosArquivosDoDiretorioAtual();
        }
                
        [Theory]
        [InlineData("extensaoqualquer")]
        [InlineData("C:")]
        public void ObtendoOsArquivosDoDiretorioAtual(string extensao)
        {
            List<String> listadenomesdearquivos = GestorDeArquivo.ObterTodosOsNomesDeArquivosPorExtensaoDoDiretorioAtualComCaminhoCompleto(extensao);
        }
    }
}