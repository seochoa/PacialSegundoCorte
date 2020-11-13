using System;
using Microsoft.EntityFrameworkCore;
using Entidad;

namespace Datos
{
    public class VacunaContext : DbContext
    {
        public VacunaContext(DbContextOptions options): base(options){
        }
        public DbSet<Vacuna> Vacunas{get;set;}
    }
}