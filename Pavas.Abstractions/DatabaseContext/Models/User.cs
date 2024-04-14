using System.ComponentModel.DataAnnotations;

namespace Pavas.Abstractions.DatabaseContext.Models;

public abstract class User
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Username { get; set; } = string.Empty;

    private string _hashedPassword = string.Empty;

    [MaxLength(100)]
    public string Password
    {
        get => _hashedPassword;
        set => _hashedPassword = BCrypt.Net.BCrypt.HashPassword(value);
    }

    public bool VerifyPassword(string attempt)
    {
        return BCrypt.Net.BCrypt.Verify(attempt, _hashedPassword);
    }
}