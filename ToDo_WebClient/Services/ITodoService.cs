using ToDo_WebClient.Models;

namespace ToDo_WebClient.Services
{
    public interface ITodoService
    {
        /// <summary>
        /// Retrieve all the <see cref="Todo"/> items in the InMemory DB.
        /// </summary>
        /// <returns></returns>
        public Task<List<TodoDTO>> GetItemsAsync();
        /// <summary>
        /// Creating a new <see cref="Todo"/> item.
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        public Task<TodoDTO> CreateAsync(TodoDTO todo);
        /// <summary>
        /// Updating an exisiting <see cref="Todo"/> by the use of <see cref="Todo.ID"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="todo"></param>
        /// <returns></returns>
        public Task Update(int id, TodoDTO todo);
        /// <summary>
        /// Deleting an existing <see cref="Todo"/> by the use of <see cref="Todo.ID"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task Delete(int id);
        /// <summary>
        /// Retrieving an existing <see cref="Todo"/> item by the use of <see cref="Todo.ID"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TodoDTO> GetItemByIdAsync(int id);        
    }
}
