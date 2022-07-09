using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_LetsMarket
{
    internal static class GlobalConfiguration
    {
        static Employee currentLoggedEmployee;

        public static Employee GetCurrentLoggedEmployee()
        {
           return currentLoggedEmployee ;
        }
        public static void SetCurrentLoggedEmployee(Employee loggedEmployee)
        {
            currentLoggedEmployee = loggedEmployee;
        }

    }
}
