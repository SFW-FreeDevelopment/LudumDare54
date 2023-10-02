using AutoMapper;
using LudumDare54.API.Models;
using LudumDare54.API.Models.DTO;

namespace LudumDare54.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<HighScore, HighScoreModel>();
        CreateMap<HighScoreModel, HighScore>();
    }
}