using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidad
{
    public class Persona
    {
        [Key]
        [Column (TypeName = "nvarchar(20)")]
        public string Documento {get; set;}
        [Column (TypeName = "nvarchar(5)")]
        public string Tipodocumeto {get; set;}
        
        [Column (TypeName = "nvarchar(20)")]
        public string Nombre {get; set;}
        public DateTime Fechanac {get; set;}
        [Column (TypeName = "nvarchar(20)")]
        public string Institucion {get; set;}
        [Column (TypeName = "nvarchar(20)")]
        public string Nombreacudiente {get; set;}
        public  List<Vacuna> Vacunas {get; set;}
    }
}