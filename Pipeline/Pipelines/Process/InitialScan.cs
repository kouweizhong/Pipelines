using Pipeline.PipelineInfastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.Pipelines.Transmission
{
    public class InitialScan<T> : BaseExecutor<T>
    {
        protected override T _Execute(T input)
        {
            dynamic transmission = input as PipelineObjects.Transmission.Process;

            if (transmission != null)
            {
                //transmission.Result += "Review transmission.";
                Console.WriteLine("Transmission result: " + transmission.Result);
            }
            return (T)transmission;
        }
    }
}
