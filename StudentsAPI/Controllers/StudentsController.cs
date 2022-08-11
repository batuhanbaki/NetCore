using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Models;
using StudentsAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<List<PostStudentViewModel>> Get()
        {
            using (var context = new DgAkademiContext())
            {
                var classes = context.Students.Select(data => new PostStudentViewModel()
                {
                    Email = data.Email,
                    Id = data.Id,
                    Name = data.Name
                }).ToList();
                if (classes == null)
                {
                    return NotFound();
                }
                else
                {
                    return classes;
                }
            }

        }



        [HttpPost]
        public ActionResult<PostStudentViewModel> Post(Student student)
        {
            using (var context = new DgAkademiContext())
            {
                if (student != null && student.Name != null)
                {
                    context.Students.Add(student);
                    context.SaveChanges();

                    return new PostStudentViewModel()
                    {
                        Id = student.Id,
                        Email = student.Email,
                        Name = student.Name
                    }; 
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        
        [HttpPut("{id}")]
        public void Put(int id, Student student)
        {

        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
