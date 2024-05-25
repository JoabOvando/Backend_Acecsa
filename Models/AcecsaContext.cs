using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiACECSA.Models;

public partial class AcecsaContext : DbContext
{
    public AcecsaContext()
    {
    }

    public AcecsaContext(DbContextOptions<AcecsaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsignacionInsumo> AsignacionInsumo { get; set; }

    public virtual DbSet<AsignacionRecurso> AsignacionRecurso { get; set; }

    public virtual DbSet<AsignacionRol> AsignacionRol { get; set; }

    public virtual DbSet<AsignacionVehiculo> AsignacionVehiculo { get; set; }

    public virtual DbSet<Charla> Charla { get; set; }

    public virtual DbSet<Empleado> Empleado { get; set; }

    public virtual DbSet<Insumo> Insumo { get; set; }

    public virtual DbSet<PersonaEncargadum> Persona_Encargada { get; set; }

    public virtual DbSet<PersonalCharla> PersonalCharla { get; set; }

    public virtual DbSet<Recurso> Recurso { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Vehiculo> Vehiculo { get; set; }

}
