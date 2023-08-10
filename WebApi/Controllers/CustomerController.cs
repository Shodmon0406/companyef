using Domain.Dtos;
using Infrastructure.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet("get-Customers")]
    public async Task<List<GetCustomerDto>> GetCustomers()
    {
        return await _service.GetCustomers();
    }

    [HttpGet("get-Customers-by-name")]
    public List<GetCustomerDto> GetCustomersByName(string name)
    {
        return _service.GetCustomersByName(name);
    }

    [HttpGet("get-Customer-by-id")]
    public async Task<GetCustomerDto> GetCustomerById(int id)
    {
        return await _service.GetCustomerById(id);
    }

    [HttpPost("add-Customer")]
    public async Task<GetCustomerDto> AddCustomer(AddCustomerDto addCustomer)
    {
        return await _service.AddCustomer(addCustomer);
    }

    [HttpPut("update-Customer")]
    public async Task<GetCustomerDto> UpdateCustomer(AddCustomerDto addCustomer)
    {
        return await _service.UpdateCustomer(addCustomer);
    }

    [HttpDelete("delete-Customer")]
    public async Task<bool> DeleteCustomer(int id)
    {
        return await _service.DeleteCustomer(id);
    }
}