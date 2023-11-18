﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace fitzestApiRest.Models;

public partial class Ingrediente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public decimal? Calorias { get; set; }

    public decimal? Proteinas { get; set; }

    public decimal? Peso { get; set; }

    [JsonIgnore]
    public virtual ICollection<PrepararComida> Prepararcomidas { get; set; } = new List<PrepararComida>();
}

