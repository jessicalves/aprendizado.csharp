using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{

    public class Pedido
    {
        public Pedido()
        {
            listaProdutosComprados = new List<Produto>();
        }

        public List<Produto> listaProdutosComprados;

        public int idPedido;

        public void adicionarProduto(string produtos)
        {

            var arr = produtos.Split(',');

            foreach(var codigoProduto in arr)
            {
                var produto = Produto.buscarProduto(codigoProduto);
                listaProdutosComprados.Add(produto);
            }
        }
    }
}
