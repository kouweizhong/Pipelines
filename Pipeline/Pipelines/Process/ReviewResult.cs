using Pipeline.PipelineInfastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.Pipelines.Transmission
{
    public class ReviewResult<T> : BaseExecutor<T>
    {
        protected override T _Execute(T input)
        {
            dynamic transmission = input as PipelineObjects.Transmission.Process;

            if (transmission != null)
            {
                transmission.Result += "Review transmission.";
                Console.WriteLine("Reviewing transmission: " + transmission.Result);
            }
            return (T)transmission;
        }
    }
}
