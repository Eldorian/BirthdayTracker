using System.Threading.Tasks;
using BirthdayTracker.API.Models;
using BirthdayTracker.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirthdayTracker.UI.Pages.Birthdays
{
    public class CreateModel : PageModel
    {
        private readonly IApiClient client;

        public CreateModel(IApiClient client)
        {
            this.client = client;
        }

        [BindProperty] public Birthday Birthday { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await client.AddBirthday(Birthday);

            return RedirectToPage("./Index");
        }
    }
}