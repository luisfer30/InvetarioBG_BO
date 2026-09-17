using AutoMapper;
using InventoryModels.DTO;
using InventoryRepository.DataModels;

namespace InventoryRepository.Converter
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<Productos, ProductoDTO>().ReverseMap();
            CreateMap<Proveedores, ProveedorDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Stock, StockDTO>().ReverseMap();
        }
    }
}
