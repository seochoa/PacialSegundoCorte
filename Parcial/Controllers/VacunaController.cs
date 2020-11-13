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
    public class VacunaController : ControllerBase
    {
        private readonly PersonaService _personaservice;
        public VacunaController(PersonaContext context){
            _personaservice = new PersonaService(context);
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

        private Vacuna MapearVacuna(VacunaInputModel vacunaInput){
            var Vacuna = new Vacuna
            {
                Idvacuna = vacunaInput.Idvacuna,
                Tipovacuna = vacunaInput.Tipovacuna,
                Fechavacuna = vacunaInput.Fechavacuna,
                Edadaplicacion = vacunaInput.Edadaplicacion,

            };
            return Vacuna;
        }
        
    }
}