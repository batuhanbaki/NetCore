using AutoMapper;
using StudentsAPI.Dtos;
using StudentsAPI.Models;
using StudentsAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAPI.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PostStudentViewModel, Student>();
            CreateMap<Student, PostStudentViewModel>();
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>();
            
            CreateMap<Class, ClassDTO>();
            CreateMap<ClassDTO, Class>();
            CreateMap<Class, PostClassViewModel>();
            CreateMap<PostClassViewModel, Class>();
        }
    }
}
