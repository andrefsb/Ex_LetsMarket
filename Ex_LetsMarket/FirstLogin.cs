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
        public static void AdmLogin(string nome, string senha)
        {
            do
            {
                int cont = 0;
                Console.WriteLine("Primeira entrada:");
                Console.Write("Login:");
                nome = Console.ReadLine();
                senha = ConsolePasswordReader.Read("Senha: ");

                if (nome.ToUpper() != "ADMIN" || senha.ToUpper() != "ADMIN")
                {
                    Console.WriteLine("Login ou senha inválidos.\n");
                    cont++;

                    if (cont > 2)
                    {
                        Console.WriteLine("Tentativas máximas de login alcançadas.");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine("Você tem mais " + (3 - cont) + " tentativas.\n");
                    }
                }
            } while (nome.ToUpper() != "ADMIN" || senha.ToUpper() != "ADMIN");
            Funcionario.CadastrarFuncionarios();
        }

    }
}
