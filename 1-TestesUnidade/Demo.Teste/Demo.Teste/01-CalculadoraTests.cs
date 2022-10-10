using Xunit;

namespace Demo.Teste
{
    public class CalculadoraTests
    {
        [Fact]
        public void Calculadora_Somar_RetornarValorSoma()
        {
            //Arrange
            var calculadora = new Calculadora();

            //Act
            var resultado = calculadora.Somar(2, 2);

            //Assert
            Assert.Equal(4, resultado);
            Assert.True(resultado == 4);
        }


        [Theory]
        [InlineData(2,2,4)]
        [InlineData(2, 3, 5)]
        [InlineData(1, 1, 2)]
        [InlineData(3, 3, 6)]
        [InlineData(4, 4, 8)]
        public void Calculadora_Somar_RetornarValoresCorretos(double v1, double v2, double total)
        {
            //Arrange
            var calculadora = new Calculadora();

            //Act
            var resultado = calculadora.Somar(v1, v2);

            //Assert
            Assert.Equal(total, resultado);
            Assert.True(resultado == total);
        }
    }
}