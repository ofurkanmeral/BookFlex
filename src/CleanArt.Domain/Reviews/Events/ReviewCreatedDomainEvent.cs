using CleanArt.Domain.Abstractions;

namespace CleanArt.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomaintEvent;