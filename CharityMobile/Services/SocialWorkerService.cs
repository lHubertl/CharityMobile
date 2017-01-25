using CharityMobile.DAL;
using CharityMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CharityMobile.Services
{
    public class SocialWorkerService
    {
        NetworkService _networkService;
        public SocialWorkerService(NetworkService netService)
        {
            _networkService = netService;
        }
        public async Task<ICollection<SocialWorker>> GetAllAsync()
        {
            return await _networkService.GetAsync<SocialWorker>("http://charity-service.azurewebsites.net/api/socialworkers/all");
        }
    }
}
