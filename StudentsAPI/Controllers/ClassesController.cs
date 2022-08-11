using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Dtos;
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
    public class ClassesController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        public ClassesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Class> Get()
        {
            using (var context = new DgAkademiContext() )
            {
                return context.Classes.ToList();
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult<Class> Get(int id)
        {
            using (var context = new DgAkademiContext())
            {
                var classes = context.Classes.Where(data => data.Id == id).FirstOrDefault();
                if(classes == null)
                {
                    return NotFound();
                } else
                {
                    return classes;
                }
            }
        }

        [HttpPost]
        public ActionResult<ClassDTO> Post(Class classes)
        {
            using (var context = new DgAkademiContext())
            {
                if (classes != null && classes.Name != null)
                {
                    context.Add(classes);
                    context.SaveChanges();


                    return _mapper.Map<ClassDTO>(classes);
                    /*return new ClassDTO()
                    {
                        Id = classes.Id,
                        Name = classes.Name,
                        Students = classes.Students
                    };
                    */
                } else
                {
                    return BadRequest();
                }
            }
        }


        [HttpPut("{id}")]
        public ActionResult<Class> Put(int id, Class classes)
        {
            using (var context = new DgAkademiContext())
            {
                var data = context.Classes.Where(data => data.Id == id).FirstOrDefault();

                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    data.Name = classes.Name;
                    try
                    {
                        context.Classes.Update(data);
                        context.SaveChanges();
                        return classes;
                    }
                    catch (Exception)
                    {
                        return NotFound();
                    }
                }
            }
        }


        [HttpDelete("{id}")]
        public ActionResult<Class> Delete(int id)
        {
            using (var context = new DgAkademiContext())
            {
                var data = context.Classes.Where(data => data.Id == id).FirstOrDefault();

                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Classes.Remove(data);
                    context.SaveChanges();
                    return data;
                }
            }

        }
    }
}
