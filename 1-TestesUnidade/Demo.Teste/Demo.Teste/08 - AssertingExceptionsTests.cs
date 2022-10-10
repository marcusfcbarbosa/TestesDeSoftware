using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Teste
{
    public class AssertingExceptionsTests
    {

        [Fact]
        public void Calculadora_Dividir_DeveRetornarErroDivisaoPorZero() {
            //Arrange
            var calculadora = new Calculadora();
            //Act& Assert
            Assert.Throws<DivideByZeroException>(testCode: () => calculadora.Dividir(10, 0));
        }

        [Fact]
        public void Funcionario_Salario_DeveRetornarErroSalarioInferiorPermitido() {

            //Arrange & Act & Assert
            var exception = Assert.Throws<Exception>(testCode: () => FuncionarioFactory.Criar("Marcus", 200));
            Assert.Equal("Salario inferior ao permitido", exception.Message);
        }

    }
}
