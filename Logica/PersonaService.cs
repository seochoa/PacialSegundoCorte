using System.Resources;
using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Logica
{
    public class PersonaService
    {
        private readonly PersonaContext _context;

        public PersonaService(PersonaContext context){
            _context=context;
        }

        public GuardarPersonaResponse Guardar(Persona persona){
            try{
                var Personabuscada = _context.Personas.Find(persona.Documento);
                if(Personabuscada!=null){
                    return new GuardarPersonaResponse ("Error La Persona Ya se encuentra registrada");
                }

                _context.Personas.Add(persona);
                _context.SaveChanges();
                return new GuardarPersonaResponse (persona);

            }
            catch(Exception e){
                return new GuardarPersonaResponse ($"Error de la aplicacion: {e.Message}");
            }
        }

        public Persona BuscarPorID(string idpersona){
            Persona persona = _context.Personas.Find(idpersona);
            return persona;
        }

        public List<Persona> ConsultarTodos(){
            List<Persona> personas = _context.Personas.ToList();
            
            return personas;
        }

       

    }

    public class GuardarPersonaResponse
    {
        public GuardarPersonaResponse(Persona persona)
        {
            Error = false;
            Persona = persona;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Persona Persona { get; set; }
    }
}