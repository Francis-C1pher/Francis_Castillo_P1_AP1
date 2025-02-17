using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Francis_Castillo_P1_AP1.Components.Models;

public class ParcialModelo
{


    public class Aportes
    {
        [Key]
        public int AporteId { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string Persona { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este campo es requerido")]

        public string Observacion { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este campo es requerido")]

        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public double Monto { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public int AportesId { get; set; }
    } 
}
        
       
    
   



