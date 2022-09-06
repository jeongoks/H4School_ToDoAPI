using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Context
{
    class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder _modelBuilder)
        {            
            _modelBuilder.Entity<Todo>().HasData(
                new Todo { ID = 1, Name = "Homework", Description = "Math, English", CreatedTime = DateTime.Now, Priority = Priority.High, Completed = false});
        }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
