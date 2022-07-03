using BetterConsoleTables;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Ex_LetsMarket
{

    public class Funcionario
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public static List<Funcionario> funcionario { get; set; } = new List<Funcionario>();
        public static int Count { get => funcionario.Count; }
        public static void ListarFuncionarios()
        {
            //var funcionario = new List<Funcionario>
            //{
            //    new Funcionario() { Nome = "Funcionario 1", Login = "func1" },
            //    new Funcionario() { Nome = "Funcionario 2", Login = "func2" },
            //    new Funcionario() { Nome = "Funcionario 3", Login = "func3" },
            //};

            Table table = new Table(TableConfiguration.UnicodeAlt());
            table.From<Funcionario>(funcionario);

            Console.Write(table.ToString());
        }
        public static void CadastrarFuncionarios(string dbPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Funcionario>));
            TextWriter write = new StreamWriter(dbPath);
            string nome = "";
            string cargo = "";
            string login = "";
            string senha = "";
            bool verif = false;
            int tamanho = 0;
            List<string> nomeC = new List<string>();

            Console.WriteLine("Dados do novo funcionário");


            if (funcionario.Count < 1)
            {
                Console.Clear();
                Console.WriteLine("Cadastro do primeiro acesso:\n");
            }
            do
            {
                Console.WriteLine("Insira o nome do usuário: ");
                nome = Console.ReadLine().ToUpper().Trim();
                nomeC = nome.Split(' ').ToList();

                if (nomeC.Count < 2)
                {
                    Console.WriteLine("Escreva nome e sobrenome.\n");
                }

            } while (nomeC.Count < 2);

            nomeC = nome.Split(' ').ToList();
            Console.Write("Cargo:");
            cargo = Console.ReadLine();
            do
            {
                Console.Write("Login:");
                login = Console.ReadLine();

                if(login.ToUpper().Contains(" ")){
                    Console.WriteLine("Insira um login sem utilizar espaços em branco.");
                }


            } while (login.ToUpper().Contains(" "));
            do
            {
                verif = true;
                Console.WriteLine("Insira a senha do usuário: ");
                senha = Console.ReadLine();
                tamanho = nomeC.Count;

                foreach (string s in nomeC)
                {

                    if (senha.ToUpper().Contains(s) || senha.ToUpper().Contains(" "))
                    {
                        verif = false;
                    }
                }
                if (verif == false)
                {
                    Console.WriteLine("\nSenha inválida. Não pode conter nome, sobrenome ou espaços em branco.\n");
                }
            } while (verif == false);

            Console.WriteLine($"\nFuncionário {nome}({login}) cadastrado com sucesso!");

            funcionario.Add(new Funcionario { Nome = nome, Cargo = cargo, Login = login, Senha = senha, });

            serializer.Serialize(write, funcionario);
            write.Close();
        }

        public static List<Funcionario> LoadFuncionario(string dbPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Funcionario>));
            TextReader reader = new StreamReader(dbPath);
            var objeto = serializer.Deserialize(reader);

            reader.Close();
            return (List<Funcionario>)objeto;
        }
    }


}