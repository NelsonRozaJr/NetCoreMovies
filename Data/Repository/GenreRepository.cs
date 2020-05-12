using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using NetCoreMovies.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovies.Data.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IConfiguration _configuration;

        public GenreRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<SelectListItem> GetGenreItems()
        {
            var result = new List<SelectListItem>();

            var configGenres = _configuration.GetSection("GenreNames").Get<List<string>>();
            foreach (var configGenre in configGenres)
            {
                result.Add(new SelectListItem()
                {
                    Value = configGenre,
                    Text = configGenre
                });
            }

            result = result
                .OrderBy(o => o.Text)
                .ToList();

            result.Insert(0, new SelectListItem
            {
                Value = "",
                Text = " - "
            });

            return result;
        }
    }
}
