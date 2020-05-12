using NetCoreMovies.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCoreMovies.Data.Repository.Interfaces
{
    public interface IMovieRepository
    {
        void Add(Movie movie);

        void Update(Movie movie);

        void Remove(Movie movie);

        Task<bool> SaveChangesAsync();

        Task<List<Movie>> ToListAsync();

        Task<Movie> FirstOrDefaultAsync(Expression<Func<Movie, bool>> expression);

        ValueTask<Movie> FindAsync(int? id);

        bool MovieExists(int id);
    }
}
