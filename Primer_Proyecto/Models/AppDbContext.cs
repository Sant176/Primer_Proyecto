using Microsoft.EntityFrameworkCore;
using WebEmpresa.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Venta>  Venta{ get; set; }
    public DbSet<DetalleVenta> DetalleVentas { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Marca la clase DetalleVentaViewModel como sin clave primaria
        modelBuilder.Entity<DetalleVentaViewModel>().HasNoKey();
    }


}

