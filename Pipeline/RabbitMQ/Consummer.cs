using Pipeline.PipelineObjects;
using RabbitMQ.Client;
using RabbitMQ.Client.Content;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.RabbitMQ
{
    public class Consummer
    {
        public void ConsumeItem()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {                    
                    channel.QueueDeclare("hello", false, false, false, null);

                    var queueConsummer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("hello", false, queueConsummer);

                    Console.WriteLine(" [*] Waiting for messages." +
                                             "To exit press CTRL+C");
                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)queueConsummer.Queue.Dequeue();
                        
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);
                        Console.WriteLine("Beginning Processing.");
                        try
                        {
                            var type = GetType(ea.Body, ea.BasicProperties);
                            Type classType = Assembly.GetExecutingAssembly().GetType(type);
                            var instance = Activator.CreateInstance(classType) as BasePipelineObject;

                            instance.PipelineObject = classType;
                            instance.PipelineObjectNamespaceName = type;
                            instance.Deserialize(ea.Body, ea.BasicProperties);
                            var processes = new PipelineInfastructure.ProcessFactory<IPipelineObject>().GetProcessors(instance);

                            Pipeline.PipelineInfastructure.Pipeline<IPipelineObject>.Execute(processes, instance);
                        }
                        catch(Exception e)
                        { }

                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                }
            }
        }

        protected string GetType(byte[] byteData, IBasicProperties props)
        {
            IMapMessageReader r = new MapMessageReader(props, byteData);
            var messageProperties = new Dictionary<string, string>();
            foreach (string key in r.Body.Keys)
            {
                messageProperties.Add(key, r.Body[key].ToString());
            }
            return messageProperties["Type"];
        }
    }
}
