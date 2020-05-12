using Microsoft.EntityFrameworkCore;
using NetCoreMovies.Data.Domain;
using NetCoreMovies.Data.Repository.Context;
using NetCoreMovies.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCoreMovies.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        public void Add(Movie movie)
        {
            movie.SaveDate = DateTime.Now;
            _context.Add(movie);
        }

        public void Update(Movie movie)
        {
            movie.UpdateDate = DateTime.Now;
            _context.Update(movie);
        }

        public void Remove(Movie movie)
        {
            _context.Remove(movie);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<List<Movie>> ToListAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> FirstOrDefaultAsync(Expression<Func<Movie, bool>> expression)
        {
            return await _context.Movies.FirstOrDefaultAsync(expression);
        }

        public async ValueTask<Movie> FindAsync(int? id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
