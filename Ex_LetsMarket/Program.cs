using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;


namespace Ex_LetsMarket
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.Title = "Let's Store";
            Employee loggedEmployee = new Employee();

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "funcionarios.xml");

            loggedEmployee = Login.Enter(dbPath);

            var menu = new MenuItem("Menu Principal");

            var products = new MenuItem("Produtos");
            products.Add(new MenuItem("Cadastrar Produtos", Produtos.RegisterProduct));
            products.Add(new MenuItem("Listar Produtos", Produtos.ListProducts));

            var employees = new MenuItem("Funcionários");
            employees.Add(new MenuItem("Cadastrar Funcionários", Employee.RegisterEmployee));

            employees.Add(new MenuItem("Listar Funcionários", Employee.ListEmployees));

            var submenu = new MenuItem("Submenu");
            submenu.Add(new MenuItem("item do submenu"));

            menu.Add(products);
            menu.Add(employees);
            menu.Add(submenu);

            menu.Execute();
        }
    }
}