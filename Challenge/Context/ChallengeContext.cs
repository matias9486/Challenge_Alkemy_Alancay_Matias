using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Challenge.Entities;


namespace Challenge.Context
{
    public class ChallengeContext: DbContext
    {
        private const string schema = "Challenge";

        public ChallengeContext(DbContextOptions options):base(options)
        {

        }
            
        public DbSet<Genero> generos { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Pelicula_Serie> Peliculas_Series { get; set; }

    }
}
