using System;
using GetPass;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_LetsMarket
{
    internal class PasswordVerification
    {
        public static Employee ValidatePassword(bool atempt, string loginEntry,string passwordEntry, List<Employee> employee)
        {
            var loggedUserName = "";
            var loggedUserLogin = "";
            var loggedUserPassword = "";
            var loggedUserPost = "";
            int count = 0;
            do
            {
                passwordEntry = ConsolePasswordReader.Read("Senha: ");
                for (int i = 0; i < employee.Count; i++)
                {
                    if (employee[i].Password.ToString() == passwordEntry && employee[i].Login.ToString() == loginEntry)
                    {
                        atempt = true;
                        loggedUserName = employee[i].Name.ToString();
                        loggedUserPost = employee[i].Post.ToString();
                        loggedUserLogin = loginEntry;
                        loggedUserPassword = passwordEntry;
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
                    count++;

                    if (count > 2)
                    {
                        Console.WriteLine("Tentativas máximas de login alcançadas.");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine("Você tem mais " + (3 - count) + " tentativas.\n");
                    }
                }
            } while (!atempt);
            Employee loggedUser = new Employee(loggedUserName, loggedUserPost, loggedUserLogin, loggedUserPassword);
            return loggedUser;
        }
    }
}
