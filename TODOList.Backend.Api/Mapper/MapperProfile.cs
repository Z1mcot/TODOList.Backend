using AutoMapper;
using TODOList.Backend.Api.Models;
using TODOList.Backend.DAL.Entities;

namespace TODOList.Backend.Api.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<TodoItem, TodoItemModel>();

            CreateMap<CreateTodoItemModel, TodoItem>()
                .ForMember(d => d.IsDone, m => m.MapFrom(s => false));
        }
    }
}
