using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pipeline.PipelineObjects.Transmission;
using Pipeline.PipelineInfastructure;
using Pipeline.Pipelines.Transmission;

namespace AsyncProcessingProducer
{
    public class TransmissionExamplePipeline
    {
        public string Process()
        {
            var result = string.Empty;

            List<IExecutor<Process>> processes = new List<IExecutor<Process>>();
            processes.Add(new ArchiveTransmission<Process>());
            processes.Add(new ProcessTransmission<Process>());
            processes.Add(new SendTransmissioncs<Process>());

            Process transmission = new Process();
            Process pipelineResult = Pipeline<Process>.Execute(processes, transmission);

            if(pipelineResult != null && !string.IsNullOrWhiteSpace(pipelineResult.Result))
            {
                return pipelineResult.Result;
            }
            return result;
        }
    }
}
