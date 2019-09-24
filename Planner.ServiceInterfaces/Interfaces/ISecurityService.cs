using System;

namespace Planner.ServiceInterfaces.Interfaces
{
    public interface ISecurityService
    {
        String GetSha256Hash(String input);
    }
}
