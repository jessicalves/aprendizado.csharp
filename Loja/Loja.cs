using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    class Loja
    {
        public static List<Cliente> listClientes = new List<Cliente>() {
            new Cliente()
            {
                nomeCliente = "cliente1",
                cfpCliente = "123"



            },
            new Cliente()
            {
                nomeCliente = "cliente2",
                cfpCliente = "456"
            }
        };

        public static void Listar()
        {
            Console.Clear();
            Console.WriteLine("-------- LISTA DE CLIENTES ----------");
            //Console.WriteLine("--------------------------------------");

            //foreach (var item in listClientes)
            //{
            //    
            //}
            //Console.ReadKey();

            //Banco banco = new Banco();

            //var ds = banco.ExecutarSqlSet("SELECT * FROM public.cliente ORDER BY id_cliente");
            //Console.WriteLine("|NOME\t\t" + "|CPF\t\t");

            //while (ds.Read())
            //{
            //    Console.WriteLine("|" + ds[1] + "\t" + "|" + ds[2] + "\t");
            //}
            //Console.ReadKey();
        }

        public static void Selecionar(string cpfSelecionado)
        {
            string cpfProcurado = cpfSelecionado;

            Banco banco = new Banco();
            banco.sql = @"SELECT id_cliente, nome_cliente, cpf_cliente 
                                   FROM public.cliente     
                                   WHERE cpf_cliente = @p";
            banco.addParameters("p", cpfProcurado);
            var dados = banco.ExecuteReader();

            dados.Read();
            var id = dados[0];
            var nome = dados[1];
            var cpf = dados[2];

            //var clientebanco = new Cliente()
            //{
            //    cfpCliente = cpf,
            //    nomeCliente = nome
            //};

            //foreach (var cliente in listClientes)
            //{
            //    if (cpfProcurado == cliente.cfpCliente)
            //    {
            //Console.Clear();
            //Console.WriteLine("~~~~~~~~~~~~ INFORMAÇÕES DO CLIENTE ~~~~~~~~~~~~");
            //Console.WriteLine("\nNOME DO CLIENTE: " + dados[1] + "\nCPF DO CLIENTE: " + dados[2]);

            //Console.WriteLine("\n\n\n[3]EDITAR CLIENTE ");
            //Console.WriteLine("[4]NOVO PEDIDO");
            //Console.WriteLine("[5]LISTAR PEDIDOS");                  
            //Console.WriteLine("[0]VOLTAR");

            //int opcaoSelecionada;
            //opcaoSelecionada = Int32.Parse(Console.ReadLine());

            //switch (opcaoSelecionada)
            //        {
            //            case 3:
            //                Console.Write("\nNOVO CPF: ");
            //                cliente.cfpCliente = Console.ReadLine();


            //                Console.Write("NOVO NOME CLIENTE: ");
            //                cliente.nomeCliente = Console.ReadLine();
            //                break;

            //            case 4:
            //                Console.Clear();
            //                Produto.listarProdutos();
            //                Console.WriteLine("\n\nCODIGO DO PRODUTO:");
            //                string produtos = Console.ReadLine();               
            //                cliente.fazerCompra(produtos);

            //                Console.WriteLine("\nPEDIDO FEITO COM SUCESSO");
            //                Console.ReadKey();

            //                break;

            //            case 5:
            //                Console.Clear();
            //                Console.WriteLine("~~~~~~~~~~~~ PEDIDOS DO CLIENTE ~~~~~~~~~~~~");
            //                Console.WriteLine("\n\nCLIENTE: " + cliente.nomeCliente + "\nCPF: " + cliente.cfpCliente);

            //                foreach (var pedido in cliente.listPedidos)
            //                {
            //                    Console.WriteLine("\n\nPEDIDO: " + pedido.idPedido + "\n");

            //                    foreach (var produto in pedido.listaProdutosComprados)
            //                    {
            //                        Console.WriteLine("\t"+produto.nomeProduto);
            //                    }
            //                }
            //                Console.ReadKey();
            //                break;
            //        }

            //    }

            //}
        }

        public static void Cadastrar(Cliente cliente)
        {

            listClientes.Add(cliente);

        }

        public static void Remover(string clienteParaRemover)
        {
            string remover = clienteParaRemover;
            Cliente removerCliente = listClientes.Find(x => x.cfpCliente == remover);

            if (removerCliente == null)
            {
                Console.WriteLine("\n\n~~~~~ CLIENTE NÃO EXITE ~~~~~~");
            }
            else
            {
                listClientes.Remove(removerCliente);
                Console.WriteLine("\n\n~~~~~ CLIENTE REMOVIDO COM SUCESSO ~~~~~");
            }
        }

        //public static Cliente acharCliente(string cpfComprador)
        //{
        //    return listClientes.Find(x => x.cfpCliente == cpfComprador);
        //}
    }
}

