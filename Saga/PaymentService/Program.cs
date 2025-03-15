using MassTransit;
using SharedMessage.Messages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<InventoryReservedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost");
        cfg.ReceiveEndpoint("inventory-reserved", e =>
        {
            e.Consumer<InventoryReservedConsumer>();
        });
    });
});

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();



public class InventoryReservedConsumer : IConsumer<InventoryReserved>
{
    public async Task Consume(ConsumeContext<InventoryReserved> context)
    {
        Console.WriteLine($"Payment process for Order  {context.Message.orderId} ");

        await context.Publish(new PaymentCompleted(context.Message.orderId));
    }
}