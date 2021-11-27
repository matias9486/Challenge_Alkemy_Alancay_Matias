using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Entities
{
    public class Genero
    {
        [Key]
        public int GeneroId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }
        public byte[] Imagen { get; set; }
        public ICollection <Pelicula_Serie>Peliculas_Series{get;set;}
    }
}
