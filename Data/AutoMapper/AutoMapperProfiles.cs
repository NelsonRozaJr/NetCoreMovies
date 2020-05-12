using AutoMapper;
using NetCoreMovies.Data.Domain;
using NetCoreMovies.ViewModel;

namespace NetCoreMovies.Data.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Movie, MovieViewModel>()
                .ReverseMap();
        }
    }
}
