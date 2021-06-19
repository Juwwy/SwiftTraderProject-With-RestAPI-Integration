using Microsoft.AspNetCore.Mvc;
using SwiftTraders.ApplicationCore.DTOs;
using SwiftTraders.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SwiftTrader.Presentation.API.Controllers
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok(userService.GetUsers());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await userService.GetUser(id);
            if (user != null)
                return Ok(user);

            return NotFound();

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAsync([FromBody] AddUserDTO model)
        {

            var userId = await userService.AddUser(model);
            if (userId != null)
                return CreatedAtAction("Get", new { Id = userId }, userId);

            return BadRequest();
        }

    }
}
