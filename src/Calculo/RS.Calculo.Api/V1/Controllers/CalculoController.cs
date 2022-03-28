using Microsoft.AspNetCore.Mvc;
using RS.Calculo.Api.Models;
using System.Threading.Tasks;

namespace RS.Calculo.Api.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/calculo")]
    public class CalculoController : ControllerBase
    {
        private readonly IRepositorioGitHubRepository _repositorioGitHubRepository;
        private readonly ITaxaRepository _taxaRepository;

        public CalculoController(IRepositorioGitHubRepository repositorioGitHubRepository, ITaxaRepository taxaRepository)
        {
            _repositorioGitHubRepository = repositorioGitHubRepository;
            _taxaRepository = taxaRepository;
        }

        [HttpGet("calculajuros")]
        public async Task<decimal> CalcularJuros(int meses, decimal valor)
        {
            return await _taxaRepository.Obter(meses, valor);
        }


        [HttpGet("showmethecode")]
        public string ShowMeTheCode()
        {
            return _repositorioGitHubRepository.Obter();
        }

    }
}
