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
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService advertService;

        public AdvertController(IAdvertService advertService)
        {
            this.advertService = advertService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await advertService.GetAllAds());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var ads = await advertService.GetAdvert(id);
            if (ads != null)
                return Ok(ads);

            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Created([FromBody] AdvertDTO model)
        {
            var ads = await advertService.AddAdvert(model);
            if(ads != null)
            return CreatedAtAction("Get", new { id = ads}, ads);

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveUser(string id)
        {
            await advertService.RemoveAdvert(id);

            return NoContent();
        }


    }
}
