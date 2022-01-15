using System.Threading.Tasks;
using Clients.Models.Order;

namespace Clients.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> getOrder(string orderId);
        public Task<Order> createOrder(Order order);
    }
}
