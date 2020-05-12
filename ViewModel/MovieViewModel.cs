using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreMovies.ViewModel
{
    public class MovieViewModel
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [Display(Name = "Título")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "O gênero é obrigatório")]
        [Display(Name = "Gênero")]
        [StringLength(100)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "A sinopse é obrigatória")]
        [Display(Name = "Sinopse")]
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Synopsis { get; set; }

        [Required(ErrorMessage = "A duração é obrigatória")]
        [Display(Name = "Duração (minutos)")]
        public int Length { get; set; }

        [Required(ErrorMessage = "A data de lançamento é obrigatória")]
        [Display(Name = "Data de lançamento")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
