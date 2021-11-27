using Challenge.Context;
using Challenge.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challenge.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly ChallengeContext _context;

        public GenerosController(ChallengeContext context)
        {
            _context = context;
        }

        
        [HttpGet]        
        public IActionResult Get()
        {

            return Ok(_context.generos.ToList());
        }
        
        [HttpPost]
        public IActionResult Post(Genero genero)      
        {
            if (genero == null) { return BadRequest(ModelState); }

            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            _context.generos.Add(genero);   
            _context.SaveChanges();     
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Genero genero)       
        {
            if (_context.generos.FirstOrDefault(x => x.GeneroId == genero.GeneroId) == null) return BadRequest("El género enviado no existe");

            
            var modificar = _context.generos.Find(genero.GeneroId);            
            modificar.Nombre = genero.Nombre;
            modificar.Imagen = genero.Imagen;
            modificar.Peliculas_Series = genero.Peliculas_Series;

            _context.SaveChanges();     
            return Ok(_context.generos.ToList());
        }


        [HttpDelete]
        [Route("{id}")] 
        public IActionResult Delete(int id)     
        {
            if (_context.generos.FirstOrDefault(x => x.GeneroId == id) == null) return BadRequest("El género enviado no existe"); //sino encuentro ese objeto devuelvo un error 400 y msj
                                                                                                                                   //creamos un objeto Continent auxiliar  y guardamos el original para eliminarlo. Hacemos esto porque no nospermite aplicar _context.Continent.delete(continent) porqueno existe entonces usamos REMOVE.
            var auxContinent = _context.generos.Find(id);
            
            _context.generos.Remove(auxContinent);

            _context.SaveChanges();    
            return Ok(_context.generos.ToList());
        }


    }
}
