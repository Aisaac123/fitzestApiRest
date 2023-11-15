using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace fitzestApiRest.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public decimal? Calorias { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? Fechafinalizacion { get; set; }

    [JsonIgnore]
    public int? IdDieta { get; set; }
    [JsonIgnore]
    public virtual Dieta? Dieta { get; set; }
}


