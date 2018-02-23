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
    public class IndexModel : PageModel
    {
        private readonly IApiClient client;

        public IndexModel(IApiClient client)
        {
            this.client = client;
        }

        public IList<Birthday> Birthdays { get;set; }

        public async Task OnGetAsync()
        {
            Birthdays = await client.GetBirthdays();
        }
    }
}
