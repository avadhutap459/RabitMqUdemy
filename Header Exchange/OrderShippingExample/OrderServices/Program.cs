using MassTransit;
using SharedMessage.Messages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit((x) =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost");
        cfg.Message<OrderPlaced>(x => x.SetEntityName("order-headers-exchange"));
        cfg.Publish<OrderPlaced>(x => x.ExchangeType = "headers");
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapPost("/orders", async (OrderRequest order, IBus bus) =>
{
    var orderPlaceMessage = new OrderPlaced(order.orderId, order.quantity);

    var headers = new Dictionary<string, object>();
    if(order.quantity > 10)
    {
        headers["department"] = "shipping";
        headers["priority"] = "high";
    }
    else
    {
        headers["department"] = "tracking";
        headers["priority"] = "low";
    }

    await bus.Publish(orderPlaceMessage , context =>
    {
        context.Headers.Set("department", headers["department"]);
        context.Headers.Set("priority", headers["priority"]);
    });

    return Results.Created($"/orders/{order.orderId}", orderPlaceMessage);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public record OrderRequest(Guid orderId,int quantity);