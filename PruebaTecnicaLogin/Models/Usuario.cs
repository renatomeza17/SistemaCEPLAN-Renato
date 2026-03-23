using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaLogin.Models
{

    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Correo { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string Clave { get; set; } = null!;

        // Cuenta cuántas veces se equivocó
        public int? IntentosFallidos { get; set; } = 0;

        // Guarda la fecha y hora exacta hasta la que no puede entrar
        public DateTime? BloqueadoHasta { get; set; }

        // Propiedad calculada: Solo devuelve 'true' si la fecha de bloqueo es mayor a 'ahora'
        public bool EstaBloqueado => BloqueadoHasta.HasValue && BloqueadoHasta.Value > DateTime.Now;
    }
}
