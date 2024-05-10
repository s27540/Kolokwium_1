using WebApplication1.Model;

namespace WebApplication1.Repositories;

public interface IClientRepository
{
    Client GetClientById(int clientId);
    void DeleteClient(int clientId);
}