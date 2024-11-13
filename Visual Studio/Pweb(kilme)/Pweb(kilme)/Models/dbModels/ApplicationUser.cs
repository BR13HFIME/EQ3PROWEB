using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Pweb_kilme_.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Datosreservacion> Datosreservacions { get; set; } = new List<Datosreservacion>();

    }
}
