using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace MVC_Microservico.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        protected HttpClient NewHttpClient(string? token = null)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(_configuration["BaseUrlNoSSL"]);

            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return httpClient;
        }
    }
}
