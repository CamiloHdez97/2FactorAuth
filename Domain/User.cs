using System.ComponentModel.DataAnnotations;

namespace Domain;

public class User : BaseEntity
{
    public DateTime DateUp { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string TwoFactorSecret { get; set; }
    public DateTime DateDown { get; set; }

}