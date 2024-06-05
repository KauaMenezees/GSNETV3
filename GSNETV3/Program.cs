using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using GSNETV3.Models;
using GSNETV3.Data; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SmartBinContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Smart Bin API", Version = "v1" });
});


builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Bin API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/api/lixeiras", async (SmartBinContext context) => {
    return await context.Lixeiras.ToListAsync();
});

app.MapPost("/api/itemlixeira", async (SmartBinContext context, ItemLixeira item) => {
    context.ItemLixeira.Add(item);
    await context.SaveChangesAsync();
    return Results.Created($"/api/itemlixeira/{item.ItemLixeiraId}", item);
});

app.MapPost("/api/usuarios", async (SmartBinContext context, Usuario usuario) => {
    context.Usuarios.Add(usuario);
    await context.SaveChangesAsync();
    return Results.Created($"/api/usuarios/{usuario.IdUsuario}", usuario);
});

app.Run();
