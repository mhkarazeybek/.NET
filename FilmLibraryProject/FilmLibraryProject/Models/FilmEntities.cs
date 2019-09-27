using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibraryProject.Models
{
    public class FilmEntities:DbContext
    {
        public FilmEntities():base("Server=servername;Database=FilmLibraryProject;User Id=ıd;Password=password")
        {
        }
        public DbSet<Film> Filmler { get; set; }
    }
}
