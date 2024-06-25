namespace ODataApiDesign.Controllers;

[Route("odata/[controller]")]
public class ProductsController : ODataController
{
    private readonly OdataDbContext _context;

    public ProductsController(OdataDbContext context)
    {
        _context = context;
        if (_context.Products.Any()) 
            return;

        var buyer1 = Buyer.Create("John Doe", "john.doe@example.com");
        var buyer2 = Buyer.Create("Ilic Babic", "ilic.babic@example.com");

        _context.Products.AddRange(
            Product.Create("Product1", 10.0m, buyer1.Id),
            Product.Create("Product2", 20.0m, buyer2.Id)
        );
        
        _context.SaveChanges();
    }

    [EnableQuery]
    public IActionResult Get()
    {
        var query = _context.Products;
        return Ok(query);
    }
}
