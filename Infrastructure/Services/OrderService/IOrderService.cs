using Domain.Dtos;

namespace Infrastructure.Services.OrderService;

public interface IOrderService
{
    Task<List<GetOrderDto>> GetOrders();
    List<GetOrderDto> GetOrdersByDate(DateTime dateTime);
    Task<GetOrderDto> GetOrderById(int id);
    Task<GetOrderDto> AddOrder(AddOrderDto addOrder);
    Task<GetOrderDto> UpdateOrder(AddOrderDto addOrder);
    Task<bool> DeleteOrder(int id);
}