using Microsoft.AspNetCore.Mvc;
using SwiftTraders.ApplicationCore.DTOs;
using SwiftTraders.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftTrader.Presentation.API.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await productService.GetAllProduct());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await productService.GetProduct(id);
            if (product != null)
                return Ok(product);
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] ProductsDTO model)
        {
            var prod = await productService.AddProduct(model);
            if (prod != null)
                return CreatedAtAction("Get", new { Id = prod }, prod);
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveProduct(string id)
        {
            await productService.RemoveProduct(id);

            return NoContent();
        }
    }
}
