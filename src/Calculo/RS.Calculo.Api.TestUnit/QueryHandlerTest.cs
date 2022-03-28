using Moq;
using RS.Calculo.Api.Application.Queries;
using RS.Calculo.Api.Data.Repository;
using System.Threading.Tasks;
using Xunit;

namespace RS.Calculo.Api.TestUnit
{
    public class QueryHandlerTest
    {
        [Fact(DisplayName = "Teste de Cálculo de Juros")]
        [Trait("Categoria", "QueryHandler")]
        public void Query_Calcular_Juros()
        {
            // Arrange
            var queryHandlerMock = new Mock<IQueryHandler<TaxaQuery, decimal>>();

            // Act
            queryHandlerMock.Setup(x => x.ExecuteAsync(It.IsAny<TaxaQuery>())).Returns(Task.FromResult(0.01m));
            var repo = new TaxaRepository(queryHandlerMock.Object);
            var result = repo.Obter(5, 100).Result;

            // Assert
            Assert.Equal(105.1m, result);
        }
    }
}
