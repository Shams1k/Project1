using System;
using System.ComponentModel.DataAnnotations;

namespace LessonApplication.Models.Users
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
