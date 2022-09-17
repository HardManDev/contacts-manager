using AutoMapper;
using ContactsManager.Application.Interfaces;
using ContactsManager.Application.Requests.Contacts.Commands.CreateContact;

namespace ContactsManager.Models.Dto;

public class CreateContactDto : IMapWith<CreateContactCommand>
{
    public string Name { get; set; } = null!;
    public string MobilePhone { get; set; } = null!;

    public string? JobTitle { get; set; }

    public string? BirthDate { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<CreateContactDto, CreateContactCommand>()
            .ForMember(dest => dest.BirthDate,
                opt =>
                    opt.MapFrom(src =>
                        !string.IsNullOrEmpty(src.BirthDate)
                            ? DateTime.Parse(src.BirthDate)
                            : (DateTime?)null));
}