using GetPass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ex_LetsMarket
{
    public abstract class Login
    {
        public XmlSerializer serializer = new XmlSerializer(typeof(List<Funcionario>));

        public static Funcionario Enter(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                FileValidation.BdValidation(dbPath);
            }
            var funcionario = Funcionario.LoadFuncionario(dbPath);
            Funcionario funcionarioLogado = new Funcionario("A", "A", "A", "A");
            string nome = "";
            var senha = "";
            string entradaLogin = "";
            var entradaSenha = "";
            
            Console.WriteLine($"Número de funcionários Cadastrados: {funcionario.Count}");

            if (funcionario.Count < 1)
            {
               FirstLogin.AdmLogin(nome,senha);
            }
            else
            {
                bool atempt = false;
                do
                {
                    entradaLogin = LoginValidation.ValidateLogin(atempt, entradaLogin,entradaSenha, funcionario);

                    funcionarioLogado = PasswordValidation.ValidatePassword(atempt, entradaLogin,entradaSenha, funcionario);

                } while (!atempt);
                return funcionarioLogado;
            }
            return null;
        }
    }
}