﻿using TicketSystem.Core.Entities;

namespace TicketSystem.Core.Services.Interfaces;

public interface IAccountService
{
    Task<ICollection<ApplicationUser>> GetAllUsers();
    Task<ApplicationUser> GetUserById(Guid id);
    Task<ApplicationUser> AddUser(ApplicationUser user);
    Task<ApplicationUser> UpdateUser(ApplicationUser user);
    Task<ApplicationUser> DeleteUser(ApplicationUser user);
}