using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_LetsMarket
{
    internal class LoginVerification
    {
        public static string ValidateLogin(string logginEntry)
        {
            Employee atempt = null;
            do
            {
                Console.Write("Insira seu Login: ");
                logginEntry = Console.ReadLine();

                
                atempt = DataBase.GetEmployeeByLogin(logginEntry);
                GlobalConfiguration.SetCurrentLoggedEmployee(atempt);
                if (atempt == null)
                {
                    Console.WriteLine("\nLogin inexistente.\n");
                }

            } while (atempt==null);
            return logginEntry;
        }
    }
}
