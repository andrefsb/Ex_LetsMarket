using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_LetsMarket
{
    internal class PasswordValidation
    {
        public static string NewPassword(List<string> nameS)
        {
            bool verify = true;
            string password = "";
            do
            {
                verify = true;
                Console.WriteLine("Insira a senha do usuário: ");
                password = Console.ReadLine();
                int size = nameS.Count;

                foreach (string s in nameS)
                {
                    if (password.ToUpper().Contains(s) || password.ToUpper().Contains(" ") || string.IsNullOrWhiteSpace(password))
                    {
                        verify = false;
                        Console.WriteLine("\nSenha inválida. Não pode conter nome, sobrenome ou espaços em branco.\n");
                    }
                }
            } while (verify == false);
            return password;
        }
    }
}
