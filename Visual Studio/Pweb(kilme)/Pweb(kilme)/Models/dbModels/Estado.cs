using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pweb_kilme_.Models.dbModels;

[Table("estado", Schema = "pwebdb")]
public partial class Estado
{
    [Key]
    public int IdEstado { get; set; }

    [Column("estado")]
    [StringLength(50)]
    public string Estado1 { get; set; } = null!;

    [InverseProperty("IdEstadoNavigation")]
    public virtual ICollection<Datosreservacion> Datosreservacions { get; set; } = new List<Datosreservacion>();
}
