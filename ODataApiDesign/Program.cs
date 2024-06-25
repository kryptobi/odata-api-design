var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true)
    .AllowCredentials());
        
app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();


void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<OdataDbContext>(options =>
        options.UseInMemoryDatabase("OdataDb"));
    
    services.AddControllers()
        .AddOData(opt => opt.AddRouteComponents("odata", OdataEdmModel.GetModel())
            .Filter().Select().Expand().OrderBy().Count().SetMaxTop(100));

    services.AddMvc();
}