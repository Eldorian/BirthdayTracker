using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayTracker.Backservice.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayTracker.Backservice.Controllers
{
    [Route("api/[controller]")]
    public class BirthdaysController : Controller
    {
        private readonly Repository.Repository repo;
        public BirthdaysController(Repository.Repository repo)
        {
            this.repo = repo;
        }

        // GET api/birthdays
        [HttpGet]
        public IEnumerable<Birthday> Get()
        {
            return repo.Get();
        }

        // GET api/birthdays/5
        [HttpGet("{id}")]
        public Birthday Get(int id)
        {
            return repo.Get(id);
        }

        // POST api/birthdays
        [HttpPost]
        public void Post([FromBody]Birthday value)
        {
            repo.Add(value);
        }

        // PUT api/birthdays/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Birthday value)
        {
            repo.Update(value);
        }

        // DELETE api/birthdays/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Remove(id);
        }
    }
}
