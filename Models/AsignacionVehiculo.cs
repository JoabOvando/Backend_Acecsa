using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiACECSA.Models;

public partial class AsignacionVehiculo
{
    [Key]
    public int IdAsignacion { get; set; }

    public int? IdVehiculo { get; set; }

    public int? IdCharla { get; set; }

}
