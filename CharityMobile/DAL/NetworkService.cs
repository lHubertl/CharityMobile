using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using CharityMobile.DAL.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;

namespace CharityMobile.DAL
{
    public class NetworkService : INetworkService
    {
        private HttpClient httpClient;

        public NetworkService()
        {
            httpClient = new HttpClient();
        }
        public Task<T> PostAsync<T>(string url, object content)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<T>> GetAsync<T>(string url)
        {

            List<T> result = default(List<T>);
            try
            {
                var response = await httpClient.GetAsync(url);

                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<T>>(responseString);
                }
                else
                {
                    throw new HttpCodeRequestException(response.StatusCode);
                }
            }
            catch(HttpCodeRequestException ex)
            {
                throw(ex);
            }
            catch (JsonException ex)
            {
                throw (ex);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Сталася помилка при відправленні запиту");
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return result;
        }

        public async Task<T> GetSingleAsync<T>(string url)
        {

            T result = default(T);
            try
            {
                var response = await httpClient.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<T>(responseString);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return result;
        }

        public Task<string> TokenAsync(string url, string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
