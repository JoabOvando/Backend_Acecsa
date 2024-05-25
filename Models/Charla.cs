using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiACECSA.Models;

public partial class Charla
{
    [Key]
    public int IdCharla { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Lugar { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Presupuesto { get; set; }

    public int? IdEncargado { get; set; }

    public bool? Estado { get; set; }

    public string? EstadoCharla { get; set; }

}
