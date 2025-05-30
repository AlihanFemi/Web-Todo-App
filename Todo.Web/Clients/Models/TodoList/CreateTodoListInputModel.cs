﻿using System.ComponentModel.DataAnnotations;

namespace Todo.Web.Clients.Models.TodoList
{
    public class CreateTodoListInputModel
    {
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
