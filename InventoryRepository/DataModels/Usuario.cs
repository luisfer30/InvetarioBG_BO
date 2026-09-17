using System;
using System.Collections.Generic;

namespace InventoryRepository.DataModels;

public partial class Usuario
{
    public Guid Id { get; set; }

    public string Apellidos { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }
}
