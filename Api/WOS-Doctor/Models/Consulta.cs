using System;
using System.Collections.Generic;

namespace WOS_Doctor.MODELS;

public partial class Consulta
{
    public int ConsultaId { get; set; }

    public int? MedicoId { get; set; }

    public int? EspecialidadeId { get; set; }

    public int? PacienteId { get; set; }

    public string? Procedimento { get; set; }

    public DateOnly? DataConsulta { get; set; }

    public virtual Especialidade? Especialidade { get; set; }

    public virtual ICollection<Medicamento> Medicamentos { get; set; } = new List<Medicamento>();

    public virtual Medico? Medico { get; set; }

    public virtual Paciente? Paciente { get; set; }
}
