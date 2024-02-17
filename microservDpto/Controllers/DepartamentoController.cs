using Microsoft.AspNetCore.Mvc;
using Model;
using System;

namespace microservDpto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {

        EmpleadosContext context = new EmpleadosContext();

        private static List<Departamento> departamentos = new List<Departamento>
        {
            new Departamento { Id = 1, Nombre = "Ventas" },
            new Departamento { Id = 2, Nombre = "TI" },
            new Departamento { Id = 3, Nombre = "Recursos Humanos" },
            new Departamento { Id = 4, Nombre = "Contabilidad" },
            new Departamento { Id = 5, Nombre = "Tesorería" },
            new Departamento { Id = 6, Nombre = "Administracion" },
            new Departamento { Id = 7, Nombre = "Marketing" },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Departamento>> GetDepartamentos()
        {
            return Ok(departamentos);
        }
    }
}
