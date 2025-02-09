using CSharpFunctionalExtensions;
using Quests.Domain.Shared;

namespace Quests.Application.TestDirectory.AddTest;

public class AddTestHandler
{
    public async Task<Result<Guid, Error>> Handle(
        AddTestRequest request,
        CancellationToken cancellationToken = default)
    {
        return Guid.NewGuid();
    }
}