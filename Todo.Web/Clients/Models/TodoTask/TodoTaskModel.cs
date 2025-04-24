namespace Todo.Web.Clients.Models.TodoTask
{
    public class TodoTaskModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
    }
}
