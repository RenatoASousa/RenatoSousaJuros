using System;

namespace RS.Calculo.Api.Models
{
    public class CalculaJuros
    {
        public CalculaJuros(int meses, decimal valor, decimal taxaJuros)
        {
            Meses = meses;
            Valor = valor;
            TaxaJuros = taxaJuros;
        }

        public int Meses { get; private set; }
        public decimal Valor { get; private set; }
        public decimal TaxaJuros { get; private set; }
        public decimal Total { get; private set; }

        public decimal CalcularTotal()
        {
            Total = Valor * CalculoExpoencial();
            Total = Math.Truncate(Total * 100) / 100;
            return Total;
        }

        internal decimal CalculoExpoencial()
        {
            return (decimal)Math.Pow((double)(1 + TaxaJuros), Meses);
        }

    }
}
