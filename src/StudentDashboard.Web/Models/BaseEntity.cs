namespace StudentDashboard.Web.Models;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public virtual string EntityLabel => $"{GetType().Name} #{Id}";

    public virtual void Touch()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
