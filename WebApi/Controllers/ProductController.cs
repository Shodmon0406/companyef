using Domain.Dtos;
using Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet("get-products")]
    public async Task<List<GetProductDto>> GetProducts()
    {
        return await _service.GetProducts();
    }

    [HttpGet("get-products-by-name")]
    public List<GetProductDto> GetProductsByName(string name)
    {
        return _service.GetProductsByName(name);
    }

    [HttpGet("get-product-by-id")]
    public async Task<GetProductDto> GetProductById(int id)
    {
        return await _service.GetProductById(id);
    }

    [HttpPost("add-product")]
    public async Task<GetProductDto> AddProduct(AddProductDto addProduct)
    {
        return await _service.AddProduct(addProduct);
    }

    [HttpPut("update-product")]
    public async Task<GetProductDto> UpdateProduct(AddProductDto addProduct)
    {
        return await _service.UpdateProduct(addProduct);
    }

    [HttpDelete("delete-product")]
    public async Task<bool> DeleteProduct(int id)
    {
        return await _service.DeleteProduct(id);
    }
}