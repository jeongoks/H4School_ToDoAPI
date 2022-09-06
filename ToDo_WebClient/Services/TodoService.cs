using ToDo_WebClient.Models;

namespace ToDo_WebClient.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;
        IHttpContextAccessor _httpContextAccessor;

        public TodoService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri(AppConstants.BaseUrl);
        }

        public async Task<TodoDTO> CreateAsync(TodoDTO todo)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(AppConstants.TodoAPI, todo);
            httpResponse.EnsureSuccessStatusCode();
            TodoDTO createdTodo = await httpResponse.Content.ReadFromJsonAsync<TodoDTO>();
            return createdTodo;
        }

        public async Task Update(int id, TodoDTO todo)
        {
            var httpResponse = await _httpClient.PutAsJsonAsync($"{AppConstants.TodoAPI}/{id}", todo);
            httpResponse.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var httpResponse = await _httpClient.DeleteAsync($"{AppConstants.TodoAPI}/{id}");
            httpResponse.EnsureSuccessStatusCode();
        }

        public async Task<TodoDTO> GetItemByIdAsync(int id)
        {
            TodoDTO toDoItem = await _httpClient.GetFromJsonAsync<TodoDTO>($"{AppConstants.TodoAPI}/{id}");
            return toDoItem;
        }

        public async Task<List<TodoDTO>> GetItemsAsync()
        {
            List<TodoDTO> toDoItems = await _httpClient.GetFromJsonAsync<List<TodoDTO>>($"{AppConstants.TodoAPI}/notComplete");
            return toDoItems;
        }
    }
}
