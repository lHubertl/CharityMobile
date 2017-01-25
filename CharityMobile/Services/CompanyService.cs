using CharityMobile.DAL;
using CharityMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityMobile.Services
{
    public class CompanyService
    {
        NetworkService _networkService;
        public CompanyService(NetworkService netService)
        {
            _networkService = netService;

        }
        public async Task<ICollection<Company>> GetAllAsync()
        {
            return await _networkService.GetAsync<Company>("http://charity-service.azurewebsites.net/api/companies/allcompanies");
        }
    }
}
