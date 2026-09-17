using System;
using System.Collections.Generic;

namespace InventoryRepository.DataModels;

public partial class Marcas
{
    public int MarcaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? PaisOrigen { get; set; }

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
