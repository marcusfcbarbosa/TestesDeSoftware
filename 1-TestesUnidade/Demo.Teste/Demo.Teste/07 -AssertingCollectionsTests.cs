using Xunit;

namespace Demo.Teste
{
    public class AssertingCollectionsTests
    {
        [Fact]
        public void Funcionario_Habilidades_NaoDevePossuirHabilidadesVazias()
        {
            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Marcus",10000);

            //Assert
            Assert.All(funcionario.Habilidades, habilidade => Assert.False(string.IsNullOrEmpty(habilidade)));
        }

        [Fact]
        public void Funcionario_Habilidades_JuniorDevePossuirHabilidadesBasica()
        {
            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Marcus", 10000);
            //Assert
            Assert.Contains(expected:"OOP", funcionario.Habilidades);
        }


        [Fact]
        public void Funcionario_Habilidades_JuniorNaoDevePossuirHabilidadesBasica()
        {
            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Marcus", 2000);
            //Assert
            Assert.DoesNotContain(expected: "Microservices", funcionario.Habilidades);
        }


        [Fact]
        public void Funcionario_Habilidades_SeniorDevePossuirTodasAsHabilidades()
        {
            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Marcus", 20000);
            //tem que estar na mesma ordem
            var habilidades = new [] { 
                "Lógica de Programação",
                "OOP",
                "Testes",
                "Microservices"
            };
            //Assert
            Assert.Equal(expected: habilidades, funcionario.Habilidades);
        }

    }
}
