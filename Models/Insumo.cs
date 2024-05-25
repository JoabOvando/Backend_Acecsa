using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiACECSA.Models;

public partial class Insumo
{
    [Key]
    public int IdInsumo { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }
}
