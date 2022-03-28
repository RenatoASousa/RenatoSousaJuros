using System.Threading.Tasks;

namespace RS.Calculo.Api.Models
{
    public interface ITaxaRepository
    {
        Task<decimal> Obter(int meses, decimal valor);
    }
}
