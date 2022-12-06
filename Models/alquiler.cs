using System.ComponentModel.DataAnnotations;

namespace app_house.Models
{
    public class Alquiler
    {
        [Key]
        public int Alquilerid {get;set;}
        [Display(Name ="fecha de alquiler")]
        [DataType(DataType.Date)]
        public DateTime FechaAlquiler { get; set; }
        
        [Display(Name ="Cliente")]
        public int Clienteid { get; set; }

        [Display(Name ="Casa")]
        public int Casaid { get; set; }

        [Display(Name ="nombre del cliente")]
        public string? Clientename { get; set; }

       [Display(Name ="nombre de la casa")]
        public string? Casaname { get; set; }

        [Display(Name= "Monto total")]
        public int MontoTotal { get; set; }

        public byte[]? imagencasa { get; set; }
        
        public virtual Casa? Casa { get; set; }
        public virtual Cliente? Cliente { get; set; }
    
    }
}