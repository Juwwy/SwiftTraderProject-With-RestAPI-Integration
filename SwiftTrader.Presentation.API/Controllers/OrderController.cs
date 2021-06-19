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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await orderService.GetAllOrders());


        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var order = await orderService.GetOrder(id);
            if (order != null)
                return Ok(order);
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAsync([FromBody] OrderDTO model)
        {
            var order = await orderService.AddOrder(model);
            if (order != null)
                return CreatedAtAction("GetAsync", new { Id = order }, order);

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveOrderAsync(string id)
        {
             await orderService.RemoveOrder(id);
           
            return NoContent();
        }










    }
}
