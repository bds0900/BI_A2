using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace ReadWrite
{
    class Program
    {
        static void Main(string[] args)
        {

            QueueToDB haha = new QueueToDB();
            haha.Run();
            string line = Console.ReadLine();
        }
    }
}
