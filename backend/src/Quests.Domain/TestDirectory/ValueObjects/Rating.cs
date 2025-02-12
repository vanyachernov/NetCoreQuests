using CSharpFunctionalExtensions;
using Quests.Domain.Shared;

namespace Quests.Domain.TestDirectory.ValueObjects;

public record Rating
{
    private Rating(double value)
    {
        if (value < 0 || value > 5)
        {
            throw new ArgumentException("Rating must be between 0 and 5.");
        }

        Value = value;
    }

    public double Value { get; }

    public static Result<Rating, Error> Create(double rating)
    {
        if (rating < 0 || rating > 5)
        {
            return Errors.General.ValueIsInvalid("Rating must be between 0 and 5.");
        }

        return new Rating(rating);
    }
}