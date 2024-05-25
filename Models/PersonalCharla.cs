using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiACECSA.Models;

public partial class PersonalCharla
{
    [Key]
    public int IdPersonalCharla { get; set; }

    public int? IdCharla { get; set; }

    public int? IdEmpleado { get; set; }

}
