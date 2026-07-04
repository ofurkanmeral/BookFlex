using CleanArt.Application.Abstractions.Messaging.Command;

namespace CleanArt.Application.Users.LogInUser;

public sealed record LogInUserCommand(string Email,string Password) : ICommand<AccessTokenResponse>;

