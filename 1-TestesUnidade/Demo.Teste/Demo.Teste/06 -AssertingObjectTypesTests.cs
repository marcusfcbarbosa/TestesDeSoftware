using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Teste
{
    public class AssertingObjectTypesTests
    {
        [Fact]
        public void FuncionarioFactory_Criar_DeveRetornarTipoFuncionario()
        {

            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Marcus", salario: 10000);
            //Assert
            Assert.IsType<Funcionario>(funcionario);
        }

        [Fact]
        public void FuncionarioFactory_Criar_DeveRetornarTipoVariadoPessoa()
        {

            //Arrange & Act
            var funcionario = FuncionarioFactory.Criar("Marcus", salario: 10000);
            //Assert
            Assert.IsAssignableFrom<Pessoa>(funcionario);// ve se ela herda de pessoa
        }
    }
}