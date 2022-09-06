using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo_WebClient.Models;
using ToDo_WebClient.Services;

namespace ToDo_WebClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITodoService _todoService;

        [BindProperty(SupportsGet = true)]
        public TodoDTO TodoItem { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                TodoItem = await _todoService.CreateAsync(TodoItem);
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
            return RedirectToPage("/Index");
        }
    }
}