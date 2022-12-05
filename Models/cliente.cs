using System.ComponentModel.DataAnnotations;

namespace app_house.Models
{
    public class Cliente{
        [Key]
        public int Clienteid {get ; set;}
        [Display( Name ="nombre del cliente")]
        [Required( ErrorMessage = "Es necesario completar esto")]
        [MaxLength(30, ErrorMessage = "Maximo 30 caracteres")]
        [RegularExpression(@"[A-Z\s]*$", ErrorMessage = "Solo mayusculas y espacios")]
        public string? Clientename { get; set;}
        [Display( Name ="apellido del cliente")]
        [Required( ErrorMessage = "Es necesario completar esto")]
        [MaxLength(30, ErrorMessage = "Maximo 30 caracteres")]
        [RegularExpression(@"[A-Z\s]*$", ErrorMessage = "Solo mayusculas y espacios")]
        public string? Clienteapellido { get; set;}

         [Display(Name = "numero de DNI")]
         [Required(ErrorMessage = "Es necesario completar esto")]
         [RegularExpression(@"[0-9\d]*$", ErrorMessage = "Solo numeros")]
        public int DNI { get; set;}
        [Display(Name = "fecha de nacimiento")]
        [Required(ErrorMessage = "Es necesario completar esto")]
        [DataType(DataType.Date)]
        public DateTime Fechanacimiento { get; set;}

        [Display(Name ="Localidad")]
        public int Localidadid { get; set; }

        public virtual Localidad? Localidad { get; set; }

    }
}