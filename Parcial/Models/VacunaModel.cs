using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Parcial.Models
{
    public class VacunaInputModel
    {
        
        public string Idvacuna {get; set;}
        public string Tipovacuna {get; set;}
        public DateTime Fechavacuna {get; set;}
        public int Edadaplicacion {get; set;}
    }

    public class VacunaViewModel : VacunaInputModel
    {
        public VacunaViewModel()
        {

        }
        public VacunaViewModel(Vacuna vacuna)
        {
            Idvacuna = vacuna.Idvacuna;
            Tipovacuna = vacuna.Tipovacuna;
            Fechavacuna = vacuna.Fechavacuna;
            Edadaplicacion = vacuna.Edadaplicacion;
            
        }
        
    }
}