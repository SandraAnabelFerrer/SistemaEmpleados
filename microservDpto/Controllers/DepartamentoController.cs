using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using Microsoft.AspNetCore.Http;

namespace microservDpto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
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
        //[HttpDelete("{id}")]
       // public void Delete(int id)
       // {
        //    Console.WriteLine("Del ID : " + id);
      //  }
        [HttpGet("FiltrarPorDepartamento/{departamentoId}")]
        public async Task<IActionResult> FiltrarPorDepartamento(int departamentoId)
        {
            try
            {
                var departamentosFiltrados = await context.Departamentos
                    .Where(p => p.Id == departamentoId)
                    .Include(p => p.Id) // Incluir la entidad relacionada Persona
                     
                    .ToListAsync();

                return Ok(departamentosFiltrados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
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

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var departamento = await context.Departamentos.FindAsync(id);

                if (departamento == null)
                {
                    return NotFound(); // Retorna un código 404 si la persona no se encuentra
                }

                context.Departamentos.Remove(departamento);
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