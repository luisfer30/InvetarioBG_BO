
namespace InventoryModels
{
   public class Response<T>
   {
        public bool Success { get; set; } = false;
        public string? Message { get; set; } = string.Empty;
        public T? Data { get; set; }
   }

    public class ErrorModel
    {
        public int StatusCode { get; set; }
        public string TraceId { get; set; } = string.Empty;
    }
}
