using System.ComponentModel.DataAnnotations;

namespace Pweb_kilme_.Models.DTO
{
    public class QuintumDTO
    {
        public int PrecioPorPersona { get; set; }
        public string Direccion { get; set; } = null!;
        public int IdRedes { get; set; }
        public int IdQuinta { get; set; }
        public int IdImagen { get; set; }
        public string Nombre { get; set; } = null!; 
    }
}
