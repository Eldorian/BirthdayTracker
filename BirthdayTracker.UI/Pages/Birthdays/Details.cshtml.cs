using System.Threading.Tasks;
using BirthdayTracker.API.Models;
using BirthdayTracker.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirthdayTracker.UI.Pages.Birthdays
{
    public class DetailsModel : PageModel
    {
        private readonly IApiClient client;

        public DetailsModel(IApiClient client)
        {
            this.client = client;
        }

        public Birthday Birthday { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Birthday = await client.GetBirthday(id.Value);

            if (Birthday == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}