using GetPass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ex_LetsMarket
{
    public abstract class Login
    {
        public XmlSerializer serializer = new XmlSerializer(typeof(List<Funcionario>));

        public static void Enter(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                var funcionario0 = new List<Funcionario>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Funcionario>));
                TextWriter write0 = new StreamWriter(dbPath);

                serializer.Serialize(write0, funcionario0);

                write0.Close();

            }
            var funcionario = Funcionario.LoadFuncionario(dbPath);
            string nome = "";
            var senha = "";
            string entradaLogin = "";
            var entradaSenha = "";
            int cont = 0;
            var nomeUsuarioLogado = "";
            var loginUsuarioLogado = "";
            var senhaUsuarioLogado = "";
            var cargoUsuarioLogado = "";

            Console.WriteLine($"Número de funcionários Cadastrados: {funcionario.Count}");

            if (funcionario.Count < 1)
            {

                do
                {
                    Console.WriteLine("Primeira entrada:");
                    Console.Write("Login:");
                    nome = Console.ReadLine();
                    senha = ConsolePasswordReader.Read("Senha: ");

                    if (nome.ToUpper() != "ADMIN" || senha.ToUpper() != "ADMIN")
                    {
                        Console.WriteLine("Login ou senha inválidos.\n");
                        cont++;

                        if (cont > 2)
                        {
                            Console.WriteLine("Tentativas máximas de login alcançadas.");
                            Console.ReadKey();
                            Environment.Exit(1);

                        }
                        else
                        {
                            Console.WriteLine("Você tem mais " + (3 - cont) + " tentativas.\n");
                        }
                    }

                } while (nome.ToUpper() != "ADMIN" || senha.ToUpper() != "ADMIN");
                
                Funcionario.CadastrarFuncionarios();

            }
            else
            {
                bool atempt = false;
                cont = 0;
                do
                {
                    do
                    {
                        
                        Console.WriteLine("Insira seu Login: ");
                        entradaLogin = Console.ReadLine();

                        foreach (var log in funcionario)
                        {
                            if (entradaLogin == log.Login)
                            {
                                atempt = true;
                                break;
                            }
                        }
                        if (atempt == false)
                        {
                            Console.WriteLine("\nLogin inexistente.\n");
                        }

                    } while (!atempt);

                    do
                    {
                        entradaSenha = ConsolePasswordReader.Read("Senha: ");
                        for (int i = 0; i < funcionario.Count; i++)
                        {
                            if (funcionario[i].Senha.ToString() == entradaSenha && funcionario[i].Login.ToString() == entradaLogin)
                            {
                                atempt = true;
                                nomeUsuarioLogado = funcionario[i].Nome.ToString();
                                cargoUsuarioLogado= funcionario[i].Cargo.ToString();
                                break;
                            }
                            else
                            {
                                atempt = false;
                            }

                        }
                        if (!atempt)
                        {
                            Console.WriteLine("\nSenha incorreta.\n");
                            cont++;
                            
                            if (cont > 2)
                            {
                                Console.WriteLine("Tentativas máximas de login alcançadas.");
                                Console.ReadKey();
                                Environment.Exit(1);
                            }
                            else
                            {
                                Console.WriteLine("Você tem mais " + (3 - cont) + " tentativas.\n");
                            }
                        }
                    } while (!atempt);

                } while (!atempt);
                //Funcionario funcionarioLogado = new Funcionario(nomeUsuarioLogado, cargoUsuarioLogado, entradaLogin, entradaSenha);
            }
        }

    }
}