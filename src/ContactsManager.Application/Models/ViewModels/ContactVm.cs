using AutoMapper;
using ContactsManager.Application.Interfaces;
using ContactsManager.Domain.Entities;

namespace ContactsManager.Application.Models.ViewModels;

public class ContactVm : IMapWith<Contact>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public string MobilePhone { get; set; } = null!;

    public string? JobTitle { get; set; }

    public DateTimeOffset? BirthDate { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<ContactVm, Contact>();
}