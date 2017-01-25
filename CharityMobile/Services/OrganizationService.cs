using CharityMobile.DAL;
using CharityMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CharityMobile.Services
{
    public class OrganizationService
    {
        NetworkService _networkService;

        public OrganizationService(NetworkService netService)
        {
            _networkService = netService;
        }
        public async Task<ICollection<Organization>> GetAllAsync()
        {
            return await _networkService.GetAsync<Organization>("http://charity-service.azurewebsites.net/api/organizations/allorganizations");
        }
    }
}
