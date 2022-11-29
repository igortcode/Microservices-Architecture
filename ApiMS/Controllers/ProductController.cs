using ApiMS.Interface;
using ApiMS.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpPost("inserir")]
        public async Task<IActionResult> Inserir([FromBody] Product product)
        {
            await _productRepository.CreateAsync(product);
            return Ok("Inserido com sucesso");
        }

        [HttpGet("buscar-todos")]
        [Authorize]
        public async Task<IActionResult> ListarTodos()
        {
            var result = await _productRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> Buscar(string id)
        {
            var result = await _productRepository.GetByIdAsync(id);
            return Ok(result);
        }


        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Atualizar(string id, Product product)
        {
            await _productRepository.UpdateAsync(id, product);
            return Ok("Atualizado com sucesso!");
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(string id)
        {
            await _productRepository.DeleteAsync(id);
            return Ok("Excluído com sucesso!");
        }
    }
}
