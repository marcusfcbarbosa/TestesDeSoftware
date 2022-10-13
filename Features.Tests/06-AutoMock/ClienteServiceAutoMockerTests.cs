using Features.Clientes;
using MediatR;
using Moq;
using Moq.AutoMock;
using System.Linq;
using System.Threading;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteServiceAutoMockerTests
    {
        readonly ClienteTestsBogusFixture _clienteTestsBogusFixture;

        public ClienteServiceAutoMockerTests(ClienteTestsBogusFixture clienteTestsBogusFixture)
        {
            _clienteTestsBogusFixture = clienteTestsBogusFixture;
        }

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Service AutoMock Tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var cliente = _clienteTestsBogusFixture.GerarClienteValido();
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>();//tem que ser uma instancia da classe concreta
            //Act
            clienteService.Adicionar(cliente);//dentro desse metodo, se tudo ocorrer bem ele foi enviado um evento
            //Assert
            Assert.True(cliente.EhValido());//teste inutil
            mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), times: Times.Once);
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), times: Times.Once);
        }

        [Fact(DisplayName = "Adicionar Cliente com Falha")]
        [Trait("Categoria", "Cliente Service AutoMock Tests")]
        public void ClienteService_Adicionar_DeveExecutarComFalhaDevidoClienteInvalido()
        {

            //Arrange
            var cliente = _clienteTestsBogusFixture.GerarClienteInvalido();
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>();//tem que ser uma instancia da classe concreta
            
            //Act
            clienteService.Adicionar(cliente);

            //Assert
            Assert.False(cliente.EhValido());

            //verifico se os metodos foram chamados
            mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), times: Times.Never);
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None), times: Times.Never);
        }

        [Fact(DisplayName = "Obter Clientes Ativos")]
        [Trait("Categoria", "Cliente Service AutoMock Tests")]
        public void ClienteService_Adicionar_DeveExecutarComFaha()
        {
            //Arrange
            //Usando o AutoMock, nao precisa ficar injetando todas as dependencias
            var mocker = new AutoMocker();
            var clienteService = mocker.CreateInstance<ClienteService>();
            //dessa forma ele diz o que deve retornar,pelo Setup quando chamar esse metodo
            mocker.GetMock<IClienteRepository>().Setup(c => c.ObterTodos()).Returns(_clienteTestsBogusFixture.ObterClientesVariados());
            
            //Act
            var clientes = clienteService.ObterTodosAtivos();
            
            //Assert
            mocker.GetMock<IClienteRepository>().Verify(r => r.ObterTodos(), Times.Once);
            Assert.True(clientes.Any());
            Assert.False(clientes.Count(c => !c.Ativo) > 0);
        }
    }
}