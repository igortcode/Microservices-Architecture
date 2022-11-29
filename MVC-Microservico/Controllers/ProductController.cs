using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using MVC_Microservico.Models;
using MVC_Microservico.Routes;

namespace MVC_Microservico.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(IConfiguration configuration, IHttpClientFactory factory) : base(configuration, factory)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = NewHttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://IS-MS:86");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return View();
            }

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "client",
                ClientSecret = "secret",
                Scope = "ApiMS"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return View();
            }

            var result = await client.GetFromJsonAsync<IEnumerable<ProductViewModel>>(ProductsApiRoutes.GET_ALL);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductViewModel viewModel)
        {

            var client = NewHttpClient();
            var result = await client.PostAsJsonAsync(ProductsApiRoutes.CREATE, viewModel);
            
            if (result.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var client = NewHttpClient();
            var result = await client.GetFromJsonAsync<ProductViewModel>(ProductsApiRoutes.GET_BY_ID + $"/{Id}");

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var client = NewHttpClient();
            var result = await client.PutAsJsonAsync(ProductsApiRoutes.UPDATE+$"/{viewModel.Id}", viewModel);

            if (result.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Details(string Id)
        {
            var client = NewHttpClient();
            var result = await client.GetFromJsonAsync<ProductViewModel>(ProductsApiRoutes.GET_BY_ID + $"/{Id}");

            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string Id)
        {
            var client = NewHttpClient();
            var result = await client.DeleteAsync(ProductsApiRoutes.DELETE + $"/{Id}");

            if (result.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return BadRequest("Não foi possível excluir");
        }
    }
}
