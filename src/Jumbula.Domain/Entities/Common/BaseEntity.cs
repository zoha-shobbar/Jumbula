namespace Jumbula.Domain.Entities.Common;
public abstract class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; }
}
