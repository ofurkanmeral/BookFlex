using CleanArt.Application.Abstractions.Messaging.Command;
using System.Windows.Input;

namespace CleanArt.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(
    string Email,
    string FirstName,
    string LastName,
    string Password) : ICommand<Guid>;
