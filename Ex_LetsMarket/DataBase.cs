using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ex_LetsMarket
    
{
    internal class DataBase
    {
        static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "funcionarios.xml");
        static List<Employee> employeeList;
        static DataBase()
        {
            if (!File.Exists(dbPath))
            {
                var funcionario0 = new List<Employee>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                TextWriter write0 = new StreamWriter(dbPath);

                serializer.Serialize(write0, funcionario0);

                write0.Close();
            }
            employeeList = LoadDb();

        }

        internal static int GetEmployeesCount()
        {
            return employeeList.Count ;
        }

        private static List<Employee> LoadDb()
        {
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
                TextReader reader = new StreamReader(dbPath);
                var objeto = serializer.Deserialize(reader);

                reader.Close();
                return (List<Employee>)objeto;
            }
        }

        public static void SaveDb(string name, string post, string login, string password, List<Employee> employee)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Employee>));
            TextWriter write = new StreamWriter(dbPath);
            employee.Add(new Employee(name, post, login, password));
            serializer.Serialize(write, employee);
            write.Close();
        }

        public static Employee GetEmployeeByLogin(string logginEntry)
        {
            foreach(var log in employeeList)
            {
                if(logginEntry == log.Login)
                return log;
            }
            return null;
        }
        public static List<Employee> GetAllEmployees()
        {
            return employeeList.AsReadOnly().ToList();
        }
    }

    


}
