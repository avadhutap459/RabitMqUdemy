using MassTransit;
using SharedMessage.Messages;

namespace ShippingServices.Consumer
{
    public class OrderPlacedConsumer : IConsumer<OrderPlaced>
    {
        public Task Consume(ConsumeContext<OrderPlaced> context)
        {
            Console.WriteLine($"Order recevied for shipping : {context.Message.orderId} and quantity {context.Message.Quantity}");

            return Task.CompletedTask;
        }
    }
}
