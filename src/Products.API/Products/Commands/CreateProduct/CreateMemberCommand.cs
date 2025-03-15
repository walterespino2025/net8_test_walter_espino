using Products.Application.Abstractions.Messaging;

namespace Products.Application.Members.Commands.CreateMember;

public sealed record CreateMemberCommand(
    string Name) : ICommand;