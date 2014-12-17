using Pipeline.PipelineObjects;
using Pipeline.Pipelines.Transmission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pipeline.PipelineObjects.Transmission;

namespace Pipeline.PipelineInfastructure
{
    public class ProcessFactory<T>
    {
        public IEnumerable<IExecutor<T>> GetProcessors(BasePipelineObject pipelineObject)
        {
            var transmission = new Process();
            List<IExecutor<T>> processes = new List<IExecutor<T>>();

            if(transmission.GetType().FullName == pipelineObject.PipelineObject.FullName)
            {
                processes.Add(new InitialScan<T>());
                processes.Add(new ArchiveTransmission<T>());
                processes.Add(new ProcessTransmission<T>());
                processes.Add(new SendTransmissioncs<T>());
                processes.Add(new ReviewResult<T>());                
            }

            return processes;
        }
    }
}
