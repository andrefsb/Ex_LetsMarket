using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_LetsMarket
{
    internal class NameValidation
    {
        public static string NewName(List<Employee> employee, List<string> nameS)
        {
            string name = "";
            bool alreadyExists = false;
            do
            {
                Console.WriteLine("Insira o nome do usuário: ");
                name = Console.ReadLine().ToUpper().Trim();
                nameS = name.Split(' ').ToList();

                if (nameS.Count < 2)
                {
                    Console.WriteLine("Escreva nome e sobrenome.\n");
                }
                foreach (var n in employee)
                {
                    if (name == n.Name)
                    {
                        alreadyExists = true;
                        Console.WriteLine("\nNome já cadastrado no sistema.\n");
                        break;
                    }
                    else
                    {
                        alreadyExists = false;
                    }
                }
            } while (nameS.Count < 2 || alreadyExists);
            return name;
        }
    }
}
