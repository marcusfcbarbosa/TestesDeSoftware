using Features.Clientes;
using FluentAssertions;
using FluentAssertions.Extensions;
using MediatR;
using Moq;
using System.Threading;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(ClienteAutoMockerCollection))]
    public class ClienteServiceFluentAssertionTests
    {
        private readonly ClienteTestsAutoMockerFixture _clienteTestsAutoMockerFixture;
        private readonly ClienteService _clienteService;

        public ClienteServiceFluentAssertionTests(
                            ClienteTestsAutoMockerFixture clienteTestsAutoMockerFixture)
        {
            _clienteTestsAutoMockerFixture = clienteTestsAutoMockerFixture;
            _clienteService = _clienteTestsAutoMockerFixture.ObterClienteService();
        }
        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Service Fluent Assertion Tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var cliente = _clienteTestsAutoMockerFixture.GerarClienteValido();
            //Act
            _clienteService.Adicionar(cliente);//dentro desse metodo, se tudo ocorrer bem ele foi enviado um evento
            var result = cliente.EhValido();
            //Assert
            result.Should().BeTrue();                             //FluentAssertions  <======= isso subistitui o Assert  
            cliente.ValidationResult.Errors.Should().HaveCount(0);//FluentAssertions  <======= isso subistitui o Assert

            _clienteTestsAutoMockerFixture.Mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), times: Times.Once);
            _clienteTestsAutoMockerFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), times: Times.Once);
        }

        [Fact(DisplayName = "Adicionar Cliente com Falha")]
        [Trait("Categoria", "Cliente Service Fluent Assertion Tests")]
        public void ClienteService_Adicionar_DeveExecutarComFalhaDevidoClienteInvalido()
        {

            //Arrange
            var cliente = _clienteTestsAutoMockerFixture.GerarClienteInvalido();
            //Act
            _clienteService.Adicionar(cliente);

            //Assert
            var result = cliente.EhValido();
            result.Should().BeFalse("Possui Inconsistencias");//FluentAssertions  <======= isso subistitui o Assert
            cliente.ValidationResult.Errors.Should().HaveCountGreaterThanOrEqualTo(1);//FluentAssertions  <======= isso subistitui o Assert

            //verifico se os metodos foram chamados
            _clienteTestsAutoMockerFixture.Mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), times: Times.Never);
            _clienteTestsAutoMockerFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), times: Times.Never);
        }

        [Fact(DisplayName = "Obter Clientes Ativos")]
        [Trait("Categoria", "Cliente Service Fluent Assertion Tests")]
        public void ClienteService_Adicionar_DeveExecutarComFaha()
        {
            //Arrange
            _clienteTestsAutoMockerFixture.Mocker.GetMock<IClienteRepository>().Setup(c => c.ObterTodos())
                .Returns(_clienteTestsAutoMockerFixture.ObterClientesVariados());

            //Act
            var clientes = _clienteService.ObterTodosAtivos();
            //Assert
            _clienteTestsAutoMockerFixture.Mocker.GetMock<IClienteRepository>().Verify(r => r.ObterTodos(), Times.Once);
            clientes.Should().HaveCountGreaterThanOrEqualTo(1).And.OnlyHaveUniqueItems(); //tem que ser maior que 1 e nao ter itens repetidos
            clientes.Should().NotContain(c => !c.Ativo);//cliente nao podem ser inativos
            _clienteService.ExecutionTimeOf(c => c.ObterTodosAtivos())
                .Should()
                .BeLessThanOrEqualTo(maxDuration: 50.Milliseconds()
                , because: "é executado milhares de vezes por segundo");
        }
    }
}
