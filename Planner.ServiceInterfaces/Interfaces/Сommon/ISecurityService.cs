namespace Planner.ServiceInterfaces.Interfaces.Сommon
{
    public interface ISecurityService
    {
        string GetSha256Hash(string input);
    }
}
