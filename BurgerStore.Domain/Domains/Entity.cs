using Flunt.Notifications;

namespace BurgerStore.Domain.Domains
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
