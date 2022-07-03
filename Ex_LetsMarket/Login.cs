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
        public string Name { get; set; }
        public string Password { get; set; }

        public XmlSerializer serializer = new XmlSerializer(typeof(List<Funcionario>));

        public Login(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public static void Enter(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                Funcionario.CadastrarFuncionarios(dbPath);

            }
            var funcionario = Funcionario.LoadFuncionario(dbPath);
            string nome = "";
            string senha = "";

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

                } while (nome.ToUpper() != "ADMIN" && senha.ToUpper() != "ADMIN");

                //Funcionario.CadastrarFuncionario(dbPath);


            }
            var content = File.ReadAllText(dbPath);

            //XmlSerializer serializer = new XmlSerializer(typeof(List<Funcionario>));
            TextWriter write = new StreamWriter(dbPath);

            bool atempt = false;
            do
            {


            } while (atempt == false);
        }

    }
}