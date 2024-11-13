using Examen3P.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen3P.Data
{
    public class PeliculaContext:DbContext
    {
        public PeliculaContext(DbContextOptions<PeliculaContext> options ) : base(options) { }
        public DbSet<Pelicula> peliculas { get; set; }
    }
}
