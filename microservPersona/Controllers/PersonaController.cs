using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace microservPersona.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        EmpleadosContext context = new EmpleadosContext();

        // GET: api/<PersonaController>
        [HttpGet]
        public async Task<List<Persona>> Get()

        {
            EmpleadosContext context = new EmpleadosContext();
            List<Persona> personas = context.Personas.ToList();

            return personas;
        }
        // POST api/<PersonaController>
        [HttpPost]
        public void Post(Persona value)
        {
            Console.WriteLine("Post");
            Console.WriteLine(value);
        }
        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public void Put(int id, Persona value)
        {
            Console.WriteLine("Put ID : " + id);
            Console.WriteLine(value);
        }
        // DELETE api/<PersonaController>/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        //    Console.WriteLine("Del ID : " + id);

        // }

        // filtrar por persona
        [HttpGet("FiltrarPorPersona/{personaId}")]
        public async Task<IActionResult> FiltrarPorEmpleado(int personaId)
        {
            try
            {
                var personaFiltrada = await context.Personas
                    .Where(p => p.Id == personaId)
                    .ToListAsync();

                return Ok(personaFiltrada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }



        [HttpPost("CrearPersona")]
        public async Task<IActionResult> CrearPersona([FromBody] Persona persona)
        {
            try
            {
                context.Personas.Add(persona);
                await context.SaveChangesAsync();

                return Ok(persona); // Devuelve la persona creada si es necesario
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var persona = await context.Personas.FindAsync(id);

                if (persona == null)
                {
                    return NotFound(); // Retorna un código 404 si la persona no se encuentra
                }

                context.Personas.Remove(persona);
                await context.SaveChangesAsync();

                return Ok(); // Retorna un código 200 OK si la eliminación es exitosa
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }



    }
}

