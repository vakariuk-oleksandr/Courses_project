using Microsoft.AspNetCore.Identity;
using System;

namespace Main_Project.Models
{
    public class User : IdentityUser
    {
        public string Fullname { get; set; }
        public string City { get; set; }
        public DateTime Birthdate { get; set; }
        public string Teachingtype { get; set; }
        public string StudyingformID { get; set; }
        public User() { }
    }
}