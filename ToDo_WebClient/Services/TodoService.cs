using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;
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

        public async Task InitializeHttpClient()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            var idToken = await _httpContextAccessor.HttpContext.GetTokenAsync("id_token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        public async Task<TodoDTO> CreateAsync(TodoDTO todo)
        {
            await InitializeHttpClient();
            var httpResponse = await _httpClient.PostAsJsonAsync(AppConstants.TodoAPI, todo);
            httpResponse.EnsureSuccessStatusCode();
            TodoDTO createdTodo = await httpResponse.Content.ReadFromJsonAsync<TodoDTO>();
            return createdTodo;
        }

        public async Task Update(int id, TodoDTO todo)
        {
            await InitializeHttpClient();
            var httpResponse = await _httpClient.PutAsJsonAsync($"{AppConstants.TodoAPI}/{id}", todo);
            httpResponse.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            await InitializeHttpClient();
            var httpResponse = await _httpClient.DeleteAsync($"{AppConstants.TodoAPI}/{id}");
            httpResponse.EnsureSuccessStatusCode();
        }

        public async Task<TodoDTO> GetItemByIdAsync(int id)
        {
            await InitializeHttpClient();
            TodoDTO toDoItem = await _httpClient.GetFromJsonAsync<TodoDTO>($"{AppConstants.TodoAPI}/{id}");
            return toDoItem;
        }

        public async Task<List<TodoDTO>> GetItemsAsync()
        {
            await InitializeHttpClient();
            List<TodoDTO> toDoItems = await _httpClient.GetFromJsonAsync<List<TodoDTO>>($"{AppConstants.TodoAPI}/notComplete");
            return toDoItems;
        }        
    }
}
