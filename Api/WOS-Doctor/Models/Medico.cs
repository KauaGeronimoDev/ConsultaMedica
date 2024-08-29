using System;
using System.Collections.Generic;

namespace WOS_Doctor.MODELS;

public partial class Medico
{
    public int MedicosId { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();
}
