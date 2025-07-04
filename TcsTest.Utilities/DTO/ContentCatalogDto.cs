using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcsTest.Utilities.DTO
{
    public class ContentCatalogDto
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [RegularExpression("Movie|TV Show", ErrorMessage = "Type must be either 'Movie' or 'TV Show'.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0.")]
        public int DurationMinutes { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        public string Rating { get; set; }

        public int Year { get; set; }

        public int? Season { get; set; }

        public int? Episode { get; set; }
    }
}
