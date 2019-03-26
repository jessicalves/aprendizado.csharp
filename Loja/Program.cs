using System;

namespace Loja
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcaoDoInicio;
            int voltarTelaInicio = 1;
            
            while (voltarTelaInicio != 0)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~ INICÍO ~~~~~~~~~~~~~~~~~");
                Console.WriteLine("\n[ 1 ] Cliente");
                Console.WriteLine("[ 2 ] Produto");
                Console.WriteLine("[ 0 ] Sair");
                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Digite a opção: ");
                opcaoDoInicio = Int32.Parse(Console.ReadLine());

                //--------------- SAIR ------------
                if (opcaoDoInicio == 0)
                {
                    voltarTelaInicio = 0;
                }

                //--------------------------------- OPÇÃO CLIENTE -----------------------------------------------
                else if (opcaoDoInicio == 1)
                {
                    bool voltarTelaCliente = true;

                    while (voltarTelaCliente == true)
                    {
                        Console.Clear();
                        Console.WriteLine("~~~~~~~~~~~~~~~~ CLIENTES ~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("\n[ 1 ]Listar");
                        Console.WriteLine("[ 2 ]Selecionar");
                        Console.WriteLine("[ 3 ]Cadastrar");
                        Console.WriteLine("[ 4 ]Remover");
                        Console.WriteLine("[ 0 ]Voltar para tela inicial");
                        Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("Digite a opção: ");


                        int opcaoCliente;

                        opcaoCliente = Int32.Parse(Console.ReadLine());

                        if (opcaoCliente == 0)
                        {

                            voltarTelaInicio = 1;
                            voltarTelaCliente = false;
                            Console.Clear();
                        }
                        else if (opcaoCliente == 1)
                        {
                            Loja.Listar();
                        }
                        else if (opcaoCliente == 2)
                        {
                            string cpfSelecionado;

                            Console.Clear();
                            Console.WriteLine("~~~~~~~~~~~~~~~~ SELECIONAR CLIENTE ~~~~~~~~~~~~~~~~");
                            Console.WriteLine("\nINFORME O CPF DO CLIENTE QUE DESEJA SELECIONAR:");
                            cpfSelecionado = Console.ReadLine();

                            Loja.Selecionar(cpfSelecionado);
                        }
                        else if (opcaoCliente == 3)
                        {
                            bool cadastrarMais = true;
                            string nome;
                            string cpf;

                            while (cadastrarMais == true)
                            {
                                Console.Clear();
                                Console.WriteLine("~~~~~~~~~~~~~~~~ CADASTRO DE CLIENTE ~~~~~~~~~~~~~~~~~");
                                Console.WriteLine("\nNOME DO CLIENTE:");
                                nome = Console.ReadLine();
                                Console.WriteLine("\nCPF DO CLIENTE:");
                                cpf = Console.ReadLine();
                                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                                Cliente novoCliente = new Cliente();
                                novoCliente.nomeCliente = nome;
                                novoCliente.cfpCliente = cpf;

                                Loja.Cadastrar(novoCliente);

                                Console.WriteLine("\n\nDESEJA CADASTRAR MAIS CLIENTES? [s/n]");
                                var respostaCadastro = Console.ReadLine();
                                if (respostaCadastro == "s")
                                {
                                    cadastrarMais = true;
                                }
                                else
                                {
                                    voltarTelaCliente = true;
                                    cadastrarMais = false;
                                }
                            }
                        }
                        else if (opcaoCliente == 4)
                        {
                            string removerCliente;
                            bool removerMais = true;

                            while (removerMais == true)
                            {
                                Console.Clear();
                                Console.WriteLine("INFORME O CPF DO CLIENTE QUE DESEJA REMOVER:");
                                removerCliente = Console.ReadLine();
                                Loja.Remover(removerCliente);


                                Console.WriteLine("\n\nDESEJA REMOVER MAIS CLIENTES? [s/n]");
                                var respostaRemover = Console.ReadLine();

                                if (respostaRemover == "s")
                                {
                                    removerMais = true;
                                }
                                else
                                {
                                    removerMais = false;
                                    voltarTelaCliente = true;
                                }
                            }
                        }
                    }
                }

                //-----------------------------OPÇÃO PRODUTOS-----------------------------------
                else if (opcaoDoInicio == 2)
                {
                    bool voltarTelaProduto = true;

                    while (voltarTelaProduto)
                    {
                        Console.Clear();
                        Console.WriteLine("~~~~~~~~~~~~~~~~ PRODUTOS ~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("\n[ 1 ]Listar");
                        Console.WriteLine("[ 2 ]Selecionar");
                        Console.WriteLine("[ 3 ]Cadastrar");
                        Console.WriteLine("[ 4 ]Remover");
                        Console.WriteLine("[ 0 ]Voltar para tela inicial");
                        Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("\nDigite a opção: ");
                        int opcaoProduto = Convert.ToInt32(Console.ReadLine());

                        if (opcaoProduto == 0)
                        {
                            voltarTelaInicio = 1;
                            voltarTelaProduto = false;
                            Console.Clear();
                        }
                        else if (opcaoProduto == 1)
                        {
                            Produto.listarProdutos();
                        }
                        else if (opcaoProduto == 2)
                        {
                            string codigoSelecionado;

                            Console.Clear();
                            Console.WriteLine("~~~~~~~~~~~~~~~~ SELECIONAR PRODUTO ~~~~~~~~~~~~~~~~");
                            Console.WriteLine("\nINFORME O CODIGO DO PRODUTO QUE DESEJA SELECIONAR:");
                            codigoSelecionado = Console.ReadLine();

                            Produto.selecionarProduto(codigoSelecionado);
                        }
                        else if (opcaoProduto == 3)
                        {
                            bool cadastrarMaisProduto = true;
                            string nomeProd;
                            string codigoProd;
                            string valorProd;

                            while (cadastrarMaisProduto == true)
                            {
                                Console.Clear();
                                Console.WriteLine("~~~~~~~~~~~~~~~~ CADASTRO DE PRODUTO ~~~~~~~~~~~~~~~~~");
                                Console.WriteLine("\nNOME DO PRODUTO:");
                                nomeProd = Console.ReadLine();
                                Console.WriteLine("\nCODIGO DO PRODUTO:");
                                codigoProd = Console.ReadLine();
                                Console.WriteLine("\nVALOR DO PRODUTO:");
                                valorProd = Console.ReadLine();
                                Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                                Produto novoProduto = new Produto();
                                novoProduto.nomeProduto = nomeProd;
                                novoProduto.codigoProduto = codigoProd;
                                novoProduto.valorProduto = valorProd;

                                Produto.cadastrarProduto(novoProduto);

                                Console.WriteLine("\n\nDESEJA CADASTRAR MAIS PRODUTOS? [s/n]");
                                var respostaCadastro = Console.ReadLine();
                                if (respostaCadastro == "s")
                                {
                                    cadastrarMaisProduto = true;
                                }
                                else
                                {
                                    voltarTelaProduto = true;
                                    cadastrarMaisProduto = false;
                                }
                            }
                        }
                        else if (opcaoProduto == 4)
                        {
                            string removerProduto;
                            bool removerMaisProduto = true;

                            while (removerMaisProduto == true)
                            {
                                Console.Clear();
                                Console.WriteLine("INFORME O CODIGO DO PRODUTO QUE DESEJA SELECIONAR:");
                                removerProduto = Console.ReadLine();
                                Produto.RremoverProduto(removerProduto);

                                Console.WriteLine("\n\nDESEJA REMOVER MAIS PRODUTOS? [s/n]");
                                var respostaRemover = Console.ReadLine();

                                if (respostaRemover == "s")
                                {
                                    removerMaisProduto = true;
                                }
                                else
                                {
                                    removerMaisProduto = false;
                                    voltarTelaProduto = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }   
}

