using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiACECSA.Models;

public partial class Vehiculo
{
    [Key]
    public int IdVehiculo { get; set; }

    public string? Tipo { get; set; }

    public string? Descripcion { get; set; }
}
