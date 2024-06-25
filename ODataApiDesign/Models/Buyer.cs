using System.ComponentModel.DataAnnotations;

namespace ODataApiDesign.Models;

public class Buyer
{
    [Key]
    public Guid Id { get; private init; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    
    public static Buyer Create(
        string name,
        string email)
    {
        return new Buyer(
            Guid.NewGuid(), 
            name, 
            email);
    }

    private Buyer(
        Guid id, 
        string name, 
        string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}