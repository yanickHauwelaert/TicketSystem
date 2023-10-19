using TicketSystem.Core.Entities;

namespace TicketSystem.Core.Services.Interfaces;

public interface IAccountService
{
    Task<ICollection<ApplicationUser>> GetAllUsers();
    Task<ApplicationUser> GetUserById();
    Task<ApplicationUser> AddUser();
    Task<ApplicationUser> UpdateUser();
    Task<ApplicationUser> DeleteUser();
}