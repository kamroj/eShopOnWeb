using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class ServiceBusHandler : IServiceBus
    {
        private IQueueClient queueClient;

        public ServiceBusHandler(string cs, string queueName)
        {
            queueClient = new QueueClient(cs, queueName);
        }

        public async Task SendAsync(string msg)
        {
            var message = new Message(Encoding.UTF8.GetBytes(msg));
            await queueClient.SendAsync(message);
        }
    }
}
