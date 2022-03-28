using Microsoft.AspNetCore.Mvc;
using RS.Taxa.Api.Models;

namespace RS.Taxa.Api.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    public class TaxaController : ControllerBase
    {

        private readonly ITaxaRepository _taxaRepository;

        public TaxaController(ITaxaRepository taxaRepository)
        {
            _taxaRepository = taxaRepository;
        }

        [HttpGet("Taxa")]
        public decimal GetTaxa()
        {
            return _taxaRepository.Obter();
        }

    }
}
