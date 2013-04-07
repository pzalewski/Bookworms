using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bookworms.Models
{
    [MetadataType(typeof(BookMetadata))]
    public partial class Book
    {

    }


    public class BookMetadata
    {
        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [StringLength(250, ErrorMessage = "Tytuł książki nie może przekraczać 250 znaków")]
        public string Title { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Autor jest wymagany")]
        [StringLength(100, ErrorMessage = "Autor książki nie może przekraczać 100 znaków")]
        public string Author { get; set; }
    }
}