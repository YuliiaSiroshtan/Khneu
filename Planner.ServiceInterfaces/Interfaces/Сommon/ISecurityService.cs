namespace Planner.ServiceInterfaces.Interfaces.Сommon
{
    public interface ISecurityService
    {
        string GetSha512Hash(string input);
    }
}
