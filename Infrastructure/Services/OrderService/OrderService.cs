using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public OrderService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<GetOrderDto>> GetOrders()
    {
        // var orders = await _context.Orders.Include(c => c.Customer)
        //     .ToListAsync();
        // var orders = (from cust in _context.Orders.Include(c => c.Customer)
        //     select cust).ToListAsync();
        // return _mapper.Map<List<GetOrderDto>>(orders);
        var orders = (from o in _context.Orders
                join c in _context.Customers on o.CustomerId equals c.Id
                select new GetOrderDto()
                {
                    CustomerId = c.Id,
                    OrderPlaced = o.OrderPlaced,
                    FullName = string.Concat(c.FirstName, " ", c.LastName),
                    OrderFulfilled = o.OrderFulfilled,
                    Products = o.OrderDetails.Select(od => od.Product).Select(od => new ProductDto()
                    {
                        Id = od.Id,
                        Name = od.Name,
                        Price = od.Price
                    }).ToList()
                }
            ).ToListAsync();
        return await orders;
    }

    public List<GetOrderDto> GetOrdersByDate(DateTime dateTime)
    {
        var orders = _context.Orders.Where(o => o.OrderPlaced == dateTime);
        return _mapper.Map<List<GetOrderDto>>(orders);
    }

    public async Task<GetOrderDto> GetOrderById(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        return _mapper.Map<GetOrderDto>(order);
    }

    public async Task<GetOrderDto> AddOrder(AddOrderDto addOrder)
    {
        var order = _mapper.Map<Order>(addOrder);
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return _mapper.Map<GetOrderDto>(order);
    }

    public async Task<GetOrderDto> UpdateOrder(AddOrderDto addOrder)
    {
        var order = _mapper.Map<Order>(addOrder);
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return _mapper.Map<GetOrderDto>(order);
    }

    public async Task<bool> DeleteOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return false;
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        return true;
    }
}