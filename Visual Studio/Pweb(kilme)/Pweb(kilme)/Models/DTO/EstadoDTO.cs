using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pweb_kilme_.Models.DTO
{
    public class EstadoDTO
    {
        public int IdEstado { get; set; }
        public string Estado1 { get; set; } = null!;
    }
}
