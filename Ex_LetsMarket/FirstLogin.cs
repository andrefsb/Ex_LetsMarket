using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetPass;

namespace Ex_LetsMarket
{
    internal class FirstLogin
    {
        public static void AdmLogin(string name, string password)
        {
            do
            {
                int count = 0;
                Console.WriteLine("Primeira entrada:");
                Console.Write("Login:");
                name = Console.ReadLine();
                password = ConsolePasswordReader.Read("Senha: ");

                if (name.ToUpper() != "ADMIN" || password.ToUpper() != "ADMIN")
                {
                    Console.WriteLine("Login ou senha inválidos.\n");
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
            } while (name.ToUpper() != "ADMIN" || password.ToUpper() != "ADMIN");
            Employee.RegisterEmployee();
        }

    }
}
