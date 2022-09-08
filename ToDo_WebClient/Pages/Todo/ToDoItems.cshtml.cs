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

        [BindProperty]
        public List<TodoDTO> TodoItems { get; set; }
        [BindProperty]
        public TodoDTO TodoItem { get; set; }

        public async Task<IActionResult> OnGet()
        {
            TodoItems = await _toDoService.GetItemsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostCreateTodo()
        {
            if (ModelState.IsValid)
            {
                await _toDoService.CreateAsync(TodoItem);
                return RedirectToPage("/Todo/ToDoItems");
            }
            else
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Todo/ToDoItems");
        }

        public async Task<IActionResult> OnPostCompleteTodo(int iD)
        {
            TodoItem = await _toDoService.GetItemByIdAsync(iD);
            TodoItem.Completed = true;
            await _toDoService.Update(TodoItem.ID, TodoItem);
            return RedirectToPage("/Todo/ToDoItems");
        }
    }
}
