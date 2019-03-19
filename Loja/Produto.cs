using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    public class Produto
    {
        public static List<Produto> listProdutos = new List<Produto>()
        {
            new Produto
            {
                nomeProduto = "produto1",
                codigoProduto = "963"
            },
            new Produto
            {
                nomeProduto = "produto2",
                codigoProduto = "741"
            },
            new Produto
            {
                nomeProduto = "produto3",
                codigoProduto = "987"
            }
        };

        public string nomeProduto;
        public string codigoProduto;

        public static void listarProdutos()
        {
            Console.Clear();
            Console.WriteLine("-------- LISTA DE PRODUTOS -----------");
            Console.WriteLine("|NOME\t\t" + "|CODIGO\t\t");
            Console.WriteLine("--------------------------------------");

            foreach (var itemProduto in listProdutos)
            {
                Console.WriteLine("|" + itemProduto.nomeProduto + "\t" + "|" + itemProduto.codigoProduto + "\t");
            }
            Console.ReadKey();
        }

        public static void cadastrarProduto(Produto produto)
        {

            listProdutos.Add(produto);

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
