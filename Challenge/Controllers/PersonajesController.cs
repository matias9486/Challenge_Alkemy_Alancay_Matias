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
    [Route("api/Characters")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private readonly ChallengeContext _context;

        public PersonajesController(ChallengeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Personaje> personajes = _context.Personajes.ToList();
            
            List<ObtenerPersonajes> lista = new List<ObtenerPersonajes>();

            foreach (var p in personajes)
            {
                ObtenerPersonajes personaje = new ObtenerPersonajes();
                personaje.Imagen = p.Imagen;
                personaje.Nombre = p.Nombre;
                lista.Add(personaje);
            }
            return Ok(lista);
        }

        [HttpGet]
        [Route("Personajes_Detallados")]
        public IActionResult ObtenerPersonajes()
        {            
            return Ok(_context.Personajes.ToList());
        }

        [HttpPost]
        public IActionResult Post(Personaje personaje)
        {
            if (personaje == null) { return BadRequest(ModelState); }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            _context.Personajes.Add(personaje);
            _context.SaveChanges();
            return Ok("Se creó personaje con éxito");
        }

        [HttpPut]
        public IActionResult Put(Personaje personaje)
        {
            if (_context.Personajes.FirstOrDefault(x => x.PersonajeId == personaje.PersonajeId) == null) 
                return BadRequest("El personaje enviado no existe"); 
            
            var modificar = _context.Personajes.Find(personaje.PersonajeId);
            
            modificar.Nombre = personaje.Nombre;
            modificar.Imagen = personaje.Imagen;
            modificar.Edad = personaje.Edad;
            modificar.Historia = personaje.Historia;
            modificar.Peso = personaje.Peso;
            modificar.Peliculas_Series = personaje.Peliculas_Series;

            _context.SaveChanges();     
            return Ok(_context.Personajes.ToList());
        }


        [HttpDelete]
        [Route("{id}")] 
        public IActionResult Delete(int id)     
        {
            if (_context.generos.FirstOrDefault(x => x.GeneroId == id) == null) 
                return BadRequest("El personaje enviado no existe"); 
                            
            var aux = _context.Personajes.Find(id);
            
            _context.Personajes.Remove(aux);

            _context.SaveChanges();     
            return Ok(_context.Personajes.ToList());
        }
        
        [HttpGet]  
        [Route("ByName")]
        public IActionResult GetByName(string nombre)
        {
            List<Personaje> personajes = _context.Personajes.Where(p=>p.Nombre==nombre).ToList();
            if (personajes.Count > 0)
                return Ok(personajes);
            else
                return NotFound($"No se encontró personaje con el nombre: {nombre}");
        }


        
        [HttpGet]        
        [Route("ByAge")]
        public IActionResult GetByAge(int edad)
        {
            List<Personaje> personajes = _context.Personajes.Where(p => p.Edad == edad).ToList();

            if (personajes.Count > 0)
                return Ok(personajes);
            else
                return NotFound($"No se encontró personaje con la edad: {edad}");
        }
        
        [HttpGet]
        [Route("ByWeight")]
        public IActionResult GetByWeight(double peso)
        {
            List<Personaje> personajes = _context.Personajes.Where(p => p.Peso == peso).ToList();

            if (personajes.Count > 0)
                return Ok(personajes);
            else
                return NotFound($"No se encontró personaje con el peso: {peso}");
        }

        [HttpGet]
        [Route("ByMovie")]
        public IActionResult GetByMovies(int movies)
        {
            Pelicula_Serie peliculaSerie = _context.Peliculas_Series.FirstOrDefault(p=>p.Pelicula_SerieId==movies);

            if (peliculaSerie != null)
                return Ok(peliculaSerie.Personajes_Asociados.ToList());
            else
                return NotFound($"No se encontró película o serie con el Id {movies}.");
        }
               
    }
}
