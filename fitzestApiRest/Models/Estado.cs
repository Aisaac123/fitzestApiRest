using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace fitzestApiRest.Models;

public partial class Estado
{
    public int Id { get; set; }

    public DateOnly? UltimaModificacion { get; set; } // Cambio de nombre y tipo de dato

    public decimal? LimiteProteina { get; set; } // Nueva propiedad y tipo de dato

    public decimal? LimiteCalorias { get; set; } // Nueva propiedad y tipo de dato

    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
