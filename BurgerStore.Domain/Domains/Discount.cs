namespace BurgerStore.Domain.Domains
{
    public class Discount : Entity
    {
        public decimal Amount { get; private set; }

        public DateTime ExpiredAt { get; private set; }

        public Discount(decimal amount, DateTime expiredAt)
        {
            Amount = amount;
            ExpiredAt = expiredAt;
        }

        public bool IsExpired()
        {
            return ExpiredAt < DateTime.Now;
        }

        public decimal Value()
        {
            if (IsExpired())
            {
                return 0;
            }

            return Amount;
        }
    }
}
