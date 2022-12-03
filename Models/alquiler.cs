using System.ComponentModel.DataAnnotations;

namespace app_house.Models
{
    public class Alquiler
    {
        [Key]
        public int Alquilerid {get;set;}
        [DataType(DataType.Date)]
        public DateTime FechaAlquiler { get; set; }

        public int Clienteid { get; set; }

        public int CasaID { get; set; }

        public string? Clientename { get; set; }

        public string? CasaNombre { get; set; }
        
        public virtual Casa? Casa { get; set; }
        public virtual Cliente? Cliente { get; set; }
    }
}