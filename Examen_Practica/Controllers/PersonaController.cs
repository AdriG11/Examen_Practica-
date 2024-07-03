using Examen_Practica.Data;
using Examen_Practica.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Examen_Practica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
       private readonly PersonaDbContext _Context;
        public PersonaController(PersonaDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersonas()
        {
            return await _Context.personas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPers(int id)
        {
            
            
                var persona = await _Context.personas.FindAsync(id);

                if (persona == null)
                {
                    return NotFound();
                }
            return persona;
        }

        [HttpPost]
        public async Task<ActionResult<Persona>> PostUser(Persona persona)
        {
            _Context.personas.Add(persona);
            await _Context.SaveChangesAsync();

            return CreatedAtAction("GetPers", new { id = persona.PersonaId }, persona);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Persona persona)
        {
            if (id != persona.PersonaId)
            {
                return BadRequest();
            }

            _Context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var persona = await _Context.personas.FindAsync(id);
            if (persona == null) { return NotFound(); }
            _Context.personas.Remove(persona);
            await _Context.SaveChangesAsync();
            return NoContent();
        }

        private bool PersonaExists(int id)
        {
            return _Context.personas.Any(e => e.PersonaId == id);
        }
    }
}
