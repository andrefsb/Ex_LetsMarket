using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ex_LetsMarket
    
{
    internal class FileValidation
    {
        public static void BdValidation(string dbPath)
        {
            var funcionario0 = new List<Funcionario>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Funcionario>));
            TextWriter write0 = new StreamWriter(dbPath);

            serializer.Serialize(write0, funcionario0);

            write0.Close();

        }
    }

    


}
