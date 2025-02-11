namespace Quests.Application.UserDirectory.AddUser;

public class AddUserResponse
{
    public bool IsSuccessfullyRegistration { get; set; }
    public IEnumerable<string> Errors { get; set; }
}