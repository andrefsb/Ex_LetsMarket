using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ex_LetsMarket
{
    public class Login
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
            string senha = "";
            string entradalogin = "";
            string entradasenha = "";

            Console.WriteLine($"Número de funcionários Cadastrados: {funcionario.Count}");

            if (funcionario.Count < 1)
            {

                do
                {
                    Console.WriteLine("Primeira entrada:");
                    Console.Write("Login:");
                    nome = Console.ReadLine();
                    Console.Write("Senha:");
                    senha = Console.ReadLine();

                    if (nome.ToUpper() != "ADMIN" || senha.ToUpper() != "ADMIN")
                    {
                        Console.WriteLine("Login ou senha inválidos.\n");
                    }

                } while (nome.ToUpper() != "ADMIN" || senha.ToUpper() != "ADMIN");

                Funcionario.CadastrarFuncionarios();


            }
            else
            {
                bool atempt = false;
                do
                {
                    do {
                        Console.WriteLine("Insira seu Login: ");
                        entradalogin = Console.ReadLine();

                        foreach( var log in funcionario)
                        {
                            if(entradalogin == log.Login)
                            {
                                atempt = true;
                                break;
                            }
                            

                        }
                        if (atempt == false)
                        {
                            Console.WriteLine("\nLogin inexistente.\n");
                        }

                    } while (atempt == false);

                    do
                    {
                        Console.Write("Insira sua senha: ");
                        entradasenha =Console.ReadLine();
                        for(int i=0; i<funcionario.Count; i++)
                        {
                            if (funcionario[i].Senha.ToString() == entradasenha && funcionario[i].Login.ToString()==entradalogin)
                            {
                                atempt = true;
                                break;
                            }
                            else
                            {
                                atempt = false;
                            }
                           
                        }
                        if (atempt == false)
                        {
                            Console.WriteLine("\nSenha incorreta.\n");
                        }
                    } while (atempt == false);

                } while (atempt == false);

               
            }
        }

    }
}