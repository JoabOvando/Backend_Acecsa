using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiACECSA.Models;

public partial class Rol
{
    [Key]
    public int ID_Rol { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }
}
