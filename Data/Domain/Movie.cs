using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreMovies.Data.Domain
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Genre { get; set; }

        [Required]
        [StringLength(1000)]
        public string Synopsis { get; set; }

        [Required]
        public int Runtime { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public string Maturity { get; set; }

        [Required]
        public DateTime SaveDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
