using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Plugin.RestClient
{
    /// <summary>
    /// RestClient implements methods for calling CRUD operations
    /// using HTTP.
    /// </summary>
    public class RestClient<T>
    {
        private const string WebServiceUrl = "http://lightscontrol.azurewebsites.net/api/Light?";

        public async Task<bool> GetAsync(string lampsUrlParameter)
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl + lampsUrlParameter);

            var isSuccessful = JsonConvert.DeserializeObject<bool>(json);

            return isSuccessful;
        }

        //public async Task<bool> PostAsync(T t)
        //{
        //    var httpClient = new HttpClient();

        //    var json = JsonConvert.SerializeObject(t);

        //    HttpContent httpContent = new StringContent(json);

        //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

        //    return result.IsSuccessStatusCode;
        //}

        //public async Task<bool> PutAsync(int id, T t)
        //{
        //    var httpClient = new HttpClient();

        //    var json = JsonConvert.SerializeObject(t);

        //    HttpContent httpContent = new StringContent(json);

        //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    var result = await httpClient.PutAsync(WebServiceUrl + id, httpContent);

        //    return result.IsSuccessStatusCode;
        //}

        //public async Task<bool> DeleteAsync(int id, T t)
        //{
        //    var httpClient = new HttpClient();

        //    var response = await httpClient.DeleteAsync(WebServiceUrl + id);

        //    return response.IsSuccessStatusCode;
        //}
    }
}
