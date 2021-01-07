using AutoMapper;
using GithubService.DTOs;
using GithubService.Models;

namespace GithubService.Profiles
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<GithubApiResponse, Project>().ForMember(
                dest => dest.Forks,
                opt=> opt.MapFrom(src => src.Forks_Count))
                .ForMember(
                    dest => dest.Stars,
                    opt=> opt.MapFrom(src => src.Stargazers_Count))
                .ForMember(
                    dest => dest.CreatedAt,
                    opt=> opt.MapFrom(src => src.Created_At))
                .ForMember(
                    dest => dest.Link,
                    opt=> opt.MapFrom(src => src.Html_Url));
        }
    }
}