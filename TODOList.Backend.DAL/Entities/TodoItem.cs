using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOList.Backend.DAL.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsDone { get; set; }
    }
}
