using System.ComponentModel.DataAnnotations;

namespace ODataApiDesign.Models;

public class Product
{
    [Key]
    public Guid Id { get; private init; }
    public string Name { get; private set; }
    public decimal Price { get;  private set; }
    
    public Guid BuyerId { get; private set; }
    private Buyer? _buyer;
    public Buyer Buyer => _buyer;

    public static Product Create(
        string name,
        decimal price,
        Guid buyerId)
    {
        return new Product(
            new Guid(),
            name,
            price,
            buyerId)
        {
            _buyer = null
        };
    }
    
    private Product(
        Guid id, 
        string name, 
        decimal price, 
        Guid buyerId)
    {
        Id = id;
        Name = name;
        Price = price;
        BuyerId = buyerId;
    }
}