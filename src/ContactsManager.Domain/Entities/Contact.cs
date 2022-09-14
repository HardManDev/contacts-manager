namespace ContactsManager.Domain.Entities;

public class Contact
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public string MobilePhone { get; set; } = null!;

    public string? JobTitle { get; set; }

    public DateTimeOffset BirthDate { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}