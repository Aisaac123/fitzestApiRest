﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace fitzestApiRest.Models;

public partial class Ejercicio
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public decimal? Peso { get; set; }

    public int? Repeticiones { get; set; }

    public string? Descripcion { get; set; }

    public int? Tiempodescanso { get; set; }

    public decimal? Consumocalorias { get; set; }
    public string Img { get; set; }
    
    public virtual ICollection<Detallesrutina> Detallesrutinas { get; set; } = new List<Detallesrutina>();
}