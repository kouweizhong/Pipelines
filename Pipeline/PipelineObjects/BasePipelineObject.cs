using RabbitMQ.Client;
using RabbitMQ.Client.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.PipelineObjects
{
    public abstract class BasePipelineObject : IPipelineObject
    {
        public Type PipelineObject { get; set; }
        public string PipelineObjectNamespaceName { get; set; }
        //IModel Model;

        public BasePipelineObject()
        {
            //Model = Connection.CreateModel();
        }

        public virtual Dictionary<string, string> Serialize()
        {
            var keyValues = new Dictionary<string, string>();
            keyValues.Add("Type", PipelineObject.FullName);
            return keyValues;
        }

        public virtual void Deserialize(byte[] byteData, IBasicProperties props)
        {
            IMapMessageReader r = new MapMessageReader(props, byteData);
            var messageProperties = new Dictionary<string, string>();
            foreach (string key in r.Body.Keys)
            {
                messageProperties.Add(key, r.Body[key].ToString());
            }

            var namespaceType = messageProperties["Type"];
            PipelineObjectNamespaceName = namespaceType;
            PipelineObject = Type.GetType(namespaceType);
        }
    }
}
