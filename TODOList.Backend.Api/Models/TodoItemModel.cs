using Microsoft.EntityFrameworkCore.Query.Internal;

namespace TODOList.Backend.Api.Models
{
    public class TodoItemModel
    {
        public int Id { get; set; } = default;
        public string Name { get; set; } = "deleted entry";
        public bool IsDone { get; set; } = false;
    }
}
