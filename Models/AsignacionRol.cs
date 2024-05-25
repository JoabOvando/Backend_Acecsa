using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiACECSA.Models;

public partial class AsignacionRol
{
    [Key]
    public int IdAsignacion { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdRol { get; set; }

}
