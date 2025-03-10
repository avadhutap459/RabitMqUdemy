using MassTransit;
using SharedMessage.Messages;

namespace TrackingService.Consumer
{
    public class OrderPlacedConsumer : IConsumer<OrderPlaced>
    {
        public Task Consume(ConsumeContext<OrderPlaced> context)
        {
            Console.WriteLine($"Order recevied for tracking : {context.Message.orderId} and quantity {context.Message.Quantity}");

            return Task.CompletedTask;
        }
    }
}
