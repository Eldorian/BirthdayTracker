using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BirthdayTracker.API.Models;
using BirthdayTracker.UI.Data;
using BirthdayTracker.UI.Services;

namespace BirthdayTracker.UI.Pages.Birthdays
{
    public class CreateModel : PageModel
    {
        private readonly IApiClient client;

        public CreateModel(IApiClient client)
        {
            this.client = client;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Birthday Birthday { get; set; }

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