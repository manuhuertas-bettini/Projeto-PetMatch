using System;
using System.Collections.Generic;

namespace Projeto_PetMatch_MVC.Models;

public partial class animai
{
    public int id { get; set; }

    public int usuario_id { get; set; }

    public string nome { get; set; } = null!;

    public string especie { get; set; } = null!;

    public string idade { get; set; } = null!;

    public string descricao { get; set; } = null!;

    public string localizacao { get; set; } = null!;

    public bool? vacinado { get; set; }

    public string? status { get; set; }

    public string foto_url { get; set; } = null!;

    public DateTime? criado_em { get; set; }

    public virtual usuario usuario { get; set; } = null!;
}
