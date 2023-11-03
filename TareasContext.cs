using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { set; get; }
    public DbSet<Tarea> Tareas { set; get; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        List<Categoria> categoriasInit = new()
        {
            new() { CategoriaId = Guid.Parse("671e734d-3b8d-4c76-b2df-3f2796e2e9f8"), Nombre = "Actividades pendientes", Peso = 20, Descripcion = "Actividades que se deben realizar en el dia" },
            new() { CategoriaId = Guid.Parse("671e734d-3b8d-4c76-b2df-3f2796e2e902"), Nombre = "Actividades personales", Peso = 50 , Descripcion = "Actividades que se deben realizar en la semana"}
        };

        builder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion);
            categoria.Property(p => p.Peso);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new()
        {
            new Tarea() { TareaId = Guid.Parse("671e734d-3b8d-4c76-b2df-3f2796e2e9f8"), CategoriaId = Guid.Parse("671e734d-3b8d-4c76-b2df-3f2796e2e9f8"), PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.Now , Descripcion = "Pagar antes del 20 de cada mes"},
            new Tarea() { TareaId = Guid.Parse("671e734d-3b8d-4c76-b2df-3f2796e2e902"), CategoriaId = Guid.Parse("671e734d-3b8d-4c76-b2df-3f2796e2e902"), PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de ver pelicula", FechaCreacion = DateTime.Now , Descripcion = "La debo terminar de ver"},
        };

        builder.Entity<Tarea>(tarea =>
        {
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion).HasDefaultValue(DateTime.Now);
            tarea.Property(p => p.Descripcion);
            tarea.Ignore(p => p.Resumen);
            tarea.HasData(tareasInit);

        });



    }

}