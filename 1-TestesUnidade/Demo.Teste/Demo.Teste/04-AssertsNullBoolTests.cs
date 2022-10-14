using Xunit;

namespace Demo.Teste
{
    public class AssertsNullBoolTests
    {
        [Fact]
        public void Funcionario_Nome_NaoDeveSerNuloOuVazio()
        {
            //Arrange & Act
            var funcionario = new Funcionario("", salario: 1000);

            //Assert
            Assert.False(string.IsNullOrEmpty(funcionario.Nome));
        }

        [Fact]
        public void Funcionario_Nome_NaoDeveTerApelido()
        {
            //Arrange & Act
            var funcionario = new Funcionario("Marcus", salario: 1000);

            //Assert
            Assert.True(string.IsNullOrEmpty(funcionario.Apelido));

            //Assert Bool
            Assert.True(string.IsNullOrEmpty(funcionario.Apelido));
            Assert.False(funcionario.Apelido?.Length > 0);
        }




    }
}
