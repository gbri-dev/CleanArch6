using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productService.GetProductsAsync();
            if (products == null)
            {
                return NotFound("Products not found");
            }
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var products = await _productService.GetByIdAsync(id);
            if (products == null)
            {
                return NotFound("Products not found");
            }
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO product)
        {
            if (product == null)
                return BadRequest("Data Invalid");

            await _productService.CreateAsync(product);

            return new CreatedAtRouteResult("GetProduct", new { id = product.Id },
                product);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO product)
        {
            if (id != product.Id)
                return BadRequest();

            if (product == null)
                return BadRequest();

            await _productService.UpdateAsync(product);
            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound("Categoria não encontrada");
            }
            await _productService.RemoveAsync(id);
            return Ok(product);
        }
    }
}
