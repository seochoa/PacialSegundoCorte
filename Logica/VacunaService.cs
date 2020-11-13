using System.Resources;
using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Logica
{
    public class VacunaService
    {
        private readonly VacunaContext _context;

        public VacunaService(VacunaContext context){
            _context=context;
        }

        public GuardarVacunaResponse Guardar(Vacuna vacuna){
            try{
                var Vacunabuscada = _context.Vacunas.Find(vacuna.Idvacuna);
                if(Vacunabuscada !=null){
                    return new GuardarVacunaResponse ("Error La Persona Ya se encuentra registrada");
                }

                _context.Vacunas.Add(vacuna);
                _context.SaveChanges();
                return new GuardarVacunaResponse (vacuna);

            }
            catch(Exception e){
                return new GuardarVacunaResponse ($"Error de la aplicacion: {e.Message}");
            }
        }

        public List<Vacuna> ConsultarTodos(){
            List<Vacuna> vacunas = _context.Vacunas.Include(s=>s.Personavacunada).ToList();
            return vacunas;
        }

        // public Usuario BuscarPorID(string iduser){
            
        //     return usuario;
        // }

    }

    public class GuardarVacunaResponse
    {
        public GuardarVacunaResponse(Vacuna vacuna)
        {
            Error = false;
            Vacuna = vacuna;
        }
        public GuardarVacunaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Vacuna Vacuna { get; set; }
    }
}