using FileRenamer.Aplicacao;
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
        [InlineData("nomequalquer")]
        [InlineData("C:")]
        public void ObtendoOsArquivosDoDiretorioAtual(string diretorio)
        {
            GestorDeArquivo.ObterTodosOsNomesDeArquivosDeUmDiretorioComCaminhoCompleto(diretorio);
        }
    }
}