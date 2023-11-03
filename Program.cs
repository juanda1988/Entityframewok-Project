using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;
using proyectoef.Models;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
//builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("TareasDb"));
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("DbContext"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbcontext) =>
{
    dbcontext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbcontext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbcontext) =>
{
    return Results.Ok(dbcontext.Tareas.Where(p => p.PrioridadTarea == proyectoef.Models.Prioridad.Baja));
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbcontext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbcontext.Tareas.AddAsync(tarea);
    await dbcontext.SaveChangesAsync();
    await dbcontext.SaveChangesAsync();

    return Results.Ok(tarea);
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbcontext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    var tareaEncontrada = await dbcontext.Tareas.FindAsync(id);

    if (tareaEncontrada != null)
    {
        tareaEncontrada.CategoriaId = tarea.CategoriaId;
        tareaEncontrada.Descripcion = tarea.Descripcion;
        tareaEncontrada.Titulo = tarea.Titulo;
        tareaEncontrada.PrioridadTarea = tarea.PrioridadTarea;

        await dbcontext.SaveChangesAsync();
        return Results.Ok();
    }


    return Results.NotFound();
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbcontext, [FromRoute] Guid id) =>
{
    var tareaEncontrada = await dbcontext.Tareas.FindAsync(id);

    if (tareaEncontrada != null)
    {
        dbcontext.Tareas.Remove(tareaEncontrada);
        await dbcontext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});



app.Run();
