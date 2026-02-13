namespace UsersService.Domain.Entities;

public sealed class UserProfile
{
    private string? _status;
    
    public Guid Id { get; private init; }

    public string Status => _status ?? string.Empty;

    #region EF
    #pragma warning disable
    private UserProfile() {}
    #pragma warning restore
    #endregion

    private UserProfile(Guid id)
    {
        Id = id;
    }

    public void UpdateStatus(string newStatus) => _status =
        string.IsNullOrWhiteSpace(newStatus) ? null : newStatus;

    public static UserProfile CreateWithId(Guid userId) => new UserProfile(userId);
}