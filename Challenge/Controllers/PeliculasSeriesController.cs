using Challenge.Context;
using Challenge.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/Movies")]
    [ApiController]
    public class PeliculasSeriesController : ControllerBase
    {
        private readonly ChallengeContext _context;

        public PeliculasSeriesController(ChallengeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //obtengo lista original con todos los atributos
            List<Pelicula_Serie> lista = _context.Peliculas_Series.ToList();

            //lista auxiliar para cargar los objetos con los datos a mostrar
            List<ObtenerPeliculas_Series> listaAux = new List<ObtenerPeliculas_Series>();
            foreach (var p in lista)
            {
                ObtenerPeliculas_Series aux = new ObtenerPeliculas_Series();
                aux.Imagen = p.Imagen;
                aux.Titulo = p.Titulo;
                aux.Fecha_Creacion = p.Fecha_Creación;
                listaAux.Add(aux);
            }
            return Ok(listaAux);
        }

        [HttpGet]
        [Route("Peliculas_Detalladas")]
        public IActionResult ObtenerPeliculasSeries()
        {
            return Ok(_context.Peliculas_Series.ToList());
        }

        [HttpPost]
        public IActionResult Post(Pelicula_Serie pelicula)
        {
            if (pelicula == null) { return BadRequest(ModelState); }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            _context.Peliculas_Series.Add(pelicula);
            _context.SaveChanges();
            return Ok("Se creó pelicula con éxito");
        }

        [HttpPut]
        public IActionResult Put(Pelicula_Serie pelicula)
        {
            if (_context.Peliculas_Series.FirstOrDefault(x => x.Pelicula_SerieId == pelicula.Pelicula_SerieId) == null)
                return BadRequest("La Película o serie enviada no existe");

            var modificar = _context.Peliculas_Series.Find(pelicula.Pelicula_SerieId);

            modificar.Caliﬁcacion = pelicula.Caliﬁcacion;
            modificar.Fecha_Creación = pelicula.Fecha_Creación;
            modificar.Imagen = pelicula.Imagen;
            modificar.Personajes_Asociados = pelicula.Personajes_Asociados;
            modificar.Titulo = pelicula.Titulo;            

            _context.SaveChanges();
            return Ok("Se modificó la película/serie con éxito.");
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (_context.Peliculas_Series.FirstOrDefault(x => x.Pelicula_SerieId == id) == null)
                return BadRequest("La película o serie enviada no existe");

            var aux = _context.Peliculas_Series.Find(id);

            _context.Peliculas_Series.Remove(aux);

            _context.SaveChanges();
            return Ok("Se eliminó película/serie con éxito.");
        }


        /*
         /movies?name=nombre
        /movies?genre=idGenero
        /movies?order=ASC | DESC
                 */

        [HttpGet]
        [Route("ByName")]
        public IActionResult GetByName(string nombre)
        {
            List<Pelicula_Serie> lista = _context.Peliculas_Series.Where(p => p.Titulo == nombre).ToList();
            if (lista.Count > 0)
                return Ok(lista);
            else
                return NotFound($"No se encontró película o serie con el nombre: {nombre}");
        }



        [HttpGet]
        [Route("ByGenre")]
        public IActionResult GetByGenero(int IdGenero)
        {
            List<Genero> lista = _context.generos.Where(p => p.GeneroId == IdGenero).ToList();

            if (lista.Count > 0)
                return Ok(lista);
            else
                return NotFound($"No se encontró película o series del género: {IdGenero}");
        }

        [HttpGet]
        [Route("ByOrder")]
        public IActionResult GetByOrder(string order)
        {
            List<Pelicula_Serie> lista = _context.Peliculas_Series.ToList();

            if (order.ToUpper() == "ASC")
                return Ok(lista.OrderBy(p=>p.Titulo).ToList());
            else
                return Ok(lista.OrderByDescending(p => p.Titulo).ToList());

        }
        
    }

}
