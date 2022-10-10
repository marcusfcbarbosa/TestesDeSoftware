using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Teste
{
    public class AssertStringsTests
    {

        [Fact]
        public void StringsTools_UnirNomes_RetornarNomeCompleto()
        {

            //Arrange
            var sut = new StringTools();
            //Act
            var nomeCompleto = sut.Unir("Marcus", "Fernando");
            //Assert
            Assert.Equal("Marcus Fernando", nomeCompleto);
        }

        [Fact]
        public void StringTools_DeveIgnorarCase()
        {
            //Arrange
            var sut = new StringTools();
            //Act
            var nomeCompleto = sut.Unir("Marcus", "Fernando");
            //Assert
            Assert.Equal("MARCUS FERNANDO", nomeCompleto, ignoreCase: true);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveConterTrecho()
        {
            //Arrange
            var sut = new StringTools();
            //Act
            var nomeCompleto = sut.Unir("Marcus", "Fernando");
            //Assert
            Assert.Contains("rnando", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveComecarCom()
        {
            //Arrange
            var sut = new StringTools();
            //Act
            var nomeCompleto = sut.Unir("Marcus", "Fernando");
            //Assert
            Assert.StartsWith("Marc", nomeCompleto);
        }

        [Fact]
        public void StringTools_UnirNomes_DeveAcabarCom()
        {
            //Arrange
            var sut = new StringTools();
            //Act
            var nomeCompleto = sut.Unir("Marcus", "Fernando");
            //Assert
            Assert.EndsWith("nando", nomeCompleto);
        }


        [Fact]
        public void StringTools_UnirNomes_ValidarExpressaoRegular()
        {
            //Arrange
            var sut = new StringTools();
            //Act
            var nomeCompleto = sut.Unir("Marcus", "Fernando");
            //Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", nomeCompleto);
        }


    }
}
