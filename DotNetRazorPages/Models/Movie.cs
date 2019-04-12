using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetRazorPages.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { set; get; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { set; get; }
        [Column(TypeName ="decima(18, 2)")]
        public decimal Price { get; set; }
    }
}
