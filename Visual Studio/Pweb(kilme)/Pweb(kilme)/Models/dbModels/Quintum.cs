using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pweb_kilme_.Models.dbModels;

[Table("quinta", Schema = "pwebdb")]
[Index("IdImagen", Name = "IdImagen")]
[Index("IdRedes", Name = "IdRedes")]
[Index("PrecioPorPersona", Name = "PrecioReservacion")]
public partial class Quintum
{
    public int PrecioPorPersona { get; set; }

    [StringLength(50)]
    public string Direccion { get; set; } = null!;

    public int IdRedes { get; set; }

    [Key]
    public int IdQuinta { get; set; }

    public int IdImagen { get; set; }

    [InverseProperty("IdQuintaNavigation")]
    public virtual ICollection<Datosreservacion> Datosreservacions { get; set; } = new List<Datosreservacion>();

    [ForeignKey("IdImagen")]
    [InverseProperty("Quinta")]
    public virtual Imgsquintum IdImagenNavigation { get; set; } = null!;

    [ForeignKey("IdRedes")]
    [InverseProperty("Quinta")]
    public virtual Redessociale IdRedesNavigation { get; set; } = null!;
}
