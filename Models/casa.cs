using System.ComponentModel.DataAnnotations;

namespace app_house.Models
{
    public class Casa
    {
        [Key]
        public int Casaid { get; set; }

        [Display(Name = "Nombre del dueño de la casa")]
        [Required(ErrorMessage = "Es necesario completar esto")]
        [MaxLength(30, ErrorMessage = "Es demaciado largo solo se admite 30 caracteres")]
        [RegularExpression(@"[A-Z\s]*$", ErrorMessage = "Solo mayusculas y espacios")]
        public string? Dueñoname { get; set; }

        [Display (Name ="Domicilio")]
        [Required( ErrorMessage = "Es necesario completar esto")]
        [MaxLength(30, ErrorMessage ="Es demaciado largo solo se admite 30 caracteres")]
        [RegularExpression(@"[A-Z\s\d]*$", ErrorMessage = "Solo mayuculas, espacios y numeros")]
        public string? Domicilio { get; set; }

        [Display(Name ="Nombre de la casa")]
        [Required( ErrorMessage = "Es necesario completar esto")]
        [MaxLength(30, ErrorMessage ="Es demaciado largo solo se admite 30 caracteres")]
        [RegularExpression(@"[A-Z\s]*$", ErrorMessage = "Solo mayusculas y espacios")]
        public string? Casaname { get; set; }
        public byte[]? imagencasa { get; set; }
       //metros cuadrados
       [Display(Name ="Metros Cuadrados")]
       [Required( ErrorMessage ="Es necesario completar esto")]
       [RegularExpression(@"[\d]*$", ErrorMessage ="solo numeros")]
        public int metros { get; set; }
        // Monto fijo
        [Display(Name ="Monto Fijo")]
        [Required( ErrorMessage ="Es necesario completar esto")]
        public int MontoF { get; set;}

        public bool eliminada { get; set; }
        public bool alquilada { get; set; }
        
        [Display(Name ="Localidad")]
        public int Localidadid { get; set; }

        public virtual Localidad? Localidad { get; set; }
    }
}