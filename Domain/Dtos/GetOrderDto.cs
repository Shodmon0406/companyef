namespace Domain.Dtos;

public class GetOrderDto : OrderDto
{
    public string FullName { get; set; }
    public string Name { get; set; }
    public List<ProductDto> Products { get; set; }
}