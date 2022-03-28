using System.Threading.Tasks;

namespace RS.Calculo.Api.Application.Queries
{
    public interface IQueryHandler<TQuery, TResult>
    {
        Task<decimal> ExecuteAsync(TQuery query);
    }
}
