namespace Todo.Web.Api.Models.User
{
    public class CreateUserInput
    {
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
    }
}
