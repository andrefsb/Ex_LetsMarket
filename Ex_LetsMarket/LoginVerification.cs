using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_LetsMarket
{
    internal class LoginVerification
    {
        public static string ValidateLogin(bool atempt, string logginEntry, List<Employee> employee)
        {
            do
            {
                Console.Write("Insira seu Login: ");
                logginEntry = Console.ReadLine();

                foreach (var log in employee)
                {
                    if (logginEntry == log.Login)
                    {
                        atempt = true;
                        break;
                    }
                }
                if (atempt == false)
                {
                    Console.WriteLine("\nLogin inexistente.\n");
                }

            } while (!atempt);
            return logginEntry;
        }
    }
}
