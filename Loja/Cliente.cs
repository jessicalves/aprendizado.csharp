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

        public void fazerCompra(int idPedido, string compraProdutos, string quantidade)
        {
            var novoPedido = new Pedido();

            var arr =compraProdutos.Split(',');
            var qttarr = quantidade.Split(',');

            Banco b = new Banco();

            for(int i = 0; i < arr.Length; i++)
            {
                b.sql = @"INSERT INTO public.pedido_x_produto (pepr_pedi_id,pepr_prod_id,pepr_quantidade_prod) VALUES (@prod_id,@prod,@qnt);";
                b.addParameters("prod_id", idPedido);
                b.addParameters("prod", Convert.ToInt32(arr[i]));
                b.addParameters("qnt", Convert.ToInt32(qttarr[i]));
                b.getDataTable();
            }


        }
    }
}
