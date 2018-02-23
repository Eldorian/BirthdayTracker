using System.Collections.Generic;
using System.Threading.Tasks;
using BirthdayTracker.API.Models;
using BirthdayTracker.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirthdayTracker.UI.Pages.Birthdays
{
    public class IndexModel : PageModel
    {
        private readonly IApiClient client;

        public IndexModel(IApiClient client)
        {
            this.client = client;
        }

        public IList<Birthday> Birthdays { get; set; }

        public async Task OnGetAsync()
        {
            Birthdays = await client.GetBirthdays();
        }
    }
}