namespace Blog.Domain.Common;

public abstract class BaseEntity
{
    private readonly Guid _adminId = Guid.Parse("6aa54ded-bfe1-428c-b381-20f4497bb513");
    public Guid Id { get; private init; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Guid CreatedBy { get; private set; }
    public Guid UpdatedBy { get; private set; }

    protected BaseEntity(Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;

        CreatedBy = _adminId;
        UpdatedBy = _adminId;
    }
}