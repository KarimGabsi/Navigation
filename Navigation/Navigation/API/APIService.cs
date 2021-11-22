using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Navigation.API
{
    public class APIService<T> : IDisposable
    {
        private HttpClient httpClient;
        public T myService;
        public APIService(string url)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            httpClient = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(url)
            };
            myService = RestService.For<T>(httpClient);
        }
        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
