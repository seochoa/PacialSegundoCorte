using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial.Models
{
    public class PersonaInputModel
    {
        
        public string Tipodocumeto {get; set;}
        public string Documento {get; set;}
        public string Nombre {get; set;}
        public DateTime Fechanac {get; set;}
        public string Institucion {get; set;}
        public string Nombreacudiente {get; set;}
        public List<Vacuna> Vacunas {get; set;}
    }

    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel()
        {

        }
        public PersonaViewModel(Persona persona)
        {
            Tipodocumeto = persona.Tipodocumeto;
            Documento = persona.Documento;
            Nombre= persona.Nombre;
            Fechanac = persona.Fechanac;
            Institucion = persona.Institucion;
            Nombreacudiente = persona.Nombreacudiente;
            Vacunas = persona.Vacunas;
            
        }
        
    }
}