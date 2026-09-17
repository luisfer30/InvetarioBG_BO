using System;
using System.Collections.Generic;

namespace InventoryRepository.DataModels;

public partial class Productos
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Modelo { get; set; }

    public int CategoriaId { get; set; }

    public int MarcaId { get; set; }

    public virtual Categorias Categoria { get; set; } = null!;

    public virtual Marcas Marca { get; set; } = null!;

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
