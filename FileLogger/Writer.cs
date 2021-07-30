using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisKata1
{
    class Writer : IWriter
    {
        public Writer()
        {
            
        }

        public void Write(string message, string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(message);
            }
        }
    }
}
