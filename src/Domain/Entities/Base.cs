namespace FlowBiz.Domain.Entities;
public abstract class Base
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }
    public bool IsActive {get; set;}

    public Base()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        LastUpdatedAt = null;
        IsActive = true;
    }
}
