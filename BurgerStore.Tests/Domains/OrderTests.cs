using BurgerStore.Domain.Domains;
using BurgerStore.Domain.Enums;

namespace BurgerStore.Tests.Domains
{
    public class OrderTests
    {
        private readonly Customer _customer = new("Abel");
        private readonly Discount _discount = new(amount: 10, DateTime.Now.AddDays(2));
        private readonly Product _product = new("x-burger", price: 10);

        [Fact]
        public void CreateNewOrder()
        {
            var order = new Order(_customer, _discount);
            Assert.True(order.IsValid);
        }

        [Fact]
        public void OrderStatusShouldBeWaitingPayment()
        {
            var order = new Order(_customer, null);
            Assert.True(order.Status == EnumOrderStatus.WaitingPayment);
        }

        [Fact]
        public void OrderStatusShouldBeWaitingDelivery()
        {
            var order = new Order(_customer, null);

            order.AddItem(new OrderItem(quantity: 1, _product));

            order.Pay(amount: 10);

            Assert.True(order.Status == EnumOrderStatus.WaitingDelivery);
        }

        [Fact]
        public void OrderStatusShouldBeCanceled()
        {
            var order = new Order(_customer, null);
            order.Cancel();

            Assert.True(order.Status == EnumOrderStatus.Canceled);
        }

        [Fact]
        public void ApplyDiscount()
        {
            var order = new Order(_customer, _discount);

            order.AddItem(new OrderItem(quantity: 5, _product));

            Assert.True(order.Total() == 40);
        }

        [Fact]
        public void IgnoreExpiredDiscount()
        {
            var expiredDiscount = new Discount(amount: 10, DateTime.Now.AddDays(-2));

            var order = new Order(_customer, expiredDiscount);

            order.AddItem(new OrderItem(quantity: 5, _product));

            Assert.True(order.Total() == 50);
        }
    }
}
