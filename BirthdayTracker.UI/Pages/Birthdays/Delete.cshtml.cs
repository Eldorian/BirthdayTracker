using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BirthdayTracker.API.Models;
using BirthdayTracker.UI.Data;
using BirthdayTracker.UI.Services;

namespace BirthdayTracker.UI.Pages.Birthdays
{
    public class DeleteModel : PageModel
    {
        private readonly IApiClient client;

        public DeleteModel(IApiClient client)
        {
            this.client = client;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Birthday = await client.GetBirthday(id.Value);

            if (Birthday != null)
            {
                await client.RemoveBirthday(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
