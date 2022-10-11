using Xunit;

namespace Features.Tests._02__Fixtures
{
    [Collection(nameof(ClienteCollection))]
    public class ClienteTesteInvalido
    {
        readonly ClienteTestsFixtures _fixture;
        public ClienteTesteInvalido(ClienteTestsFixtures fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Novo Cliente Inválido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            // Arrange
            var cliente = _fixture.GerarClienteInValido();

            // Act
            var result = cliente.EhValido();

            // Assert 
            Assert.False(result);
            Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);
        }
    }
}