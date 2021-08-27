using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.Gateway.Models;
using TicketStore.Gateway.Services;

namespace TicketStore.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventTicketsController : ControllerBase
    {
        private readonly IEventCatalogService _eventCatalogService;

        public EventTicketsController(IEventCatalogService eventCatalogService)
        {
            _eventCatalogService = eventCatalogService;
        }

        [HttpGet("categories")]
        public async Task<ActionResult<CategoryDto>> GetCategories()
        {
            var result = await _eventCatalogService.GetCategoriesAsync();
            return this.Ok(result);
        }

        [HttpGet("events/{id}")]
        public async Task<ActionResult<CategoryDto>> GetEventById(Guid id)
        {
            var result = await _eventCatalogService.GetEventByIdAsync(id);
            return this.Ok(result);
        }

        [HttpGet("events")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetEventsByCategory([FromQuery]Guid categoryId)
        {
            var result = await _eventCatalogService.GetEventsByCategoryAsync(categoryId);
            return this.Ok(result);
        }
    }
}
