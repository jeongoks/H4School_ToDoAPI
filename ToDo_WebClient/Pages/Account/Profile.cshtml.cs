using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ToDo_WebClient.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ProfileImage { get; set; }

        public void OnGet()
        {
            Name = User.Identity.Name;
            Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value;
        }
    }
}
