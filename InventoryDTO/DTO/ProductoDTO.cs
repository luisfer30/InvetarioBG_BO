namespace InventoryModels.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Modelo { get; set; }
        public int CategoriaId { get; set; }
        public int MarcaId { get; set; }
    }
}
