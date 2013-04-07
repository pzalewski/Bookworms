using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bookworms.Models
{
    [MetadataType(typeof(ReviewMetadata))]
    public partial class Review
    {

    }

    public class ReviewMetadata
    {
        [Display(Name = "Tytuł recenzji")]
        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [StringLength(250, ErrorMessage = "Tytuł książki nie może przekraczać 250 znaków")]
        public string Title { get; set; }

        [Display(Name = "Autor recenzji")]
        [Required(ErrorMessage = "Autor jest wymagany")]
        [StringLength(100, ErrorMessage = "Autor książki nie może przekraczać 100 znaków")]
        public string Author { get; set; }

        [Display(Name = "Treść")]
        [Required(ErrorMessage = "Treść jest wymagana")]
        public string Content { get; set; }
    }
}