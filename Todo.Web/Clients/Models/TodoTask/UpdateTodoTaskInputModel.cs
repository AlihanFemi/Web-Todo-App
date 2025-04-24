namespace Todo.Web.Clients.Models.TodoTask
{
    public class UpdateTodoTaskInputModel
    {
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
