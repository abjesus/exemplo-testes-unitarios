using BurgerStore.Domain.Domains;
using Flunt.Validations;

namespace BurgerStore.Domain.Validations
{
    public class OrderContract : Contract<Order>
    {
        public OrderContract(Order order)
        {
            Requires()
                .IsNotNull(order.Customer, nameof(order.Customer), "Invalid Customer!");                
        }
    }
}
