using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODOList.Backend.Api.Models;
using TODOList.Backend.Api.Services;

namespace TODOList.Backend.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<List<TodoItemModel>> GetTodoList(int skip = 0, int take = 10)
            => await _todoService.GetTodoList(skip, take);

        [HttpPost]
        public async Task<int> AddTodoItem(CreateTodoItemModel model)
            => await _todoService.AddTodoItemToList(model);

        [HttpPost]
        public async Task UpdateItemStatus(int id)
            => await _todoService.UpdateItemStatus(id);

        [HttpDelete]
        public async Task DeleteTodoItem(int id)
            => await _todoService.DeleteItem(id);
    }
}
