﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Entities;

namespace TicketSystem.Infrastructure.Data;

public class ApplicationDbContext: IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
}