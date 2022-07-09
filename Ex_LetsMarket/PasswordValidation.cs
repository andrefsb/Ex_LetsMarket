using System;
using GetPass;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_LetsMarket
{
    internal class PasswordValidation
    {
        public static Funcionario ValidatePassword(bool atempt, string entradaSenha,string entradaLogin, List<Funcionario> funcionario)
        {
            var nomeUsuarioLogado = "";
            var loginUsuarioLogado = entradaLogin;
            var senhaUsuarioLogado = entradaSenha;
            var cargoUsuarioLogado = "";
            do
            {
                int cont = 0;
                entradaSenha = ConsolePasswordReader.Read("Senha: ");
                for (int i = 0; i < funcionario.Count; i++)
                {
                    if (funcionario[i].Senha.ToString() == entradaSenha && funcionario[i].Login.ToString() == entradaLogin)
                    {
                        atempt = true;
                        nomeUsuarioLogado = funcionario[i].Nome.ToString();
                        cargoUsuarioLogado = funcionario[i].Cargo.ToString();
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
            } while (!atempt);
            Funcionario funcionarioLogado = new Funcionario(nomeUsuarioLogado, cargoUsuarioLogado, entradaLogin, entradaSenha);
            return funcionarioLogado;
        }
    }
}
