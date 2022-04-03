using FileRename.Aplicacao;
using Xunit;

namespace FileRename.Test
{
    public class UnitTestGestorDeArquivo
    {
        public GestorDeArquivo GestorDeArquivo { get; set; }
        public string nome_diretorio_atual { get; set; }

        public UnitTestGestorDeArquivo()
        {
            GestorDeArquivo = new GestorDeArquivo();
            nome_diretorio_atual = GestorDeArquivo.ObterNomeDoDiretorioAtual();
        }

        [Fact]
        public void ExibirNomeDoDiretorioAtual()
        {
            GestorDeArquivo.ExibirNomesDosArquivosDoDiretorioAtual();
        }
                
        [Theory]
        [InlineData("nomequalquer")]
        [InlineData("C:")]
        public void ObtendoOsArquivosDoDiretorioAtual(string diretorio)
        {
            GestorDeArquivo.ObterTodosOsNomesDeArquivosDeUmDiretorio(diretorio);
        }
    }
}