using System;
using System.Collections.Generic;

namespace Imobiliaria.Web;

public partial class MensagensContato
{
    public int MensagemId { get; set; }

    public int ImovelId { get; set; }

    public int ClienteId { get; set; }

    public int CorretorId { get; set; }

    public string Mensagem { get; set; } = null!;

    public DateTime DataEnvio { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Corretore Corretor { get; set; } = null!;

    public virtual Imovei Imovel { get; set; } = null!;
}
