using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        //DirectorId will add
        [Required]
        public string  DirectorName{ get; set; }
        [Required]
        public string MovieName { get; set; }
        public string MovieImdb { get; set; }//Format tipi getir

     
        public string ReleaseYear { get; set; }//datetime will be
  

    }
}
