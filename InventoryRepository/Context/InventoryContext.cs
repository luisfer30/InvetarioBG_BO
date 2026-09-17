using InventoryRepository.DataModels;
using Microsoft.EntityFrameworkCore;

namespace InventoryRepository.Context;

public partial class InventoryContext : DbContext
{
    public InventoryContext()
    {
    }

    public InventoryContext(DbContextOptions<InventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Marcas> Marcas { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Proveedores> Proveedores { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1C5E52E5B84");

            entity.HasIndex(e => e.Nombre, "UQ__Categori__75E3EFCF3D19DA76").IsUnique();

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Marcas>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK__Marcas__D5B1CDEBE8091C84");

            entity.HasIndex(e => e.Nombre, "UQ__Marcas__75E3EFCF24FEDBB7").IsUnique();

            entity.Property(e => e.MarcaId).HasColumnName("MarcaID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PaisOrigen).HasMaxLength(100);
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC0734A8FDD6");

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");
            entity.Property(e => e.MarcaId).HasColumnName("MarcaID");
            entity.Property(e => e.Modelo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Categorias");

            entity.HasOne(d => d.Marca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.MarcaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Productos_Marcas");
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proveedo__3214EC075C7545E7");

            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => new { e.ProductoId, e.ProveedorId }).HasName("PK__Stock__2222C838C2FCF4BD");

            entity.ToTable("Stock");

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Producto).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PP_Productos");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PP_Proveedores");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC070824C298");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
