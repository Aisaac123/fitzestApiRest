using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace fitzestApiRest.Models;

public partial class PrepararComida
{
    public int Id { get; set; }

    public int? IdRecetas { get; set; }

    public int? IdAlimentos { get; set; }

    public decimal? NumeroIngredientes { get; set; }

    public decimal? Calorias { get; set; }

    public decimal? Proteinas { get; set; }

    public virtual Ingrediente? Ingrediente { get; set; }

    public virtual Receta? Receta { get; set; }
}
