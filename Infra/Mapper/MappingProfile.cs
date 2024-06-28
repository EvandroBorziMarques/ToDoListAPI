using AutoMapper;
using Domain.DTO;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<ToDo, ToDoDTO>().ReverseMap();
        }
    }
}
