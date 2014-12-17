using Pipeline.PipelineInfastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.Pipelines.Transmission
{
    public class SendTransmissioncs<T> : BaseExecutor<T>
    {
        protected override T _Execute(T input)
        {
            dynamic transmission = input as PipelineObjects.Transmission.Process;

            if (transmission != null)
            {
                transmission.Result += "Send transmission.";
                Console.WriteLine("Sending transmission");
            }
            return (T)transmission;
        }
    }
}
