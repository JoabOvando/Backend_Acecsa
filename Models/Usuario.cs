using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiACECSA.Models;

public partial class Usuario
{
    [Key]
    public int ID_Usuario { get; set; }

    public string? Nombre { get; set; }

    public string? Password { get; set; }
}
