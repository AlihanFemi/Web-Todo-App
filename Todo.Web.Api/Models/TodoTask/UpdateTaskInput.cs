namespace Todo.Web.Api.Models.TodoTask
{
    public class UpdateTaskInput
    {
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
