namespace BurgerStore.Domain.Domains
{
    public class Customer : Entity
    {
        public string Name { get; private set; }

        public Customer(string name)
        {
            Name = name;
        }
    }
}
