using BurgerStore.Domain.Domains;
using Flunt.Validations;

namespace BurgerStore.Domain.Validations
{
    public class OrderItemContract : Contract<OrderItem>
    {
        public OrderItemContract(OrderItem orderItem)
        {
            Requires()
                .IsNotNull(orderItem.Product, nameof(Product), "Invalid Product!")
                .IsGreaterThan(orderItem.Quantity, 0, nameof(orderItem.Quantity), "The quantity must be greater than 0");
        }
    }
}
