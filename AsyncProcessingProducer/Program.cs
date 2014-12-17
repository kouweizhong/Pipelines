using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pipeline.PipelineObjects.Transmission;

namespace AsyncProcessingProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please provide input:");
            Console.WriteLine("1 - Produce process pipeline queue item.");
            Console.WriteLine("2 - Produce sync pipeline queue item");
            Console.WriteLine("3 - Exit");

            while(true)
            {
                var instructions = Console.ReadLine();

                switch(instructions)
                {
                    case "1":
                        Console.WriteLine("1 was called.");
                        break;
                    case "2":
                        Console.WriteLine("2 was called.");
                        for (int i = 0; i <= 4; i++ )
                        {
                            Process t = new Process();
                            t.Result = i.ToString();
                            t.PipelineObject = t.GetType();
                            t.PipelineObjectNamespaceName = t.GetType().FullName;
                            new Pipeline.RabbitMQ.Producer().EnqueuItem(t);
                        }                            
                        //var result = new TransmissionExamplePipeline().Process();
                        Console.WriteLine("Process result: " + "");
                        break;
                    case "3":
                        return;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
