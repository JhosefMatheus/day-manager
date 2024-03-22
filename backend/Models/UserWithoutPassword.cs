namespace backend.Models;

public class UserWithoutPassword
{
    public int Id { get; }
    public string Name { get; }
    public string Login { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
    public DateTime? DeletedAt { get; }

    public UserWithoutPassword(UserModel user)
    {
        this.Id = user.Id;
        this.Name = user.Name;
        this.Login = user.Login;
        this.CreatedAt = user.CreatedAt;
        this.UpdatedAt = user.UpdatedAt;
        this.DeletedAt = user.DeletedAt;
    }

    public object ToObject()
    {
        return new
        {
            id = this.Id,
            name = this.Name,
            login = this.Login,
            created_at = this.CreatedAt,
            updated_at = this.UpdatedAt,
            deleted_at = this.DeletedAt
        };
    }
}