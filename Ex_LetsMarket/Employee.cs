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
        public Employee() { }

        public static void ListEmployees()

        {
            //if (Cargo.ToUpper() == "GERENTE")
            //{
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "funcionarios.xml");
            employee = DataBase.LoadDb(dbPath);

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
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "funcionarios.xml");//Receber como parâmetro
            var employee = DataBase.LoadDb(dbPath);
            string name = "";
            var post = "";
            string login = "";
            string password = "";
            List<string> nameS = new List<string>();

            if (employee.Count < 1)
            {
                Console.WriteLine("Cadastro do primeiro acesso:\n");
            }
            Console.WriteLine("Dados do novo funcionário\n");

            name = NameValidation.NewName(employee,nameS);
            nameS = name.Split(' ').ToList();

            post = PostValidation.NewPost(employee);

            login = LoginValidation.NewLogin(employee);

            password = PasswordValidation.NewPassword(nameS);

            Console.WriteLine($"\nFuncionário {name} ({login}) cadastrado com sucesso!");
            DataBase.SaveDb(name, post, login, password, employee);
            Console.ReadKey();
        }

    }


}