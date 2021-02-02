using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_IS413.Models
{
    public class MovieResponse
    {
         [Required]
         public string Category { get; set; }
        [Required]
         public string Title { get; set; }
        [Required]
         public int YearReleased { get; set; }
        [Required]
         public string DirectorName { get; set; }
        [Required (ErrorMessage ="Please Select a Rating")]
         public string MovieRating { get; set; }
         public bool IsEdited { get; set; }
         public string IsLentTo { get; set; }
        [StringLength (25) ]
         public string Notes { get; set; }

    }
}
