using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_LetsMarket
{
    internal class LoginValidation
    {
        public static string ValidateLogin(bool atempt, string entradaLogin,string entradaSenha, List<Employee> funcionario)
        {
            do
            {
                Console.Write("Insira seu Login: ");
                entradaLogin = Console.ReadLine();

                foreach (var log in funcionario)
                {
                    if (entradaLogin == log.Login)
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
            return entradaLogin;
        }
    }
}
