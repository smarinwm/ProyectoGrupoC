using GrupoC.AlbaranDeEntrega.Interfaces;
using GrupoC.AlbaranDeEntrega.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("estanteriasService", c =>
{
    c.BaseAddress = new Uri(configuration["Services:Estanterias"]);
});
builder.Services.AddHttpClient("productosService", c =>
{
    c.BaseAddress = new Uri(configuration["Services:Productos"]);
});

builder.Services.AddScoped<IEstanteriaService, EstanteriaService>();
builder.Services.AddScoped<IProductoService, ProductosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
