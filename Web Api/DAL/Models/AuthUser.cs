using Microsoft.AspNetCore.Identity;

namespace DAL.Models;

public class AuthUser : IdentityUser
{
    public string Address { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
