using System.Threading.Tasks;
using Clients.Models.Order;

namespace Clients.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> GetOrder(string orderId);
        public Task<Order> CreateOrder(Order order);
    }
}