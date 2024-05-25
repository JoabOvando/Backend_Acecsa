using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiACECSA.Models;

public partial class AsignacionRecurso
{
    [Key]
    public int IdAsignacion { get; set; }

    public int? IdRecurso { get; set; }

    public int? IdCharla { get; set; }

}
