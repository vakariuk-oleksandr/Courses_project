using System;

namespace Main_Project.BL.DTO
{
    public class StudentDTO
    {
        public string StudentID { get; set; }
        public string Fullname { get; set; }
        public string City { get; set; }
        public DateTime Birthdate { get; set; }
        public string Teachingtype { get; set; }
        public string Lessons { get; set; }
        public string PhoneNumber { get; set; }
        public int? StudyingformID { get; set; }

        public string Email { get; set; }
    }
}
