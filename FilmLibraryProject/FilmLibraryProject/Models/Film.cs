using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibraryProject.Models
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }
        public string FilmName { get; set; }
    }
}
