using ToDo.Models;

namespace ToDo.Repository
{
    public interface IToDoRepository
    {
        public List<TodoItems> GetAll();
        public string AddItem(TodoItems item);
    }
}
