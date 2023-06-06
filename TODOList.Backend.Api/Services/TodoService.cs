using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TODOList.Backend.Api.Models;
using TODOList.Backend.DAL;
using TODOList.Backend.DAL.Entities;

namespace TODOList.Backend.Api.Services
{
    public class TodoService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TodoService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TodoItemModel>> GetTodoList(int skip, int take)
        {
            var dbModels = await _context.TodoItems.AsNoTracking()
                                                   .Skip(skip)
                                                   .Take(take)
                                                   .ToListAsync();

            return _mapper.Map<List<TodoItemModel>>(dbModels);
        }

        public async Task<int> AddTodoItemToList(CreateTodoItemModel model)
        {
            var dbModel = _mapper.Map<TodoItem>(model);
            try
            {
                await _context.AddAsync(dbModel);
                await _context.SaveChangesAsync();

                return dbModel.Id;
            } 
            catch (DbUpdateException)
            {
                throw new Exception("Entry with the same name already exists");
            }
        }

        public async Task UpdateItemStatus(int id)
        {
            var dbModel = await _context.TodoItems.FirstOrDefaultAsync(item => item.Id == id)
                ?? throw new Exception("List item not found");

            dbModel.IsDone = !dbModel.IsDone;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(int id)
        {
            var dbModel = await _context.TodoItems.FirstOrDefaultAsync(item => item.Id == id)
                ?? throw new Exception("List item not found");

            _context.Remove(dbModel);
            await _context.SaveChangesAsync();
        }
    }
}
