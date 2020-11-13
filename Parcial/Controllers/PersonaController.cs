using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Datos;
using Parcial.Models;

namespace Parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _personaservice;
        public PersonaController(PersonaContext context){
            _personaservice = new PersonaService(context);
        }

        [HttpPost]
        public ActionResult<PersonaViewModel> post(PersonaInputModel personaInput){
            Persona persona = MapearPersona(personaInput);
            var response = _personaservice.Guardar(persona);
            if (response.Error){
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Persona);
        }

        private Persona MapearPersona(PersonaInputModel personaInput){
            var Persona = new Persona
            {
                Documento = personaInput.Documento,
                Tipodocumeto = personaInput.Tipodocumeto,
                Nombre = personaInput.Nombre,
                Fechanac = personaInput.Fechanac,
                Institucion = personaInput.Institucion,
                Nombreacudiente = personaInput.Nombreacudiente,
                Vacunas = personaInput.Vacunas

            };
            return Persona;
        }

        
    }
}