using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pipeline.PipelineObjects;
using RabbitMQ.Client.Content;

namespace Pipeline.RabbitMQ
{
    public class Producer
    {
        IModel Model;

        public void EnqueuItem(IPipelineObject pipelineObject)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    Model = connection.CreateModel();
                    channel.QueueDeclare("hello", false, false, false, null);
                    IBasicProperties basicProperties = Model.CreateBasicProperties();


                    string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", "hello", basicProperties, ProduceObjectData(pipelineObject));
                    Console.WriteLine(" [x] Sent {0}", message);
                }
            }
        }

        protected byte[] ProduceObjectData(IPipelineObject item)
        {
            var keyValues = item.Serialize();

            IMapMessageBuilder b = new MapMessageBuilder(Model);
            foreach (KeyValuePair<string, string> keyValue in keyValues)
            {
                b.Body[keyValue.Key] = keyValue.Value;
            }
            return b.GetContentBody();
        }
    }
}
