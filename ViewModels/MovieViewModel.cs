using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCoreMovies.ViewModels
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
        public string Synopsis { get; set; }

        [Required(ErrorMessage = "A duração é obrigatória")]
        [Range(1, 600, ErrorMessage = "Duração deve estar compreendida entre 1 e 600")]
        [Display(Name = "Duração")]
        public int Runtime { get; set; }

        [Required(ErrorMessage = "O ano de lançamento é obrigatório")]
        [Display(Name = "Ano de lançamento")]
        public int ReleaseYear { get; set; }

        [Required(ErrorMessage = "A classificação indicativa é obrigatória")]
        [Display(Name = "Classificação indicativa")]
        [StringLength(30)]
        public string Maturity { get; set; }

        public DateTime SaveDate { get; set; }

        public List<SelectListItem> GenreItems { get; set; }

        public List<SelectListItem> MaturityItems { get; set; }
    }
}
