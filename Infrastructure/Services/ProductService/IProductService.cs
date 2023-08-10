using Domain.Dtos;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Infrastructure.Services.ProductService;

public interface IProductService
{
    Task<List<GetProductDto>> GetProducts();
    List<GetProductDto> GetProductsByName(string name);
    Task<GetProductDto> GetProductById(int id);
    Task<GetProductDto> AddProduct(AddProductDto addProduct);
    Task<GetProductDto> UpdateProduct(AddProductDto addProduct);
    Task<bool> DeleteProduct(int id);
}