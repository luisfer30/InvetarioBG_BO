# Inventory API

API REST desarrollada en **ASP.NET Core** para la gestión de productos, proveedores y stock de un sistema de inventario.

El proyecto fue desarrollado como parte de un challenge Full Stack utilizando:

- .NET Core
- Entity Framework Core
- SQL Server
- JWT
- Swagger
- Serilog

---

## Funcionalidades

La API permite:

- Autenticación de usuarios mediante JWT.
- Consulta de productos.
- Registro de productos.
- Actualización de productos.
- Eliminación de productos.
- Consulta de proveedores.
- Gestión de stock por producto y proveedor.
- Manejo de diferentes precios por proveedor.
- Manejo de cantidades de stock por proveedor.
- Registro de logs mediante Serilog.
- Manejo centralizado de errores.
- Documentación de endpoints mediante Swagger.

---

## Arquitectura

El proyecto está organizado en diferentes capas:

```text
InventoryAPI
    |
    |-- Controllers
    |-- Middlewares
    |-- Services
    |-- Dependencies
    |
InventoryRepository
    |
    |-- Repository
    |-- DataModels
    |-- BaseRepository
    |
InventoryModels
    |
    |-- DTO
    |-- Response Models