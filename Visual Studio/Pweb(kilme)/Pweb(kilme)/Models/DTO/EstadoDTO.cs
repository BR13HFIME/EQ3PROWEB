using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pweb_kilme_.Models.DTO
{
    public class EstadoDTO
    {
        [Required]
        [Display(Name = "Estado")]
        public int IdEstado { get; set; }
        public string Estado1 { get; set; } = null!;

        public SelectList? Estados { get; set; }
    }
}
