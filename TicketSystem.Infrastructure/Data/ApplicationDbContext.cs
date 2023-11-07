using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Entities;

namespace TicketSystem.Infrastructure.Data;

public class ApplicationDbContext: IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<ApplicationUser> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var passwordHasher = new PasswordHasher<ApplicationUser>();
        
        var userToSeed = new List<ApplicationUser>();
        userToSeed.Add(new ApplicationUser
        {
            Id = new Guid("10000000-0000-0000-0000-000000000000"),
            UserName = "YanickHauwelaert",
            FirstName = "Yanick",
            LastName = "Hauwelaert",
            Email = "hauwelaert.yanick@gmail.com"
        });
        
        userToSeed.Add(new ApplicationUser
        {
            Id = new Guid("20000000-0000-0000-0000-000000000000"),
            UserName = "TestUser1",
            FirstName = "Test1",
            LastName = "User",
            Email = "TestUser1@gmail.com"
        });
        
        userToSeed.Add(new ApplicationUser
        {
            Id = new Guid("30000000-0000-0000-0000-000000000000"),
            UserName = "TestUser2",
            FirstName = "Test2",
            LastName = "User",
            Email = "TestUser2@gmail.com"
        });

        foreach (var user in userToSeed)
        {
            user.PasswordHash = passwordHasher.HashPassword(user, "Test123");
            user.NormalizedEmail = user.Email.ToUpper();
            user.NormalizedUserName = user.UserName.ToUpper();
            user.SecurityStamp = Guid.NewGuid().ToString();
        }

        builder.Entity<ApplicationUser>().HasData(userToSeed);

        builder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
        {
            Id = Guid.Parse("6B5C44D7-29EC-440E-BCCB-63D5CF34FBC4"),
            Name = "Admin",
            NormalizedName = "ADMIN",
            ConcurrencyStamp = new Guid().ToString()
        });

        builder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
        {
            Id = Guid.Parse("38DFD248-ADB7-43BD-9FF0-348357283BA2"),
            Name = "User",
            NormalizedName = "USER",
            ConcurrencyStamp = new Guid().ToString()
        });

        //Admin
        builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
        {
            UserId = Guid.Parse("10000000-0000-0000-0000-000000000000"),
            RoleId = Guid.Parse("6B5C44D7-29EC-440E-BCCB-63D5CF34FBC4")
        });
        
        //Users
        builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
        {
            UserId = Guid.Parse("20000000-0000-0000-0000-000000000000"),
            RoleId = Guid.Parse("38DFD248-ADB7-43BD-9FF0-348357283BA2")
        });
        builder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
        {
            UserId = Guid.Parse("30000000-0000-0000-0000-000000000000"),
            RoleId = Guid.Parse("38DFD248-ADB7-43BD-9FF0-348357283BA2")
        });

        builder.Entity<IdentityUserClaim<Guid>>().HasData(
            new IdentityUserClaim<Guid>
            {
                Id = 1,
                UserId = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                ClaimType = ClaimTypes.Role,
                ClaimValue = "Admin"
            },
            new IdentityUserClaim<Guid>
            {
                Id = 2,
                UserId = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                ClaimType = ClaimTypes.Email,
                ClaimValue = "hauwelaert.yanick@gmail.com"
            },
            new IdentityUserClaim<Guid>
            {
                Id = 3,
                UserId = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                ClaimType = ClaimTypes.NameIdentifier,
                ClaimValue = "10000000-0000-0000-0000-000000000000"
            },
            new IdentityUserClaim<Guid>
            {
                Id = 4 ,
                UserId = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                ClaimType = ClaimTypes.Name,
                ClaimValue = "YanickHauwelaert"
            },
            new IdentityUserClaim<Guid>
            {
                Id = 5,
                UserId = Guid.Parse("20000000-0000-0000-0000-000000000000"),
                ClaimType = ClaimTypes.Role,
                ClaimValue = "User",
            },
            new IdentityUserClaim<Guid>
            {
                Id = 6,
                UserId = Guid.Parse("20000000-0000-0000-0000-000000000000"),
                ClaimType = ClaimTypes.Email,
                ClaimValue = "TestUser1@gmail.com"
            },
            new IdentityUserClaim<Guid>
            {
                Id = 7,
                UserId = Guid.Parse("20000000-0000-0000-0000-000000000000"),
                ClaimType = ClaimTypes.NameIdentifier,
                ClaimValue = "20000000-0000-0000-0000-000000000000"
            },
            new IdentityUserClaim<Guid>
            {
                Id = 8,
                UserId = Guid.Parse("20000000-0000-0000-0000-000000000000"),
                ClaimType = ClaimTypes.Name,
                ClaimValue = "TestUser1"
            },
            new IdentityUserClaim<Guid>
            {
                Id = 9,
                UserId = Guid.Parse("30000000-0000-0000-0000-000000000000"),
                ClaimType = ClaimTypes.Role,
                ClaimValue = "User"
            },
            new IdentityUserClaim<Guid>
            {
                Id = 10,
                UserId = Guid.Parse("30000000-0000-0000-0000-000000000000"),
                ClaimType = ClaimTypes.Email,
                ClaimValue = "TestUser2@gmail.com"
            },
            new IdentityUserClaim<Guid>
            {
                Id = 11,
                UserId = Guid.Parse("30000000-0000-0000-0000-000000000000"),
                ClaimType = ClaimTypes.NameIdentifier,
                ClaimValue = "30000000-0000-0000-0000-000000000000"
            },
            new IdentityUserClaim<Guid>
            {
                Id = 12,
                UserId = Guid.Parse("30000000-0000-0000-0000-000000000000"),
                ClaimType = ClaimTypes.Name,
                ClaimValue = "TestUser2"
            }
        );

        builder.Entity<Category>().HasData(
                new Category
                {
                    Id = new Guid("00000000-1000-0000-0000-000000000000"),
                    Name = "Hardware"
                },
                new Category
                {
                    Id = new Guid("00000000-2000-0000-0000-000000000000"),
                    Name = "Software"
                },               
                new Category
                {
                    Id = new Guid("00000000-3000-0000-0000-000000000000"),
                    Name = "Other"
                }
        );

        builder.Entity<Ticket>().HasData(
                new Ticket
                {
                    Id = new Guid("00000000-0000-1000-0000-000000000000"),
                    CategoryId =  Guid.Parse("00000000-2000-0000-0000-000000000000"),
                    CreationDate = DateTime.Today,
                    Description = "The software keeps freezing when i try to start it",
                    Status = "InProcces",
                    Subject = "Program X freez",
                    UserId = Guid.Parse("30000000-0000-0000-0000-000000000000")
                },
                new Ticket
                {
                    Id = new Guid("00000000-0000-2000-0000-000000000000"),
                    CategoryId =  Guid.Parse("00000000-1000-0000-0000-000000000000"),
                    CreationDate = DateTime.Today,
                    Description = "Hard drive constantly 100% usage",
                    Status = "None",
                    Subject = "Hardrive usage",
                    UserId = Guid.Parse("20000000-0000-0000-0000-000000000000")
                },
                new Ticket
                {
                    Id = new Guid("00000000-0000-3000-0000-000000000000"),
                    CategoryId =  Guid.Parse("00000000-3000-0000-0000-000000000000"),
                    CreationDate = DateTime.Today,
                    Description = "I get the a lot of blue screens with the following error code some error code",
                    Status = "Done",
                    Subject = "blue screen",
                    UserId = Guid.Parse("20000000-0000-0000-0000-000000000000")
                }
                ,
                new Ticket
                {
                    Id = new Guid("00000000-0000-4000-0000-000000000000"),
                    CategoryId =  Guid.Parse("00000000-1000-0000-0000-000000000000"),
                    CreationDate = DateTime.Today,
                    Description = "Fans keep spinning really loud",
                    Status = "None",
                    Subject = "Loud fans",
                    UserId = Guid.Parse("20000000-0000-0000-0000-000000000000")
                }
            );
    }
}