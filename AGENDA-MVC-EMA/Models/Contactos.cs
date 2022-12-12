using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AGENDA_MVC_EMA.Models
{
    public class Contactos
    {

        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public int Edad { get; set; }

        public string? Direccion { get; set; }

        public int Telefono { get; set; }

        [Required]
        [ForeignKey("User")]
        public string idUser { get; set; }

        public virtual IdentityUser User { get; set; }



    }
}
