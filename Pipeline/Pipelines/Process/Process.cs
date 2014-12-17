using Pipeline.PipelineInfastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.Pipelines.Transmission
{
    public class ProcessTransmission<T> : BaseExecutor<T>
    {
        protected override T _Execute(T input)
        {
            dynamic transmission = input as PipelineObjects.Transmission.Process;

            if (transmission != null)
            {
                transmission.Result += "Process transmission.";
                Console.WriteLine("Processing transmission.");
            }
            return (T)transmission;
        }
    }
}
