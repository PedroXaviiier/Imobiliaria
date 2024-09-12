using System;
using System.Collections.Generic;

namespace Imobiliaria.Web;

public partial class Corretore
{
    public int CorretorId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Creci { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Imovei> ImoveiCorretorGestors { get; set; } = new List<Imovei>();

    public virtual ICollection<Imovei> ImoveiCorretorNegocios { get; set; } = new List<Imovei>();

    public virtual ICollection<MensagensContato> MensagensContatos { get; set; } = new List<MensagensContato>();
}
