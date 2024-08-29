using System;
using System.Collections.Generic;

namespace WOS_Doctor.MODELS;

public partial class Paciente
{
    public int PacienteId { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();
}
