using BurgerStore.Domain.Validations;

namespace BurgerStore.Domain.Domains
{
    public class OrderItem : Entity
    {
        public int Quantity { get; private set; }

        public decimal Price { get; private set; }

        public Product Product { get; private set; }

        public OrderItem(int quantity, Product product)
        {
            Product = product;
            Quantity = quantity;
            Price = product?.Price ?? 0;

            AddNotifications(new OrderItemContract(this));
        }

        public decimal Total()
        {
            return Price * Quantity;
        }
    }
}
