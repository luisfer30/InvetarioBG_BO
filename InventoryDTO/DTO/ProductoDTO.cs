namespace InventoryModels.DTO
{
    public class ProductoDTO
    {
        public Guid Id { get; set; }
        public string Objeto { get; set; } = string.Empty;
        public long Cantidad { get; set; } = 0;
        public List<string> Colores { get; set; } = [];
        public bool Estado { get; set; } = false;
    }
    

    public enum Colores
    {
        Rojo = 1,
        Verde = 2,
        Azul = 3,
        Amarillo = 4,
        Negro = 5,
        Plata = 6,
        Blanco = 7
    }

}
