using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<Order, GetOrderDto>();
        CreateMap<AddOrderDto, Order>();

        CreateMap<Customer, GetCustomerDto>();
        CreateMap<AddCustomerDto, Customer>();

        CreateMap<Product, GetProductDto>();
        CreateMap<AddProductDto, Product>();

        CreateMap<OrderDetail, GetOrderDetailDto>();
        CreateMap<AddOrderDetailDto, OrderDetail>();
    }
}