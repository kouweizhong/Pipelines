using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pipeline.PipelineInfastructure;

namespace Pipeline.Pipelines.Transmission
{
    public class ArchiveTransmission<T> : BaseExecutor<T>
    {
        protected override T _Execute(T input)
        {
            dynamic transmission = input as PipelineObjects.Transmission.Process;

            if(transmission != null)
            {
                transmission.Result += "Archived transmission.";
                Console.WriteLine("Archiving Transmission.");
            }
            return (T)transmission;
        }
    }
}
