using System.ComponentModel.DataAnnotations;

namespace app_house.Models
{
    public class Casa
    {
        [Key]
        public int Casaid { get; set; }

        [Display(Name = "Nombre del dueño de la casa")]
        [Required(ErrorMessage = "Es necesario completar esto")]
        [MaxLength(30, ErrorMessage = "Es demaciado largo maximo 30 caracteres")]
        [RegularExpression(@"[A-Z\s]*$", ErrorMessage = "Solo mayusculas y espacios")]
        public string? Dueñoname { get; set; }

        [Display (Name ="Domicilio")]
        [Required( ErrorMessage = "Es necesario completar esto")]
        [MaxLength(30, ErrorMessage ="Es demaciado largo maximo 30 caracteres")]
        [RegularExpression(@"[A-Z\s\d]*$", ErrorMessage = "Solo mayuculas, espacios y numeros")]
        public string? Domicilio { get; set; }

        [Display]
        public string? CasaName { get; set; }
        public byte[]? imagencasa { get; set; }

        public bool eliminada { get; set; }
        public bool alquilada { get; set; }
    }
}