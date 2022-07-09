using GetPass;
using Sharprompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ex_LetsMarket
{
    public class Login
    {
        public XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));

        public static void Enter()
        {

            var employeesCount = DataBase.GetEmployeesCount();
            Employee loggedEmployee = new Employee();
            string name = "";
            var password = "";
            string loginEntry = "";
            var passwordEntry = "";

            Console.WriteLine($"Número de funcionários Cadastrados: {employeesCount}");

            if (employeesCount < 1)
            {
                FirstLogin.AdmLogin(name, password);
            }
            else
            {
                bool atempt = false;

                loginEntry = LoginVerification.ValidateLogin(loginEntry);

                passwordEntry = Prompt.Password("Insira a senha: ");

                PasswordVerification.ValidatePassword(loginEntry, passwordEntry);

            }
        }
    }
}