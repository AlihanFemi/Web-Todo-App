namespace Todo.Web.Api.Models.TodoTask
{
    public class CreateTaskInput
    {
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
    }
}
