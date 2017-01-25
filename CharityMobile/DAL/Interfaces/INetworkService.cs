using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CharityMobile.DAL.Interfaces
{
    public interface INetworkService
    {
        Task<T> PostAsync<T>(string url, object content);
        Task<ICollection<T>> GetAsync<T>(string url);
        Task<T> GetSingleAsync<T>(string url);
        Task<string> TokenAsync(string url, string username, string password);
    }
}
