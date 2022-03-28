using RS.Calculo.Api.Models;

namespace RS.Calculo.Api.Data.Repository
{
    public class RepositorioGitHubRepository : IRepositorioGitHubRepository
    {
        private string DIRETORIO_GITHUB => "https://github.com/RenatoASousa/RenatoSousaJuros";

        public RepositorioGitHubRepository() { }

        public string Obter()
        {
            return DIRETORIO_GITHUB;
        }
    }
}
