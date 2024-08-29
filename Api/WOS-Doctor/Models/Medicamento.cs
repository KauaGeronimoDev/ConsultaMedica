using System;
using System.Collections.Generic;

namespace WOS_Doctor.MODELS;

public partial class Medicamento
{
    public int MedicamentoId { get; set; }

    public int? ConsultaId { get; set; }

    public string? NomeMedicamento { get; set; }

    public string? Dosagem { get; set; }

    public virtual Consulta? Consulta { get; set; }
}
