using DataAccess.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> getOrder(string orderId);
        public Task<Order> createOrder(Order order);
    }
}
