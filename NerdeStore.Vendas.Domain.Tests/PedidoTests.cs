using NerdStore.Vendas.Domain;
using System;
using Xunit;

namespace NerdeStore.Vendas.Domain.Tests
{
    public class PedidoTests
    {
        [Fact(DisplayName = "Adicionar Item Pedido Vazio")]
        [Trait("Categoria", "Pedido Tests")]
        public void AdicionarItemPedido_NovoPedido_DeveAtualizarValor()
        {
            // Arrange
            var pedido = new Pedido();
            var pedidoItem = new PedidoItem(Guid.NewGuid(),"Produto Teste",2,100);
            // Act
            pedido.AdicionarITem(pedidoItem);
            // Assert
            Assert.Equal(200, pedido.ValorTotal);
        }
    }
}
