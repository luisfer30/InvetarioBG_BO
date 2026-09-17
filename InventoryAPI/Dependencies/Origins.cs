namespace InventoryAPI.Dependencies
{
    public static class Origins
    {
        public static void CORSDI (this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("InventoryOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }
    }
}
