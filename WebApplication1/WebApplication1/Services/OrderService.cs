using WebApplication1.Model;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public IEnumerable<Product> GetOrderDetails(int orderId)
    {
        return _orderRepository.GetOrderById(orderId);
    }

    public void DeleteOrder(int orderId)
    {
        _orderRepository.DeleteOrder(orderId);
    }
}