using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{orderId}")]
    public IActionResult GetOrder(int orderId)
    {
        var order = _orderService.GetOrderDetails(orderId);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpDelete("{orderId}")]
    public IActionResult DeleteOrder(int orderId)
    {
        _orderService.DeleteOrder(orderId);
        return NoContent();
    }
}