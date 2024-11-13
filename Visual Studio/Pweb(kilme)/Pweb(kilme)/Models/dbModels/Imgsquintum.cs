using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pweb_kilme_.Models.dbModels;

[Table("imgsquinta", Schema = "pwebdb")]
public partial class Imgsquintum
{
    [StringLength(255)]
    public string ImgQuinta { get; set; } = null!;

    [Key]
    public int IdImg { get; set; }

    [InverseProperty("IdImagenNavigation")]
    public virtual ICollection<Quintum> Quinta { get; set; } = new List<Quintum>();
}
