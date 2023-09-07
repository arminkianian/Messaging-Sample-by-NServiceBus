namespace Messages
{
    public class RegisterUserCommand : ICommand
    {
        public string Username { get; set; }
    }
}