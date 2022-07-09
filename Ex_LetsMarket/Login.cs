﻿using GetPass;
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

        public static Employee Enter(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                FileValidation.BdValidation(dbPath);
            }
            var employee = Employee.LoadFuncionario(dbPath);
            Employee loggedEmployee = new Employee();
            string name = "";
            var password = "";
            string loginEntry = "";
            var passwordEntry = "";

            Console.WriteLine($"Número de funcionários Cadastrados: {employee.Count}");

            if (employee.Count < 1)
            {
                FirstLogin.AdmLogin(name, password);
            }
            else
            {
                bool atempt = false;

                loginEntry = LoginValidation.ValidateLogin(atempt, loginEntry, passwordEntry, employee);

                loggedEmployee = PasswordValidation.ValidatePassword(atempt, loginEntry, passwordEntry, employee);

                return loggedEmployee;
            }
            return null;
        }
    }
}