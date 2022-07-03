using BetterConsoleTables;
using System.Xml.Serialization;

namespace Ex_LetsMarket
{

    public class Funcionario
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public static List<Funcionario> funcionario { get; } = new List<Funcionario>();
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

            if (funcionario.Count < 1)
            {
                Console.Clear();
                Console.WriteLine("\nCadastro do primeiro acesso:\n");
            }

            Console.WriteLine("Dados do novo funcionário");
            Console.Write("Nome:");
            nome = Console.ReadLine();
            Console.Write("Cargo:");
            cargo = Console.ReadLine();
            Console.Write("Login:");
            login = Console.ReadLine();
            Console.Write("Senha:");
            senha = Console.ReadLine();

            Console.WriteLine($"Funcionário {nome} cadastrado com sucesso!");


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