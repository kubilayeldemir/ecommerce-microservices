using System;
using System.Threading.Tasks;
using Clients.Interfaces;
using Clients.Models.Order;

namespace Clients.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IClient _client;
        public OrderRepository(IClient client)
        {
            this._client = client;
            this._client.SetBaseAddress(Environment.GetEnvironmentVariable("ORDER_SERVICE"));
        }
        public async Task<Order> getOrder(string orderId)
        {
            string endPoint = "order/" + orderId;
            return await _client.GetAsync<Order>(endPoint);
        }

        public async Task<Order> createOrder(Order order)
        {
            //string endPoint = "order/"+
            string endPoint = "order";
            return await _client.PostAsync<Order>(endPoint, order);
        }
    }
}
