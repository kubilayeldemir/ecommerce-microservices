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
            _client = client;
            _client.SetBaseAddress(Environment.GetEnvironmentVariable("ORDER_SERVICE"));
        }

        public async Task<Order> GetOrder(string orderId)
        {
            var endPoint = "order/" + orderId;
            return await _client.GetAsync<Order>(endPoint);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            //string endPoint = "order/"+
            var endPoint = "order";
            return await _client.PostAsync<Order>(endPoint, order);
        }
    }
}