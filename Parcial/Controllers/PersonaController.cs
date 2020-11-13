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

        [HttpGet("{idpersona}")]
        public ActionResult<PersonaViewModel> get(string idpersona){
            var persona = _personaservice.BuscarPorID(idpersona);
            if(persona == null)return NotFound();
            var personaView = new PersonaViewModel(persona);
            return personaView;
        }
        [HttpGet]
        public IEnumerable<PersonaViewModel> gets(){
            var personas = _personaservice.ConsultarTodos().Select(p=>new PersonaViewModel(p));
            return personas;
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