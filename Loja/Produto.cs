using Npgsql;
using System;
using System.Collections.Generic;

namespace Loja
{
    public class Produto
    {
        public static List<Produto> listProdutos = new List<Produto>() { };

        public string nomeProduto;
        public string codigoProduto;
        public string valorProduto;

        public static void listarProdutos()
        {
            Console.Clear();
            Console.WriteLine("-------- LISTA DE PRODUTOS -----------");
            Console.WriteLine("|NOME\t\t" + "|CODIGO\t" + "|VALOR R$");
            Console.WriteLine("--------------------------------------");

            Banco banco = new Banco();
            banco.sql = ("SELECT prod_id,prod_nome, prod_codigo, prod_valor FROM public.produto ORDER BY prod_id");

            var ds = banco.getDataTable();

            for(int i =0; i<ds.Rows.Count;i++)
            {
                Console.WriteLine("|" + ds.Rows[i][1] + "\t" + "|" + ds.Rows[i][2] + "\t" + "|" + ds.Rows[i][3] + "\t");
            }
            Console.ReadKey();
        }

        public static void cadastrarProduto(Produto produto)
        {
            Banco banco = new Banco();
            banco.sql = @"INSERT INTO public.produto (prod_nome,prod_codigo,prod_valor) VALUES (@nome,@codigo,@valor)";
            banco.addParameters("nome", produto.nomeProduto);
            banco.addParameters("codigo", produto.codigoProduto);
            banco.addParameters("valor", produto.valorProduto);

            banco.getDataTable();
        }

        public static void RremoverProduto(string codigoParaRemover)
        {
            string remover = codigoParaRemover;
            //Produto removerProduto = listProdutos.Find(x => x.codigoProduto == remover);
            Banco banco = new Banco();
            banco.sql = @"DELETE FROM public.produto WHERE prod_codigo = @cod";
            banco.addParameters("cod", remover);
            banco.getDataTable();

            if (remover == null)
            {
                Console.WriteLine("\n\n~~~~~ PRODUTO NÃO EXISTE ~~~~~~");
            }
            else
            {
                Console.WriteLine("\n\n~~~~~ PRODUTO REMOVIDO COM SUCESSO ~~~~~");
            }
        }

        public static void selecionarProduto(string codigoSelecionado)
        {
            string codigoProcurado = codigoSelecionado;

            Banco banco = new Banco();
            banco.sql = @"SELECT prod_id, prod_nome, prod_codigo,prod_valor 
                                   FROM public.produto     
                                   WHERE prod_codigo = @p";
            banco.addParameters("p", codigoProcurado);
            var dados = banco.getDataTable();
            
            var idProduto = dados.Rows[0][0];
            var nomeBanco = dados.Rows[0][1];
            var codigoBanco = dados.Rows[0][2];
            var valorBanco = dados.Rows[0][3];

            var produtoBanco = new Produto();

            produtoBanco.nomeProduto = Convert.ToString(nomeBanco);
            produtoBanco.codigoProduto = Convert.ToString(codigoBanco);
            produtoBanco.valorProduto = Convert.ToString(valorBanco);

            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~ INFORMAÇÕES DO PRODUTO ~~~~~~~~~~~~");
            Console.WriteLine("\nNOME DO PRODUTO: " + dados.Rows[0][1] + "\nCODIGO DO PRODUTO: " + dados.Rows[0][2]);

            Console.WriteLine("\n\n\nDIGITE [3] SE DESEJA EDITAR PRODUTO");
            Console.WriteLine("DIGITE [0] PARA VOLTAR");

            int opcaoSelecionada;
            opcaoSelecionada = int.Parse(Console.ReadLine());

            if (opcaoSelecionada == 3)
            {
                Console.Write("\nNOVO CODIGO DO PRODUTO: ");
                produtoBanco.codigoProduto = Console.ReadLine();

                Console.Write("NOVO NOME PRODUTO: ");
                produtoBanco.nomeProduto = Console.ReadLine();

                Console.Write("NOVO VALOR DO PRODUTO: ");
                produtoBanco.valorProduto = Console.ReadLine();

                banco.sql = @"UPDATE public.produto SET prod_nome = @nome , prod_codigo = @codigo, prod_valor = @valor
                            WHERE prod_codigo = @p";

                banco.addParameters("nome", produtoBanco.nomeProduto);
                banco.addParameters("codigo", produtoBanco.codigoProduto);
                banco.addParameters("valor", produtoBanco.valorProduto);
                banco.addParameters("p", codigoProcurado);

                banco.getDataTable();
            }
        }

        public static Produto buscarProduto(string codigoProduto)
        {
            return listProdutos.Find(x => x.codigoProduto == codigoProduto);
        }
    }
}
