﻿namespace WebApplication1.Interfaces
{
    public interface IUserService
    {
        Task<string> GetRolesByEmail(string email);
    }
}
