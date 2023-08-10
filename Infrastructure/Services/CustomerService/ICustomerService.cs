using Domain.Dtos;

namespace Infrastructure.Services.CustomerService;

public interface ICustomerService
{
    Task<List<GetCustomerDto>> GetCustomers();
    List<GetCustomerDto> GetCustomersByName(string name);
    Task<GetCustomerDto> GetCustomerById(int id);
    Task<GetCustomerDto> AddCustomer(AddCustomerDto addCustomer);
    Task<GetCustomerDto> UpdateCustomer(AddCustomerDto addCustomer);
    Task<bool> DeleteCustomer(int id);
}