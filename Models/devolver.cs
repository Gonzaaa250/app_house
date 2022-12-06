using System.ComponentModel.DataAnnotations;

namespace app_house.Models
{
    public class Devolver{
        [Key]
        public int Devolverid {get ;set;}

        [Display(Name ="Fecha de Devolucion")]
        [DataType(DataType.Date)]
        public DateTime FechaDevolucion { get; set;}
        [Display(Name ="Alquiler")]
        public int Alquilerid { get; set; }

        [Display(Name ="Cliente")]
        public int Clienteid { get; set;}

        [Display(Name ="Casa")]
        public int Casaid { get; set;}

        [Display(Name ="Nombre del cliente")]
        public string? Clientename { get; set; }
        
        [Display(Name ="nombre de la casa")]
        public string? Casaname { get; set; }

        public virtual Cliente? Cliente { get; set;}
         public virtual Casa? Casa { get; set; }
    }
}