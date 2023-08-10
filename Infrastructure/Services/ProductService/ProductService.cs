using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.ProductService;

public class ProductService : IProductService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ProductService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<GetProductDto>> GetProducts()
    {
        var products = await _context.Products.ToListAsync();
        return _mapper.Map<List<GetProductDto>>(products);
    }

    public List<GetProductDto> GetProductsByName(string name)
    {
        var products = _context.Products.Where(p=>p.Name.ToLower().Contains(name.ToLower()));
        return _mapper.Map<List<GetProductDto>>(products);
    }

    public async Task<GetProductDto> GetProductById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return _mapper.Map<GetProductDto>(product);
    }

    public async Task<GetProductDto> AddProduct(AddProductDto addProduct)
    {
        var product = _mapper.Map<Product>(addProduct);
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<GetProductDto>(product);
    }

    public async Task<GetProductDto> UpdateProduct(AddProductDto addProduct)
    {
        var product = _mapper.Map<Product>(addProduct);
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<GetProductDto>(product);
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}