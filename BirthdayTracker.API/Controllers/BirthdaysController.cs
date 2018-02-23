using System.Linq;
using System.Threading.Tasks;
using BirthdayTracker.API.Data;
using BirthdayTracker.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BirthdayTracker.API.Controllers
{
    [Route("api/[controller]")]
    public class BirthdaysController : Controller
    {
        private readonly BirthdayContext context;

        public BirthdaysController(BirthdayContext context)
        {
            this.context = context;
        }

        // GET api/birthdays
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var birthdays = await context.Birthdays
                .AsNoTracking()
                .ToListAsync();
            return Ok(birthdays);
        }

        // GET api/birthdays/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var birthday = await context.Birthdays.FindAsync(id);
            return Ok(birthday);
        }

        // POST api/birthdays
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Birthday value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Birthdays.Add(value);
            await context.SaveChangesAsync();

            return Ok();
        }

        // PUT api/birthdays/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Birthday value)
        {
            if (!context.Birthdays.Any(x => x.Id == id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Birthdays.Update(value);
            await context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/birthdays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var birthday = await context.Birthdays.FindAsync(id);

            if (birthday == null)
            {
                return NotFound();
            }

            context.Birthdays.Remove(birthday);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}