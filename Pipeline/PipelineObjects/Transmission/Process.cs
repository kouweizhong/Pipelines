using RabbitMQ.Client;
using RabbitMQ.Client.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.PipelineObjects.Transmission
{
    public class Process : BasePipelineObject
    {
        public string Result { get; set; }

        public override Dictionary<string, string> Serialize()
        {
            var dictionary = base.Serialize();
            dictionary.Add("Result", Result);
            return dictionary;
        }

        public override void Deserialize(byte[] byteData, IBasicProperties props)
        {
            base.Deserialize(byteData, props);

            IMapMessageReader r = new MapMessageReader(props, byteData);
            var messageProperties = new Dictionary<string, string>();
            foreach (string key in r.Body.Keys)
            {
                messageProperties.Add(key, r.Body[key].ToString());
            }

            Result = messageProperties["Result"];
        }
    }
}
