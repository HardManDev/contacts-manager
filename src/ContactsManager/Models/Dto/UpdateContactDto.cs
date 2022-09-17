using AutoMapper;
using ContactsManager.Application.Interfaces;
using ContactsManager.Application.Requests.Contacts.Commands.UpdateContact;

namespace ContactsManager.Models.Dto;

public class UpdateContactDto : IMapWith<UpdateContactCommand>
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? MobilePhone { get; set; }

    public string? JobTitle { get; set; }

    public string? BirthDate { get; set; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<UpdateContactDto, UpdateContactCommand>()
            .ForMember(dest => dest.BirthDate,
                opt =>
                    opt.MapFrom(src =>
                        !string.IsNullOrEmpty(src.BirthDate)
                            ? DateTime.Parse(src.BirthDate)
                            : (DateTime?)null));
}