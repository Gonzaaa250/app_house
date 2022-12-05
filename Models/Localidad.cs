using System.ComponentModel.DataAnnotations;

namespace app_house.Models
{
    public class Localidad{
        [Key]
        public int Localidadid { get; set; }
       
       [Display( Name ="Localidad")]
       [Required( ErrorMessage = "Es necesario completar esto")]
       [MaxLength(30, ErrorMessage = "Maximo 30 caracteres")]
       [RegularExpression(@"[A-Z\s]*$", ErrorMessage = "Solo mayusculas y espacios")]
        public string? Localidadname { get; set; }

    }
}