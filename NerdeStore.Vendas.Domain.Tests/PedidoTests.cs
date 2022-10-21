using NerdStore.Vendas.Domain;
using System;
using System.Linq;
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
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());//uma instancia usando factory
            var pedidoItem = new PedidoItem(Guid.NewGuid(), "Produto Teste", 2, 100);
            // Act
            pedido.AdicionarITem(pedidoItem);
            // Assert
            Assert.Equal(200, pedido.ValorTotal);
        }

        [Fact(DisplayName = "Mudar")]
        [Trait("Categoria", "Mudar")]
        public void AdicionarItemPedido_ItemExistente_DeveIncrementarUnidadesSomarValores()
        {
            // Arrange
            var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(Guid.NewGuid());//uma instancia usando factory
            var produtoId = Guid.NewGuid();
            var pedidoItem = new PedidoItem(produtoId, "Produto Teste", 2, 100);
            pedido.AdicionarITem(pedidoItem);
            var pedidoItem2 = new PedidoItem(produtoId, "Produto Teste", 1, 100);
            // Act
            pedido.AdicionarITem(pedidoItem2);

            // Assert
            Assert.Equal(expected: 300, actual: pedido.ValorTotal);
            Assert.Equal(1, pedido.PedidoItens.Count);//Naa pode ter dois pedidos com mesmo id na mesma lista
            Assert.Equal(3, pedido.PedidoItens.FirstOrDefault(p => p.ProdutoId == produtoId).Quantidade);
        }
    }
}
