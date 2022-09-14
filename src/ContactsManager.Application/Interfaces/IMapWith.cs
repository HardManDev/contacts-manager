using AutoMapper;

namespace ContactsManager.Application.Interfaces;

public interface IMapWith<TSource>
{
    void Mapping(Profile profile) =>
        profile.CreateMap(typeof(TSource), GetType());
}