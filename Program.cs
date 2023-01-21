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
            policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UserContext>(opt => opt.UseNpgsql("Host=dpg-cf632qda499d72tt1gl0-a.oregon-postgres.render.com;Port=5432;Pooling=true;Database=db_draw;User Id=db_draw_user;Password=WyKslmz7RwX6J1WfAZB3a4icgQ67iIYS;"));
builder.Services.AddDbContext<ShapeContext>(opt => opt.UseNpgsql("Host=dpg-cf632qda499d72tt1gl0-a.oregon-postgres.render.com;Port=5432;Pooling=true;Database=db_draw;User Id=db_draw_user;Password=WyKslmz7RwX6J1WfAZB3a4icgQ67iIYS;"));
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
