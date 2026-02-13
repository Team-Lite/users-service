namespace UsersService.Domain.Entities;

public sealed class UserProfile
{
    private string? _status;
    
    public Guid Id { get; private init; }

    public string Status => _status ?? string.Empty;
    
    public string ShownName { get; set; }

    #region EF
    #pragma warning disable
    private UserProfile() {}
    #pragma warning restore
    #endregion

    private UserProfile(Guid id, string shownName)
    {
        Id = id;
        ShownName = shownName;
    }

    public void UpdateStatus(string newStatus) => _status =
        string.IsNullOrWhiteSpace(newStatus) ? null : newStatus;

    public static UserProfile CreateWithId(Guid userId, string shownName) => new(userId, shownName);
}