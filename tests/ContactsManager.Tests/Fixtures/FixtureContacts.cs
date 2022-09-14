using ContactsManager.Domain.Entities;

namespace ContactsManager.Tests.Fixtures;

public static class FixtureContacts
{
    public static readonly Contact ContactForDelete = new()
    {
        Id = Guid.NewGuid(),
        Name = "Lindsey Burke",
        MobilePhone = "+1234-567-8901",
        JobTitle = "This is job title!",
        BirthDate = new DateTime(2000, 1, 1),
        CreatedAt = DateTimeOffset.Now,
        UpdatedAt = DateTimeOffset.Now.AddHours(12)
    };

    public static readonly Contact ContactForUpdate = new()
    {
        Id = Guid.NewGuid(),
        Name = "Martin Griffith",
        MobilePhone = "+1234-567-8902",
        JobTitle = "This is job title!",
        BirthDate = new DateTime(1989, 12, 16),
        CreatedAt = DateTimeOffset.Now,
        UpdatedAt = null
    };

    public static readonly Contact ContactForGetById = new()
    {
        Id = Guid.NewGuid(),
        Name = "John Doe",
        MobilePhone = "+1234-567-8903",
        JobTitle = "This is job title!",
        BirthDate = new DateTime(2001, 11, 03),
        CreatedAt = DateTimeOffset.Now,
        UpdatedAt = DateTimeOffset.Now.AddDays(1).AddHours(14)
    };
}