using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreMovies.Data.Domain;
using NetCoreMovies.Data.Repository.Interfaces;
using NetCoreMovies.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMaturityRepository _maturityRepository;
        private readonly IMapper _mapper;

        public MoviesController(IMovieRepository movieRepository, IGenreRepository genreRepository, IMaturityRepository maturityRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _maturityRepository = maturityRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieRepository.GetAllAsync();
            var movieViewModel = _mapper.Map<List<MovieViewModel>>(movies);

            return View(movieViewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieRepository.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            var movieViewModel = _mapper.Map<MovieViewModel>(movie);

            return View(movieViewModel);
        }

        public IActionResult Create()
        {
            var movieViewModel = new MovieViewModel
            {
                GenreItems = _genreRepository.GetGenreItems(),
                MaturityItems = _maturityRepository.GetMaturityItems()
            };

            return View(movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = _mapper.Map<Movie>(model);
                _movieRepository.Add(movie);
                await _movieRepository.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieRepository.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            var movieViewModel = _mapper.Map<MovieViewModel>(movie);
            movieViewModel.GenreItems = _genreRepository.GetGenreItems();
            movieViewModel.MaturityItems = _maturityRepository.GetMaturityItems();

            return View(movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var movie = _mapper.Map<Movie>(model);
                    _movieRepository.Update(movie);
                    await _movieRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_movieRepository.MovieExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _movieRepository.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            var movieViewModel = _mapper.Map<MovieViewModel>(movie);

            return View(movieViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _movieRepository.FindAsync(id);
            _movieRepository.Remove(movie);
            await _movieRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm)
        {
            var query = _movieRepository.GetAll();
            
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(s => s.Title.ToLower().Contains(searchTerm.ToLower()));
            }

            var movies = await query.ToListAsync();

            return View(nameof(Index), _mapper.Map<List<MovieViewModel>>(movies));
        }
    }
}
