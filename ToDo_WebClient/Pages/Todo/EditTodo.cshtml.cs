using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using ToDo_WebClient.Models;
using ToDo_WebClient.Services;

namespace ToDo_WebClient.Pages.Todo
{
    public class EditTodoModel : PageModel
    {
        private readonly ITodoService _todoService;

        public EditTodoModel(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [BindProperty(SupportsGet = true)]
        public TodoDTO Todoitem { get; set; }

        public async Task<IActionResult> OnGet(int TodoId)
        {
            Todoitem = await _todoService.GetItemByIdAsync(TodoId);
            return Page();
        }

        public async Task<IActionResult> OnPost(bool editTodo, bool deleteTodo)
        {
            if (ModelState.IsValid)
            {
                if (editTodo)
                {
                    if (Todoitem != null)
                    {                        
                        await _todoService.Update(Todoitem.ID, Todoitem);
                        return RedirectToPage("/Todo/ToDoItems");
                    }
                }
                else if (deleteTodo)
                {
                    await _todoService.Delete(Todoitem.ID);
                    return RedirectToPage("/Todo/ToDoItems");
                }
                return RedirectToPage("/Todo/ToDoItems");
            }
            else
            {
                return Page();
            }
        }
    }
}
