using prmToolkit.NotificationPattern;

namespace BookStore.Domain.Entities.Base;

public class EntityBase : Notifiable
{
    public EntityBase()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}
