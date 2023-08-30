namespace BurgerStore.Domain.Enums
{
    public enum EnumOrderStatus
    {
        WaitingPayment = 0,
        WaitingDelivery = 1,
        Delivered = 3,
        Completed = 4,
        Canceled = 5
    }
}
