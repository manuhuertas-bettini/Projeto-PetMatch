using System;
using System.Collections.Generic;

namespace Projeto_PetMatch_MVC.Models;

public partial class usuario
{
    public int id { get; set; }

    public string nome { get; set; } = null!;

    public string email { get; set; } = null!;

    public string senha { get; set; } = null!;

    public string? telefone { get; set; }

    public DateTime? criado_em { get; set; }

    public string perfil { get; set; } = null!;

    public virtual ICollection<animai> animais { get; set; } = new List<animai>();
}
