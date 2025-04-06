using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.Repository;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDo : ControllerBase
    {
        private readonly IToDoRepository _repository;
        public ToDo(IToDoRepository repository)
        {
            _repository = repository;
            
        }
        [HttpGet] 
        public IActionResult GetItems()
        {
            return Ok(_repository.GetAll());    
        }
        [HttpPost]
        public IActionResult AddItems([FromBody] TodoItems todoItems)
        {
            return Ok(_repository.AddItem(todoItems));

        }
    }
}
