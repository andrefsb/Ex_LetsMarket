using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharprompt;

namespace Ex_LetsMarket
{
    internal class PostValidation
    {
        public static string NewPost(List<Employee> employee)
        {
            string post = "";
            if (employee.Count < 1)
            {
                post = "Gerente";
                Console.WriteLine($"Cargo: {post}");
                Console.ReadKey();
            }
            else
            {
                post = Prompt.Select("Selecione seu cargo:", new[] { "Entregador", "Caixa", "Supervisor", "Gerente" });
                Console.WriteLine($"Cargo escolhido: {post}.");
            }
            return post;
        }
    }
}
