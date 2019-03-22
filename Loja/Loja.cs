using Npgsql;
using System;
using System.Collections.Generic;

namespace Loja
{
    class Loja
    {
        public static List<Cliente> listClientes = new List<Cliente>() { };

        public static void Listar()
        {
            Console.Clear();
            Console.WriteLine("-------- LISTA DE CLIENTES ----------");
            Console.WriteLine("|NOME\t\t" + "|CPF\t\t");
            Console.WriteLine("--------------------------------------");

            Banco banco = new Banco();
            banco.sql = ("SELECT clie_id, clie_nome, clie_cpf FROM public.cliente ORDER BY clie_id");
            NpgsqlDataReader ds = banco.ExecuteReader();

            while (ds.Read())
            {
                Console.WriteLine("|" + ds[1] + "\t" + "|" + ds[2] + "\t");
            }
            Console.ReadKey();
        }

        public static void Selecionar(string cpfSelecionado)
        {
            string cpfProcurado = cpfSelecionado;

            Banco banco = new Banco();
            banco.sql = @"SELECT clie_id, clie_nome, clie_cpf 
                                   FROM public.cliente     
                                   WHERE clie_cpf = @p";
            banco.addParameters("p", cpfProcurado);
            var dados = banco.ExecuteReader();

            dados.Read();
            var idCliente = dados[0];
            var nomeBanco = dados[1];
            var cpfBanco = dados[2];

            var clienteBanco = new Cliente();

            clienteBanco.nomeCliente = Convert.ToString(nomeBanco);
            clienteBanco.cfpCliente = Convert.ToString(cpfBanco);

            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~ INFORMAÇÕES DO CLIENTE ~~~~~~~~~~~~");
            Console.WriteLine("\nNOME DO CLIENTE: " + dados[1] + "\nCPF DO CLIENTE: " + dados[2]);

            Console.WriteLine("\n\n\n[3]EDITAR CLIENTE ");
            Console.WriteLine("[4]NOVO PEDIDO");
            Console.WriteLine("[5]LISTAR PEDIDOS");
            Console.WriteLine("[0]VOLTAR");

            int opcaoSelecionada;
            opcaoSelecionada = int.Parse(Console.ReadLine());

            switch (opcaoSelecionada)
            {
                case 3:
                    Console.Write("\nNOVO CPF: ");
                    clienteBanco.cfpCliente = Console.ReadLine();

                    Console.Write("NOVO NOME CLIENTE: ");
                    clienteBanco.nomeCliente = Console.ReadLine();

                    banco.sql = @"UPDATE public.cliente SET clie_nome = @nome , clie_cpf = @cpf WHERE clie_cpf = @p";
                    banco.addParameters("nome", clienteBanco.nomeCliente);
                    banco.addParameters("cpf", clienteBanco.cfpCliente);
                    banco.addParameters("p", cpfProcurado);

                    dados.Close();
                    dados = banco.ExecuteReader();

                    break;

                    //case 4:
                    //    Console.Clear();
                    //    Produto.listarProdutos();
                    //    Console.WriteLine("\n\nCODIGO DO PRODUTO:");
                    //    string produtos = Console.ReadLine();
                    //    clienteBanco.fazerCompra(produtos);

                    //    Console.WriteLine("\nPEDIDO FEITO COM SUCESSO");
                    //    Console.ReadKey();

                    //    break;

                    //case 5:
                    //    Console.Clear();
                    //    Console.WriteLine("~~~~~~~~~~~~ PEDIDOS DO CLIENTE ~~~~~~~~~~~~");
                    //    Console.WriteLine("\n\nCLIENTE: " + cliente.nomeCliente + "\nCPF: " + cliente.cfpCliente);

                    //    foreach (var pedido in cliente.listPedidos)
                    //    {
                    //        Console.WriteLine("\n\nPEDIDO: " + pedido.idPedido + "\n");

                    //        foreach (var produto in pedido.listaProdutosComprados)
                    //        {
                    //            Console.WriteLine("\t" + produto.nomeProduto);
                    //        }
                    //    }
                    //    Console.ReadKey();
                    //    break;
            }
        }

        public static void Cadastrar(Cliente cliente)
        {
            Banco banco = new Banco();
            banco.sql = @"INSERT INTO public.cliente (clie_nome,clie_cpf) VALUES (@nome,@cpf);";
            banco.addParameters("nome",cliente.nomeCliente);
            banco.addParameters("cpf", cliente.cfpCliente);
            var dados = banco.ExecuteReader();
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

