using Features.Clientes;
using MediatR;
using Moq;
using System.Linq;
using System.Threading;
using Xunit;

//Install-Package Moq

namespace Features.Tests
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteServiceTests
    {
        readonly ClienteTestsBogusFixture _clienteTestsBogusFixture;
        public ClienteServiceTests(ClienteTestsBogusFixture clienteTestsBogusFixture)
        {
            _clienteTestsBogusFixture = clienteTestsBogusFixture;
        }

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var cliente = _clienteTestsBogusFixture.GerarClienteValido();
            var clienteRepo = new Mock<IClienteRepository>();
            var mediator = new Mock<IMediator>();
            var clienteService = new ClienteService(clienteRepo.Object, mediator.Object);
            //Act
            clienteService.Adicionar(cliente);//dentro desse metodo, se tudo ocorrer bem ele foi enviado um evento

            //Assert
            Assert.True(cliente.EhValido());//teste inutil

            clienteRepo.Verify(r => r.Adicionar(cliente), times: Times.Once);
            mediator.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), times: Times.Once);

        }

        [Fact(DisplayName = "Adicionar Cliente com Falha")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_Adicionar_DeveExecutarComFalhaDevidoClienteInvalido()
        {

            //Arrange
            var cliente = _clienteTestsBogusFixture.GerarClienteInvalido();
            var clienteRepo = new Mock<IClienteRepository>();
            var mediator = new Mock<IMediator>();
            var clienteService = new ClienteService(clienteRepo.Object, mediator.Object);
            //Act
            clienteService.Adicionar(cliente);

            //Assert
            Assert.False(cliente.EhValido());

            //verifico se os metodos foram chamados
            clienteRepo.Verify(r => r.Adicionar(cliente), times: Times.Never);
            mediator.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), times: Times.Never);
        }

        [Fact(DisplayName = "Obter Clientes Ativos")]
        [Trait("Categoria", "Cliente Service Mock Tests")]
        public void ClienteService_Adicionar_DeveExecutarComFaha()
        {
            //Arrange
            var clienteRepo = new Mock<IClienteRepository>();
            var mediator = new Mock<IMediator>();
            //dessa forma ele diz o que deve retornar,pelo Setup quando chamar esse metodo
            clienteRepo.Setup(c => c.ObterTodos()).Returns(_clienteTestsBogusFixture.ObterClientesVariados());
            var clienteService = new ClienteService(clienteRepo.Object, mediator.Object);
            //Act
            var clientes = clienteService.ObterTodosAtivos();
            //Assert
            clienteRepo.Verify(r => r.ObterTodos(), Times.Once);
            Assert.True(clientes.Any());
            Assert.False(clientes.Count(c => !c.Ativo) > 0);
        }


    }
}
