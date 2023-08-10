using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.CustomerService;

public class CustomerService : ICustomerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CustomerService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetCustomerDto>> GetCustomers()
    {
        var customers = await _context.Customers.ToListAsync();
        return _mapper.Map<List<GetCustomerDto>>(customers);
    }

    public List<GetCustomerDto> GetCustomersByName(string name)
    {
        var customers = _context.Customers.
            Where(c => EF.Functions
                .Like(c.FirstName, $"{name}") || EF.Functions
                .Like(c.LastName, $"{name}"));
        return _mapper.Map<List<GetCustomerDto>>(customers);
    }

    public async Task<GetCustomerDto> GetCustomerById(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        return _mapper.Map<GetCustomerDto>(customer);
    }

    public async Task<GetCustomerDto> AddCustomer(AddCustomerDto addCustomer)
    {
        var customer = _mapper.Map<Customer>(addCustomer);
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return _mapper.Map<GetCustomerDto>(customer);
    }

    public async Task<GetCustomerDto> UpdateCustomer(AddCustomerDto addCustomer)
    {
        var customer = _mapper.Map<Customer>(addCustomer);
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
        return _mapper.Map<GetCustomerDto>(customer);
    }

    public async Task<bool> DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return false;
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }
}