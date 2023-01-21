using Microsoft.EntityFrameworkCore;
using DrawApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy1",
        policy =>
        {
            policy.WithOrigins("http://example.com",
                                "http://www.contoso.com");
        });

    options.AddPolicy("AnotherPolicy",
        policy =>
        {
            policy.WithOrigins("https://deadlyshoes.github.io")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UserContext>(opt => opt.UseNpgsql("Host=containers-us-west-21.railway.app;Port=6598;Pooling=true;Database=railway;User Id=postgres;Password=pq31nScnyIutlStMvsil;"));
builder.Services.AddDbContext<ShapeContext>(opt => opt.UseNpgsql("Host=containers-us-west-21.railway.app;Port=6598;Pooling=true;Database=railway;User Id=postgres;Password=pq31nScnyIutlStMvsil;"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
