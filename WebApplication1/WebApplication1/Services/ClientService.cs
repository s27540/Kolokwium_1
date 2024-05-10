using WebApplication1.Model;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public Client GetClientDetails(int clientId)
    {
        return _clientRepository.GetClientById(clientId);
    }

    public void DeleteClient(int clientId)
    {
        _clientRepository.DeleteClient(clientId);
    }
}