using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookworms.Models;

namespace Bookworms.ViewModel
{
    public class BookVM
    {
        public int IdBook {get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string GenreName { get; set; }
        public DateTime AddDate { get; set; }
        public List<Review> Reviews { get; set; }
    }
}