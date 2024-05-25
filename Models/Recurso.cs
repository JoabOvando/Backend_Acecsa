using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiACECSA.Models;

public partial class Recurso
{
    [Key]
    public int ID_Recurso { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }
}
