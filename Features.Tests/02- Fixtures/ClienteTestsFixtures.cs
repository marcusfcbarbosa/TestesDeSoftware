using Features.Clientes;
using System;
using Xunit;

namespace Features.Tests._02__Fixtures
{

    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteTestsFixtures> { 
    
    }
    public class ClienteTestsFixtures : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                "Marcus ",
                "Fernando ",
                DateTime.Now.AddYears(-30),
                "marcus@teste.com",
                true,
                DateTime.Now);

            return cliente;
        }
        public Cliente GerarClienteInValido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                "edu2edu.com",
                true,
                DateTime.Now);
            return cliente;
        }
        public void Dispose()
        {
        }
    }
}