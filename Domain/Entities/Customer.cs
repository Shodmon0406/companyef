using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Customer
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }
    [MaxLength(100)]
    public string Address { get; set; }
    [MaxLength(100)]
    public string? Email { get; set; }
    [MaxLength(20)]
    public string Phone { get; set; }

    public List<Order> Orders { get; set; }
}