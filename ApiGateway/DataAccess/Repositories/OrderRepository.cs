using DataAccess.Interfaces;
using DataAccess.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IClient _client;
        public OrderRepository(IClient client)
        {
            this._client = client;
            this._client.SetBaseAddress("http://localhost:8056/api/");
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
