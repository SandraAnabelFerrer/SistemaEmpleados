using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine("Del ID : " + id);
        }
        [HttpPost("CrearPersona")]
        public async Task<IActionResult> CrearEmpleado([FromBody] Persona persona)
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






    }


}
