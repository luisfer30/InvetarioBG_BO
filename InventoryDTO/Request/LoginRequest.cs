namespace InventoryModels.Request
{
    public class LoginRequest
    {
        public required string Correo { get; set; }
        public required string Password { get; set; }
    }
}
