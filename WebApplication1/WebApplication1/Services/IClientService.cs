using WebApplication1.Model;

namespace WebApplication1.Services;

public interface IClientService
{
    Client GetClientDetails(int clientId);
    void DeleteClient(int clientId);
}