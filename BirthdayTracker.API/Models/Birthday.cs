using System;

namespace BirthdayTracker.API.Models
{
    public class Birthday
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Relationship { get; set; }
    }
}