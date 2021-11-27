using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Entities
{
    public class Personaje
    {
        [Key]
        public int PersonajeId { get; set; }
        public byte[] Imagen { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Historia { get; set; }        
        public ICollection<Pelicula_Serie> Peliculas_Series { get; set; }

    }
}
