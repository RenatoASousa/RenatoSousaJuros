using RS.Taxa.Api.Models;

namespace RS.Taxa.Api.Data.Repository
{
    public class TaxaRepository : ITaxaRepository
    {
        public decimal VALOR_TAXA => 0.01m;

        public TaxaRepository() { }

        public decimal Obter()
        {
            // Esse valor deveria ser proveniente de uma base de dados  ex(Sql, Mysql, excel, txt, ...)
            return VALOR_TAXA;
        }
    }
}
