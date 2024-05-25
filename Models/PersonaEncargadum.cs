using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiACECSA.Models;

public partial class PersonaEncargadum
{
    [Key]
    public int ID_Encargado { get; set; }

    public int? ID_Empleado { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

}
