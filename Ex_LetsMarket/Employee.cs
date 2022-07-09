using BetterConsoleTables;
using Sharprompt;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Ex_LetsMarket
{

    public class Employee
    {
        private class NonManagerView
        {
            public string Name { get; set; }
            public string Post { get; set; }
            public string Login { get; set; }
        }
        public string Name { get; set; }
        public string Post { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        
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
            var employees = DataBase.GetAllEmployees();
            var loggedEmployee = GlobalConfiguration.GetCurrentLoggedEmployee();
            Table table = new Table(TableConfiguration.UnicodeAlt());
            if(loggedEmployee.Post == "Gerente")
            {
                table.From<Employee>(employees);
            }
            else
            {
                List<NonManagerView> nonManagerView = new List<NonManagerView>();
                foreach(var item in employees)
                {
                    nonManagerView.Add(new NonManagerView { Name = item.Name, Post = item.Post, Login = item.Login });
                   
                }
                table.From<NonManagerView>(nonManagerView);
            }

            Console.Write(table.ToString());
            //    }
            //    else
            //    {
            //        Console.WriteLine("Acesso negado.");
            //    }
        }
        public static void RegisterEmployee()
        {
            string name = "";
            var post = "";
            string login = "";
            string password = "";
            List<string> nameS = new List<string>();

            var employeesCount = DataBase.GetEmployeesCount();
            if (employeesCount < 1)
            {
                Console.WriteLine("Cadastro do primeiro acesso:\n");
            }

            Console.WriteLine("Dados do novo funcionário\n");

            var employee = DataBase.GetAllEmployees();

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