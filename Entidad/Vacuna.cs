using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidad
{
    public class Vacuna
    {
        [Key]
        [Column (TypeName = "nvarchar(20)")]
        public string Idvacuna {get; set;}
        [Column (TypeName = "nvarchar(20)")]
        public string Tipovacuna {get; set;}
        public DateTime Fechavacuna {get; set;}
        public int Edadaplicacion {get; set;}
        [Column (TypeName = "nvarchar(20)")]
        public Persona Personavacunada {get; set;}
    }
}