﻿namespace Todo.Web.Clients.Models.TodoList
{
    public class UpdateTodoListInputModel
    {
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int? NumberOfTasks { get; set; }
    }
}
