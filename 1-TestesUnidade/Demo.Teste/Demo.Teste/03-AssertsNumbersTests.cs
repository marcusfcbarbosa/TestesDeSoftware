using Xunit;

namespace Demo.Teste
{
    public class AssertsNumbersTests
    {

        [Fact]
        public void Calculadora_Somar_DeveSerIgual()
        {
            //Arrange
            var calculadora = new Calculadora();
            //Act
            var result = calculadora.Somar(2,2);
            //Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void Calculadora_Somar_NaoDeveSerIgual()
        {
            //Arrange
            var calculadora = new Calculadora();
            //Act
            var result = calculadora.Somar(2.12121212, 2.542323232);
            //Assert
            Assert.NotEqual(4, result, precision:1);
        }
    }
}
