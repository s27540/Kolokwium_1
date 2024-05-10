using WebApplication1.Model;

namespace WebApplication1.Services;

public interface IOrderService
{
    IEnumerable<Product> GetOrderDetails(int orderId);
    void DeleteOrder(int orderId);
}