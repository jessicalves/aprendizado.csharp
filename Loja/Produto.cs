using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    public class Produto
    {
        public static List<Produto> listProdutos = new List<Produto>(){};

        public string nomeProduto;
        public string codigoProduto;

        public static void listarProdutos()
        {
            Console.Clear();
            Console.WriteLine("-------- LISTA DE PRODUTOS -----------");
            Console.WriteLine("|NOME\t\t" + "|CODIGO\t\t");
            Console.WriteLine("--------------------------------------");

            Banco banco = new Banco();
            banco.sql = ("SELECT id_produto,nome_produto, cod_produto FROM public.produto ORDER BY id_produto");

            NpgsqlDataReader dados = banco.ExecuteReader();

            while (dados.Read())
            {
                Console.WriteLine("|" + dados[1] + "\t" + "|" + dados[2] + "\t");
            }
            Console.ReadKey();



            //foreach (var itemProduto in listProdutos)
            //{
            //    Console.WriteLine("|" + itemProduto.nomeProduto + "\t" + "|" + itemProduto.codigoProduto + "\t");
            //}
            //Console.ReadKey();
        }

        public static void cadastrarProduto(Produto produto)
        {

            //listProdutos.Add(produto);

        }

        public static void RremoverProduto(string codigoParaRemover)
        {
            string remover = codigoParaRemover;
            Produto removerProduto = listProdutos.Find(x => x.codigoProduto == remover);

            if (removerProduto == null)
            {
                Console.WriteLine("\n\n~~~~~ PRODUTO NÃO EXISTE ~~~~~~");
            }
            else
            {
                listProdutos.Remove(removerProduto);
                Console.WriteLine("\n\n~~~~~ PRODUTO REMOVIDO COM SUCESSO ~~~~~");
            }
        }

        public static void selecionarProduto(string codigoSelecionado)
        {
            string codigoProcurado = codigoSelecionado;

            foreach (var itemProduto in listProdutos)
            {
                if (codigoProcurado == itemProduto.codigoProduto)
                {
                    Console.Clear();
                    Console.WriteLine("~~~~~~~~~~~~ INFORMAÇÕES DO PRODUTO ~~~~~~~~~~~~");
                    Console.WriteLine("\nNOME DO PRODUTO: " + itemProduto.nomeProduto + "\nCODIGO DO PRODUTO: " + itemProduto.codigoProduto);

                    Console.WriteLine("\n\n\nDIGITE [3] SE DESEJA EDITAR PRODUTO");
                    Console.WriteLine("DIGITE [0] PARA VOLTAR");

                    int opcaoSelecionada;
                    opcaoSelecionada = Int32.Parse(Console.ReadLine());

                   if(opcaoSelecionada==3)
                    {
                        Console.Write("\nNOVO CODIGO DO PRODUTO: ");
                        itemProduto.codigoProduto = Console.ReadLine();
                    
                        Console.Write("NOVO NOME PRODUTO: ");
                        itemProduto.nomeProduto = Console.ReadLine();
                        
                    }                    
                }

            }
        }

        public static Produto buscarProduto(string codigoProduto)
        {
            return listProdutos.Find(x => x.codigoProduto == codigoProduto);
        }
    }
}
