using BetterConsoleTables;
using Sharprompt;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Ex_LetsMarket
{

    public class Employee
    {

        public string Name { get; set; }
        public string Post { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public static List<Employee> employee { get; set; } = new List<Employee>();
        public static int Count { get => employee.Count; }
        public Employee(string name, string post, string login, string password)
        {
            Name = name;
            Post = post;
            Login = login;
            Password = password;
        }
        public Employee(){}

        public static void ListEmployees()

        {
            //if (Cargo.ToUpper() == "GERENTE")
            //{
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "funcionarios.xml");
                employee = Employee.LoadFuncionario(dbPath);

                Table table = new Table(TableConfiguration.UnicodeAlt());
                table.From<Employee>(employee);

                Console.Write(table.ToString());
        //    }
        //    else
        //    {
        //        Console.WriteLine("Acesso negado.");
        //    }
        }
        public static void RegisterEmployee()
        {
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "funcionarios.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            TextWriter write = new StreamWriter(dbPath);

            string name = "";
            var post = "";
            string login = "";
            string password = "";
            bool verify = false;
            bool alreadyExists = false;
            int size = 0;
            List<string> nameS = new List<string>();

            if (employee.Count < 1)
            {
                Console.WriteLine("Cadastro do primeiro acesso:\n");
            }
            Console.WriteLine("Dados do novo funcionário\n");
            do
            {
                Console.WriteLine("Insira o nome do usuário: ");
                name = Console.ReadLine().ToUpper().Trim();
                nameS = name.Split(' ').ToList();

                if (nameS.Count < 2)
                {
                    Console.WriteLine("Escreva nome e sobrenome.\n");
                }
                foreach (var n in employee)
                {
                    if (name == n.Name)
                    {
                        alreadyExists = true;
                        Console.WriteLine("\nNome já cadastrado no sistema.\n");
                        break;
                    }
                    else
                    {
                        alreadyExists = false;
                    }
                }
            } while (nameS.Count < 2 || alreadyExists);

            nameS = name.Split(' ').ToList();

            if (employee.Count < 1)
            {
                post = "Gerente";
                Console.Write($"Cargo: {post}");
            }
            else
            {
                post = Prompt.Select("Selecione seu cargo:", new[] { "Entregador", "Caixa", "Supervisor" , "Gerente"});
                Console.WriteLine($"Cargo escolhido: {post}.");
            }
            do
            {
                Console.Write("Login:");
                login = Console.ReadLine();

                if (login.ToUpper().Contains(" "))
                {
                    Console.WriteLine("Insira um login sem utilizar espaços em branco.");
                }
                foreach (var log in employee)
                {
                    if (login == log.Login)
                    {
                        alreadyExists = true;
                        Console.WriteLine("\nLogin já cadastrado no sistema.\n");
                        break;
                    }
                    else
                    {
                        alreadyExists = false;
                    }
                }
                
            } while (login.ToUpper().Contains(" ") || alreadyExists);
            Console.WriteLine($"Login escolhido: {login}.\n");
            do
            {
                verify = true;
                Console.WriteLine("Insira a senha do usuário: ");
                password = Console.ReadLine();
                size = nameS.Count;

                foreach (string s in nameS)
                {

                    if (password.ToUpper().Contains(s) || password.ToUpper().Contains(" "))
                    {
                        verify = false;
                    }
                }
                if (verify == false)
                {
                    Console.WriteLine("\nSenha inválida. Não pode conter nome, sobrenome ou espaços em branco.\n");
                }
            } while (verify == false);

            Console.WriteLine($"\nFuncionário {name} ({login}) cadastrado com sucesso!");

            employee.Add(new Employee( name, post, login, password ));

            serializer.Serialize(write, employee);
            write.Close();
        }
        public static List<Employee> LoadFuncionario(string dbPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            TextReader reader = new StreamReader(dbPath);
            var objeto = serializer.Deserialize(reader);

            reader.Close();
            return (List<Employee>)objeto;
        }
    }


}