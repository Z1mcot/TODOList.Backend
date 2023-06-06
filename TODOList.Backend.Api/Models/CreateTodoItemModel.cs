using System.ComponentModel.DataAnnotations;

namespace TODOList.Backend.Api.Models
{
    public class CreateTodoItemModel
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
