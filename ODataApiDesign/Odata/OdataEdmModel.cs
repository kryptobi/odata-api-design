namespace ODataApiDesign.Odata;

public static class OdataEdmModel
{
    public static IEdmModel GetModel()
    {
        var odataBuilder = new ODataConventionModelBuilder();
        odataBuilder.EntitySet<Buyer>("Buyers").EntityType.HasKey(b => b.Id);
        odataBuilder.EntitySet<Product>("Products").EntityType.HasKey(b => b.Id);
        
        return odataBuilder.GetEdmModel();
    }
}