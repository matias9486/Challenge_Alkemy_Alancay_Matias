using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Entities
{
    public class ObtenerPeliculas_Series
    {
        //clase creada para mostrar solo los datos pedidos al mostrar las peliculas
        public byte[] Imagen { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha_Creacion { get; set; }
    }
}
