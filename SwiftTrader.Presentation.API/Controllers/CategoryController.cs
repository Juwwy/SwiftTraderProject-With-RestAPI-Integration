using Microsoft.AspNetCore.Mvc;
using SwiftTraders.ApplicationCore.DTOs;
using SwiftTraders.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiftTrader.Presentation.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await categoryService.GetAllCategories());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var cate = await categoryService.GetCategory(id);
            if (cate != null)
                return Ok(cate);

            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAsync([FromBody] CategoryDTO model)
        {
            var cate = await categoryService.AddCategory(model);
            if (cate != null)
                return CreatedAtAction("Get", new { Id = cate }, cate);

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveCategory(string id)
        {
            await categoryService.RemoveCategory(id);

            return NoContent();
        }
    }
}
