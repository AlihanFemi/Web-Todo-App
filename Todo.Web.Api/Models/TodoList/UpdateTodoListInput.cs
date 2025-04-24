namespace Todo.Web.Api.Models.TodoList
{
    public class UpdateTodoListInput
    {
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
