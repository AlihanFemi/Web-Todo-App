using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Todo.Application.Services;
using Todo.Domain.Services;
using Todo.Web.Api.Models.TodoList;
using Todo.Web.Api.Models.TodoTask;

namespace Todo.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private readonly ITodoTaskService _todoTaskService;
        public TodoTaskController(ITodoTaskService todoTaskService)
        {
            _todoTaskService = todoTaskService;
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById([FromRoute, Required] int? id)
        {
            if (id == null)
            {
                return BadRequest("Invalid id");
            }

            var task = _todoTaskService.GetTodoTask(id.GetValueOrDefault());
            if (task == null)
            {
                return BadRequest("Task with this id was not found");
            }

            return Ok(new { task.Id, task.Description, task.DueDate });
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll(int listID)
        {
            var tasks = _todoTaskService.GetAll(listID);
            if (tasks == null)
            {
                return BadRequest("You have no tasks!");
            }

            return Ok(
                tasks
                .Select(task => new { task.Id, task.Description, task.DueDate, task.IsCompleted })
                .ToArray());
        }
        [HttpPost("CreateTodoTask")]
        public IActionResult CreateTodoTask([FromBody] CreateTaskInput todoTask, int listID)
        {
            if (string.IsNullOrEmpty(todoTask.Description))
            {
                return BadRequest("Invalid input parameters");
            }

            _todoTaskService.Create(listID, todoTask.Description, todoTask.DueDate);

            return Ok();
        }
        [HttpPut("UpdateTodoTask/{id}")]
        public IActionResult UpdateTask([FromRoute] int? id, [FromBody] UpdateTaskInput todoTask)
        {
            if (id is null
                || string.IsNullOrEmpty(todoTask.Description))
            {
                return BadRequest("Invalid input parameters");
            }

            _todoTaskService.Update(
                id.GetValueOrDefault(),
                todoTask.Description,
                todoTask.IsCompleted,
                todoTask.DueDate);

            return Ok();
        }
        [HttpDelete("DeleteTodoTask/{id}")]
        public IActionResult DeleteTask([FromRoute] int? id)
        {
            if (id is null)
            {
                return BadRequest("Invalid id provided");
            }

            _todoTaskService.Delete(id.GetValueOrDefault());

            return Ok();
        }
    }
}
