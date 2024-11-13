using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pweb_kilme_.Models.dbModels;

[Table("datosreservacion", Schema = "pwebdb")]
[Index("IdEstado", Name = "IdEstado")]
[Index("IdQuinta", Name = "IdQuinta")]
[Index("IdUsuario", Name = "IdUsuario")]
public partial class Datosreservacion
{
    [Key]
    public int IdReservacion { get; set; }

    public DateOnly Fecha { get; set; }

    public int NumInvitados { get; set; }

    public int IdEstado { get; set; }

    public int IdUsuario { get; set; }

    public int IdQuinta { get; set; }

    [ForeignKey("IdEstado")]
    [InverseProperty("Datosreservacions")]
    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    [ForeignKey("IdQuinta")]
    [InverseProperty("Datosreservacions")]
    public virtual Quintum IdQuintaNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Datosreservacions")]
    public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
}
