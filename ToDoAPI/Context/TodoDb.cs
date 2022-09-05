﻿using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

namespace ToDoAPI.Context
{
    class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
