namespace Planner.ServiceInterfaces.Interfaces.Misc
{
    public interface ISecurityService
    {
        string GetSha512Hash(string input);
    }
}