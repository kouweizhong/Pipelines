using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.PipelineObjects
{
    public interface IPipelineObject
    {
        Dictionary<string, string> Serialize();
        void Deserialize(byte[] byteData, IBasicProperties props);
    }
}
