using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class CosmoDbOrderSender : ICosmoDbOrderSender
    {
        private readonly string _fncUrl;

        public CosmoDbOrderSender(string url)
        {
            _fncUrl = url;
        }


        public async Task SendOrderDetailsToCosmoDB(Order order)
        {
            string json = JsonSerializer.Serialize(order);

            using (var client = new HttpClient())
            {
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var respone = await client.PostAsync(_fncUrl, data);
            }
        }
    }
}
