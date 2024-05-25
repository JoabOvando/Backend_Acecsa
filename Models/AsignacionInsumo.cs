using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiACECSA.Models;

public partial class AsignacionInsumo
{
    [Key]
    public int IdAsignacion { get; set; }

    public int? IdInsumo { get; set; }

    public int? IdCharla { get; set; }

}
