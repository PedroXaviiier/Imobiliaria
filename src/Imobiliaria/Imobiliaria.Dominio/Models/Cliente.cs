using System;
using System.Collections.Generic;

namespace Imobiliaria.Web;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    public virtual ICollection<Imovei> Imoveis { get; set; } = new List<Imovei>();

    public virtual ICollection<MensagensContato> MensagensContatos { get; set; } = new List<MensagensContato>();
}
