using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayTracker.Backservice.Models;

namespace BirthdayTracker.Backservice.Repository
{
    public class Repository
    {
        private List<Birthday> Birthdays = new List<Birthday>
        {
            new Birthday
            {
                Id = 1,
                FirstName = "Jennifer",
                LastName = "Cook",
                Birthdate = new DateTime(2018, 4, 21),
                Relationship = "Wife"
            },
            new Birthday
            {
                Id = 2,
                FirstName = "Mary",
                LastName = "DeYeager",
                Birthdate = new DateTime(2018, 2, 11),
                Relationship = "Mother"
            },
            new Birthday
            {
                Id = 3,
                FirstName = "Eric",
                LastName = "Currin",
                Birthdate = new DateTime(2018, 9, 30),
                Relationship = "Friend"
            }
        };

        public List<Birthday> Get()
        {
            return Birthdays;
        }
        public Birthday Get(int id)
        {
            return Birthdays.First(t => t.Id == id);
        }

        public void Add(Birthday newBirthday)
        {
            Birthdays.Add(newBirthday);
        }

        public void Update(Birthday birthdayToUpdate)
        {
            Birthdays.Remove(Birthdays.First(t => t.Id == birthdayToUpdate.Id));
            Add(birthdayToUpdate);
        }

        public void Remove(int id)
        {
            Birthdays.Remove(Birthdays.First(t => t.Id == id));
        }
    }
}
