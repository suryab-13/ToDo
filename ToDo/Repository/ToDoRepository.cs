using ToDo.Data;
using ToDo.Models;

namespace ToDo.Repository
{
    public class ToDoRepository : IToDoRepository
    {
      
        ToDoDbcontext obj = new ToDoDbcontext();
        public List<TodoItems> GetAll() { 
            var res =  obj.TodoItems.ToList(); 
            return res;

        }
        public string AddItem(TodoItems item) { 
            obj.TodoItems.Add(item);
            obj.SaveChanges();
            return "Added new Item";
        }
    }
}
