using AutoMapper;
using NetCoreMovies.Data.Domain;
using NetCoreMovies.ViewModels;

namespace NetCoreMovies.Data.AutoMapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Movie, MovieViewModel>()
                .ReverseMap();
        }
    }
}
