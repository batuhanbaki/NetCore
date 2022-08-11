using StudentsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAPI.Dtos
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Class Class { get; set; }
    }
}
