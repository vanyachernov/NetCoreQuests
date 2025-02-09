using CSharpFunctionalExtensions;

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

    public static Result<Rating> Create(double rating)
    {
        if (rating < 0 || rating > 5)
        {
            return Result.Failure<Rating>("Rating must be between 0 and 5.");
        }

        return new Rating(rating);
    }
}