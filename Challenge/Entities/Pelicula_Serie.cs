using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Entities
{
    public class Pelicula_Serie
    {
        [Key]
        public int Pelicula_SerieId { get; set; }
        public byte[] Imagen { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime Fecha_Creación { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, 5, ErrorMessage = "{0} debe estar comprendida entre {1} y {2}")]
        public int Caliﬁcacion{get;set;}//(del 1 al 5).
        public ICollection <Personaje> Personajes_Asociados { get; set; }
    }
}
