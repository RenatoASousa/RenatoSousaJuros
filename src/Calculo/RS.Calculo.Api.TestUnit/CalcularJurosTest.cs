using RS.Calculo.Api.Models;
using Xunit;

namespace RS.Calculo.Api.TestUnit
{
    public class CalcularJurosTest
    {
        [Trait("Categoria", "Calculo")]
        [Theory(DisplayName = "Calculo Valor Total")]
        [InlineData(5, 100, 0.01, 105.1)]
        [InlineData(10, 100, 0.01, 110.46)]
        [InlineData(20, 200, 0.01, 244.03)]
        public void Calculo_Validar_CalcularTotal(int meses, decimal valor, decimal taxa, decimal total)
        {
            //Arrange
            var calculo = new CalculaJuros(meses, valor, taxa);

            //Act
            var resultado = calculo.CalcularTotal();

            //Assert
            Assert.Equal(total, resultado);
        }

    }
}
