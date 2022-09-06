using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo_WebClient.Services;
using ToDo_WebClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToDo_WebClient.Pages.Todo
{
    public class ToDoItemsModel : PageModel
    {
        private readonly ITodoService _toDoService;

        public ToDoItemsModel(ITodoService todoService)
        {
            _toDoService = todoService;
        }

        public List<TodoDTO> TodoItems { get; set; }
        [BindProperty]
        public TodoDTO TodoItem { get; set; }

        public async Task<IActionResult> OnGet()
        {
            TodoItems = await _toDoService.GetItemsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                TodoItem = await _toDoService.CreateAsync(TodoItem);
                return RedirectToPage("/Todo/ToDoItems");
            }
            return RedirectToPage("/Todo/ToDoItems");
        }
    }
}
