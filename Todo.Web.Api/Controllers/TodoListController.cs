using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Todo.Application.Services;
using Todo.Domain.Services;
using Todo.Web.Api.Models;
using Todo.Web.Api.Models.TodoList;

namespace Todo.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListService _todoListService;
        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById([FromRoute, Required] int? id)
        {
            if (id == null)
            {
                return BadRequest("Invalid id");
            }

            var list = _todoListService.GetTodoList(id.GetValueOrDefault());
            if (list == null)
            {
                return BadRequest("Todo List wit this id was not found");
            }

            return Ok(new { list.Id, list.Description, list.IsActive });
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll(int userID)
        {
            var list = _todoListService.GetTodoLists(userID);
            if (list == null)
            {
                return BadRequest("You have no todos!");
            }

            return Ok(
                list
                .Select(list => new { list.Id, list.Description, list.IsActive })
                .ToArray());
        }

        [HttpPost("CreateTodoList")]
        public IActionResult CreateTodoList([FromBody] CreateTodoListInput todoList, int userID)
        {
            if (string.IsNullOrEmpty(todoList.Description))
            {
                return BadRequest("Invalid input parameters");
            }

            _todoListService.Create(userID, todoList.Description);

            return Ok();
        }

        [HttpPut("UpdateTodoList/{id}")]
        public IActionResult UpdateUser([FromRoute] int? id, [FromBody] UpdateTodoListInput todoList)
        {
            if (id is null
                || string.IsNullOrEmpty(todoList.Description))
            {
                return BadRequest("Invalid input parameters");
            }

            _todoListService.Update(
                id.GetValueOrDefault(),
                todoList.Description,
                todoList.IsActive,
                null);

            return Ok();
        }

        [HttpDelete("DeleteTodoList/{id}")]
        public IActionResult DeleteUser([FromRoute] int? id)
        {
            if (id is null)
            {
                return BadRequest("Invalid id provided");
            }

            _todoListService.Delete(id.GetValueOrDefault());

            return Ok();
        }
    }
}
