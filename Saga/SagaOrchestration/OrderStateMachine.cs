using MassTransit;
using SharedMessage.Messages;

namespace SagaOrchestration
{
    public class OrderStateMachine : MassTransitStateMachine<OrderState>
    {
        //state
        public State Submitted { get; private set; }
        public State InventoryReserved { get;private set; }
        public State PaymentCompleted { get;private set; }

        //Event
        public Event<OrderPlaced> OrderPlacedEvent { get; private set; }
        public Event<InventoryReserved> InventoryReservedEvent { get; private set; }
        public Event<PaymentCompleted> PaymentCompletedEvent { get; private set; }


        public OrderStateMachine()
        {
            InstanceState(x => x.CurrentState);

            Event(() => OrderPlacedEvent, x => x.CorrelateById(context => context.Message.orderId));
            Event(() => InventoryReservedEvent, x => x.CorrelateById(context => context.Message.orderId));
            Event(() => PaymentCompletedEvent, x => x.CorrelateById(context => context.Message.orderId));

            Initially(
                When(OrderPlacedEvent)
                .Then( context =>
                {
                    context.Instance.OrderId = context.Data.orderId;
                    context.Instance.Quantity = context.Data.Quantity;
                    Console.WriteLine($"order {context.Instance.OrderId} placed successfully");
                }).TransitionTo(Submitted));

            During(Submitted,
                When(InventoryReservedEvent)
                .TransitionTo(InventoryReserved));

            During(InventoryReserved,
                When(PaymentCompletedEvent)
                .Then(context => Console.WriteLine($"order {context.Instance.OrderId} completed successfully"))
                .TransitionTo(PaymentCompleted)
                .Finalize());

            SetCompletedWhenFinalized();
        }
    }
}
