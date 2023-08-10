using Domain.Dtos;
using Infrastructure.Services.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class OrderController : ControllerBase
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet("get-Orders")]
    public async Task<List<GetOrderDto>> GetOrders()
    {
        return await _service.GetOrders();
    }

    [HttpGet("get-Orders-by-name")]
    public List<GetOrderDto> GetOrdersByName(DateTime dateTime)
    {
        return _service.GetOrdersByDate(dateTime);
    }

    [HttpGet("get-Order-by-id")]
    public async Task<GetOrderDto> GetOrderById(int id)
    {
        return await _service.GetOrderById(id);
    }

    [HttpPost("add-Order")]
    public async Task<GetOrderDto> AddOrder(AddOrderDto addOrder)
    {
        return await _service.AddOrder(addOrder);
    }

    [HttpPut("update-Order")]
    public async Task<GetOrderDto> UpdateOrder(AddOrderDto addOrder)
    {
        return await _service.UpdateOrder(addOrder);
    }

    [HttpDelete("delete-Order")]
    public async Task<bool> DeleteOrder(int id)
    {
        return await _service.DeleteOrder(id);
    }
}