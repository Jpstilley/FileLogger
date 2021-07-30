using System;

namespace ArdalisKata1
{
    class Program
    {
        static void Main(string[] args)
        {
            Writer writer = new Writer();
            string message = "Joey";
            Logger log = new Logger(writer);
            log.Log(message);
        }
    }
}
