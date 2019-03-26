using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    public class Cliente
    {
        public Cliente()
        {
            listPedidos = new List<Pedido>();
        }
        public List<Pedido> listPedidos;

        public string nomeCliente;
        public string cfpCliente;
        public int idCliente { get; set; }

        public void fazerCompra(string compraProdutos)
        {
            var novoPedido = new Pedido();

            novoPedido.adicionarProduto(compraProdutos);

            listPedidos.Add(novoPedido);

            novoPedido.idPedido = listPedidos[listPedidos.Count-1].idPedido+1;

        }
    }
}
