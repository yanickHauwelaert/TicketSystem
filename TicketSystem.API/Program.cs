using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TicketSystem.Core.Entities;
using TicketSystem.Core.Repositories.Interfaces;
using TicketSystem.Core.Services;
using TicketSystem.Core.Services.Interfaces;
using TicketSystem.Infrastructure.Data;
using TicketSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("LocalDatabase");
    options.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllers();

//DI for Repository Interfaces
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

//DI for Service Interfaces
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITicketService, TicketService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new OpenApiInfo
    {
        Title = "Ticket system",
        Version = "v1"
    });
    
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwtOptions =>
{
    var config = builder.Configuration;
    jwtOptions.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = config["JWTConfiguration:Issuer"],
        ValidAudience = config["JWTConfiguration:Audience"],
        IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTConfiguration:SigningKey"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanRead", policy =>
    {
        policy.RequireAssertion(context =>
        {
            if (context.User.IsInRole("Admin") || context.User.IsInRole("User"))
                return true;
            return false;
        });
    });
    options.AddPolicy("CanEdit", policy =>
    {
        policy.RequireAssertion(context =>
        {
            if (context.User.IsInRole("Admin") || context.User.IsInRole("User"))
                return true;
            return false;
        });
    });
    options.AddPolicy("CanUpdate", policy =>
    {
        policy.RequireAssertion(context =>
        {
            if (context.User.IsInRole("Admin") || context.User.IsInRole("User"))
                return true;
            return false;
        });
    });
    options.AddPolicy("CanDelete", policy =>
    {
        policy.RequireAssertion(context =>
        {
            if (context.User.IsInRole("Admin") || context.User.IsInRole("User"))
                return true;
            return false;
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();