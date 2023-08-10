using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Product
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}