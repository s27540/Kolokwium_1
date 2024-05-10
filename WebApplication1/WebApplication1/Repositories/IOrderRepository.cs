using WebApplication1.Model;

namespace WebApplication1.Repositories;

public interface IOrderRepository
{
    IEnumerable<Product> GetOrderById(int orderId);
    void DeleteOrder(int orderId);
}