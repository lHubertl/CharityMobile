using System.Collections.Generic;
using System.Threading.Tasks;
using CharityMobile.DAL;
using CharityMobile.Models;

namespace CharityMobile.Services
{
    public class NeedService
    {
        NetworkService _networkService;
        public NeedService(NetworkService netService)
        {
            _networkService = netService;
        }
        public async Task<ICollection<Need>> GetAllAsync()
        {
            var needs = await _networkService.GetAsync<Need>("http://charity-service.azurewebsites.net/api/needs/allneeds");
            return needs;
        }
    }
}
