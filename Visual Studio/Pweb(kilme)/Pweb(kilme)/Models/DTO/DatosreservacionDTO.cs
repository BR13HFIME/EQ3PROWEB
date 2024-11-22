using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Pweb_kilme_.Models.DTO
{
    public class DatosreservacionDTO
    {
        public int IdReservacion { get; set; }

        public DateOnly Fecha { get; set; }

        public int NumInvitados { get; set; }

        public int IdEstado { get; set; }

        public int IdUsuario { get; set; }

        public int IdQuinta { get; set; }

        public required SelectList Estados { get; set; }
        public required SelectList Quintas { get; set; }
        public required SelectList Usuarios { get; set; }
    }
}
