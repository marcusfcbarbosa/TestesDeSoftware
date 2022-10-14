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
            //Usando Bogus
            //var genero = new Faker().PickRandom<Name.Gender>();
            //var cliente = new Faker<Cliente>(locale: "pt_BR")
            //    .CustomInstantiator(f => new Cliente(
            //        Guid.NewGuid(),
            //        nome: f.Name.FirstName(genero),
            //        sobrenome: f.Name.LastName(genero),
            //        dataNascimento: f.Date.Past(yearsToGoBack: 80, DateTime.Now.AddYears(-30)),
            //        email: "",
            //        ativo: true,
            //        dataCadastro: DateTime.Now
            //        )).RuleFor(property: c => c.Email,
            //        setter: (f, c) => f.Internet.Email(
            //                firstName: c.Nome.ToLower(), 
            //                lastName: c.Sobrenome.ToLower()));

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