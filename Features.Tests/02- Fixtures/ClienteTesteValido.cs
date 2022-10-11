using Features.Clientes;
using System;
using Xunit;

namespace Features.Tests._02__Fixtures
{
    [Collection(nameof(ClienteCollection))]
    public class ClienteTesteValido
    {
        readonly ClienteTestsFixtures _fixture;
        public ClienteTesteValido(ClienteTestsFixtures fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Novo Cliente Válido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            //Arrange
            var cliente = _fixture.GerarClienteValido();
            //Act
            var result = cliente.EhValido();

            //Assert
            Assert.True(result);
            Assert.Equal(expected: 0, actual: cliente.ValidationResult.Errors.Count);
        }
    }
}