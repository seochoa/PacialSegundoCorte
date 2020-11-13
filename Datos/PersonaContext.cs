using System;
using Microsoft.EntityFrameworkCore;
using Entidad;

namespace Datos
{
    public class PersonaContext : DbContext
    {
        public PersonaContext(DbContextOptions options): base(options){
        }
        public DbSet<Vacuna> Vacunas{get;set;}
        public DbSet<Persona> Personas{get;set;}
    }
}