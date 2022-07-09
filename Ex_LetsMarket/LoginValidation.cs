using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_LetsMarket
{
    internal class LoginValidation
    {
        public static string NewLogin(List<Employee> employee)
        {
            string login = "";
            bool alreadyExists = false;
            do
            {
                Console.Write("Login: ");
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
            return login;
        }
    }
}
