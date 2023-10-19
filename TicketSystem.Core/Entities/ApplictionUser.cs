using Microsoft.AspNetCore.Identity;

namespace TicketSystem.Core.Entities;

public class ApplictionUser: IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
}