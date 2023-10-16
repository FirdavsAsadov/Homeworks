namespace N53_Ht_Task1.api.Models
{
    public class OrderCreatedEvent
    {
        public event Func<Order, ValueTask>? OnOrderCreated;
        public async ValueTask CreateOrderEventAsync(Order order)
        {
            if(OnOrderCreated != null)
                 OnOrderCreated?.Invoke(order);
        }
    }
}
