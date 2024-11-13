using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pweb_kilme_.Models.dbModels;

[Table("redessociales", Schema = "pwebdb")]
public partial class Redessociale
{
    [StringLength(255)]
    public string RedSoc { get; set; } = null!;

    [Key]
    public int IdRedes { get; set; }

    [InverseProperty("IdRedesNavigation")]
    public virtual ICollection<Quintum> Quinta { get; set; } = new List<Quintum>();
}
