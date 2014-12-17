using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pipeline.RabbitMQ;

namespace AsyncProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            var consummer = new Consummer();
            while(true)
            {
                consummer.ConsumeItem();
            }
        }
    }
}
