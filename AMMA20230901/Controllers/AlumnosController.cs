using AMMA20230901.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMMA20230901.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        static List<Alumno> alumnos = new List<Alumno>();

        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return alumnos;
        }

        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            var alumno = alumnos.FirstOrDefault(a => a.Id == id);
            return alumno;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Alumno alumno)
        {
            alumnos.Add(alumno);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Alumno alumno)
        {
            var existingAlumno = alumnos.FirstOrDefault(a=> a.Id == id);
            if (existingAlumno != null)
            {
                existingAlumno.Nombre = alumno.Nombre;
                existingAlumno.Apellido = alumno.Apellido;
                existingAlumno.Matricula = alumno.Matricula;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAlumno = alumnos.FirstOrDefault(a => a.Id == id);
            if (existingAlumno != null)
            {
                alumnos.Remove(existingAlumno);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
