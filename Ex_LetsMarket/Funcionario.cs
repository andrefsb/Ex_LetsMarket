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
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "funcionarios.xml");
            Funcionario.LoadFuncionario(dbPath);

            Table table = new Table(TableConfiguration.UnicodeAlt());
            table.From<Funcionario>(funcionario);

            Console.Write(table.ToString());
        }
        public static void CadastrarFuncionarios()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "funcionarios.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Funcionario>));
            TextWriter write = new StreamWriter(dbPath);
            string nome = "";
            string cargo = "";
            string login = "";
            string senha = "";
            bool verif = false;
            bool jaexiste = true;
            int tamanho = 0;
            List<string> nomeC = new List<string>();

            Funcionario.LoadFuncionario(dbPath);

            if (funcionario.Count < 1)
            {
                Console.WriteLine("Cadastro do primeiro acesso:\n");
            }
            do
            {
                Console.WriteLine("Dados do novo funcionário\n");
                Console.WriteLine("Insira o nome do usuário: ");
                nome = Console.ReadLine().ToUpper().Trim();
                nomeC = nome.Split(' ').ToList();

                if (nomeC.Count < 2)
                {
                    Console.WriteLine("Escreva nome e sobrenome.\n");
                }
                foreach (var nom in funcionario)
                {
                    if (nome == nom.Nome)
                    {
                        jaexiste = true;
                        Console.WriteLine("\nNome já cadastrado no sistema.\n");
                        
                    }
                    else
                    {
                        jaexiste = false;
                    }

                }

            } while (nomeC.Count < 2 || jaexiste);

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
                foreach (var log in funcionario)
                {
                    if (login == log.Login)
                    {
                        jaexiste = true;
                        Console.WriteLine("\nLogin já cadastrado no sistema.\n");

                    }
                    else
                    {
                        jaexiste = false;
                    }

                }

            } while (login.ToUpper().Contains(" ") || jaexiste);
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