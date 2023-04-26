using Microsoft.AspNetCore.Rewrite;
using stock_api.Context;
using stock_api.RabbitMQ;
using stock_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderConfirmedService, OrderConfirmedService>();
builder.Services.AddDbContext<OrderContext>();
builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
