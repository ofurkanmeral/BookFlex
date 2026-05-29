using CleanArt.Application.Abstractions.Messaging.Command;

namespace CleanArt.Application.Reviews.AddReview;

public sealed record AddReviewCommand(Guid BookingId, int Rating, string Comment) : ICommand;