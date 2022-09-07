using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using ToDoAPI;
using ToDoAPI.Context;
using ToDoAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("ToDoList")) ;
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

string domain = $"https://{builder.Configuration["Auth0:Domain"]}/";

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = domain;
        options.Audience = builder.Configuration["Auth0:Audience"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = ClaimTypes.NameIdentifier
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

var app = builder.Build();

#region GET => "Hello, World!"
app.MapGet("/", () => "Hello, World!");
#endregion

#region GET => All To-do items.
app.MapGet("/todoitems", async (TodoDb db) => 
    await db.Todos.ToListAsync()).RequireAuthorization();
#endregion

#region GET => Not completed To-do items.
app.MapGet("/todoitems/notComplete", async (TodoDb db) =>
    await db.Todos.Where(t => t.Completed == false).ToListAsync()).RequireAuthorization();
#endregion

#region GET => To-do item by ID.
app.MapGet("/todoitems/{ID}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
    is Todo todo
        ? Results.Ok(todo)
        : Results.NotFound()).RequireAuthorization();
#endregion

#region POST => Add new To-do item.
app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.ID}", todo);
}).RequireAuthorization();
#endregion

#region PUT => To-do item by ID.
app.MapPut("/todoitems/{ID}", async (int id, Todo inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.Description = inputTodo.Description;
    todo.Priority = inputTodo.Priority;
    todo.Completed = inputTodo.Completed;

    await db.SaveChangesAsync();

    return Results.NoContent();
});
#endregion

#region DELETE => To-do item by ID.
app.MapDelete("/todoitems/{ID}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }

    return Results.NotFound();
});
#endregion

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(o => {
    o.AllowAnyOrigin();
    o.AllowAnyHeader();
    o.AllowAnyMethod();
});

app.UseAuthentication();
app.UseAuthorization();

app.Run();