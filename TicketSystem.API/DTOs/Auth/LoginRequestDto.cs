﻿namespace TicketSystem.API.DTOs.Auth;

public class LoginRequestDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}