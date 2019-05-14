using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPageMovie.Move
{
    public class Moveies
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate{ get; set; }
        public string Genre { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
