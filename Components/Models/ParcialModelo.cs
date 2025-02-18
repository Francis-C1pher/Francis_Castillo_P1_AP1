using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Francis_Castillo_P1_AP1.Components.Models;

public class ParcialModelo
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
        [Range(0.01, double.MaxValue, ErrorMessage = "El Monto debe ser mayor a 0.")]   
        public int AportesId { get; set; }
    
}
        
       
    
   



