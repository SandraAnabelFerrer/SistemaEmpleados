using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using System;

namespace microservDpto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        EmpleadosContext context = new EmpleadosContext();

        // GET: api/<DepartamentoController>
        [HttpGet]
        public async Task<List<Departamento>> Get()
        {
            EmpleadosContext context = new EmpleadosContext();
            List<Departamento> departamento = context.Departamentos.ToList();

            return departamento;
        }

       

        // POST api/<DepartamentoController>
        [HttpPost]
        public void Post(Departamento value)
        {
            Console.WriteLine("Post");
            Console.WriteLine(value);
        }
        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public void Put(int id, Departamento value)
        {
            Console.WriteLine("Put ID : " + id);
            Console.WriteLine(value);
        }
        // DELETE api/<DepartamentoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine("Del ID : " + id);
        }
        [HttpPost("CrearDepartamento")]
        public async Task<IActionResult> CrearDepartamento([FromBody] Departamento departamento)
        {
            try
            {
                context.Departamentos.Add(departamento);
                await context.SaveChangesAsync();

                return Ok(departamento); // Devuelve un departamento creada si es necesario
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }
    }
}