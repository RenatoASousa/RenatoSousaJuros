using RS.Calculo.Api.Application.Queries;
using RS.Calculo.Api.Models;
using System.Threading.Tasks;

namespace RS.Calculo.Api.Data.Repository
{
    public class TaxaRepository : ITaxaRepository
    {
        private readonly IQueryHandler<TaxaQuery, decimal> _queryHandler;

        public TaxaRepository(IQueryHandler<TaxaQuery, decimal> queryHandler)
        {
            _queryHandler = queryHandler;
        }

        public async Task<decimal> Obter(int meses, decimal valor)
        {
            var taxa = await _queryHandler.ExecuteAsync(new TaxaQuery());
            var calculo = new CalculaJuros(meses, valor, taxa);

            return calculo.CalcularTotal();
        }
    }
}
