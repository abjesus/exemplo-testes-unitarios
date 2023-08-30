using BurgerStore.Domain.Enums;
using BurgerStore.Domain.Validations;

namespace BurgerStore.Domain.Domains
{
    public class Order : Entity
    {
        public Customer Customer { get; private set; }

        public decimal Amount { get; private set; }

        public Discount? Discount { get; private set; }

        public List<OrderItem> Items { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public EnumOrderStatus Status { get; private set; }

        public Order(Customer customer, Discount? discount)
        {
            CreatedAt = DateTime.Now;
            Status = EnumOrderStatus.WaitingPayment;
            Discount = discount;
            Customer = customer;
            Items = new List<OrderItem>();

            AddNotifications(new OrderContract(this));
        }

        public decimal Total()
        {
            foreach (OrderItem item in Items)
            {
                Amount += item.Total();
            }

            Amount -= Discount?.Value() ?? 0;

            return Amount;
        }

        public void ApplyDiscount(Discount discount)
        {
            Amount -= discount?.Value() ?? 0;
        }

        public void AddItem(OrderItem orderItem)
        {
            if (orderItem.IsValid)
            {
                Items.Add(orderItem);
            }
        }

        public void RemoveItem(OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }

        public void Pay(decimal amount)
        {
            if (amount == Total())
            {
                Status = EnumOrderStatus.WaitingDelivery;
            }
        }

        public void Cancel()
        {
            Status = EnumOrderStatus.Canceled;
        }
    }
}
