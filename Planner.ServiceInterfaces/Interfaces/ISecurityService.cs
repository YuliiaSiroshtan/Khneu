﻿
namespace Planner.ServiceInterfaces.Interfaces
{
    public interface ISecurityService
    {
        string GetSha256Hash(string input);
    }
}
