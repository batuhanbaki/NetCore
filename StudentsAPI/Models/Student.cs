using System;
using System.Collections.Generic;



namespace StudentsAPI.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Class Class { get; set; }
    }
}
