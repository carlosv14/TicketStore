using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.EventCatalog.Models;

namespace TicketStore.EventCatalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private static readonly List<CategoryDto> Categories = new List<CategoryDto>
        {
            new CategoryDto
            {
                CategoryId = new Guid("20983d00-f2ae-4361-bdad-68f14e46a32c"),
                Name = "Conciertos"
            },
            new CategoryDto
            {
                CategoryId = new Guid("7eeb2e1f-8648-4ea4-a339-f7005671deae"),
                Name = "Obras"
            },
        };

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> Get()
        {
            return this.Ok(Categories);
        }

        [HttpGet("{categoryId}")]
        public ActionResult<IEnumerable<CategoryDto>> Get(Guid categoryId)
        {
            return this.Ok(Categories.FirstOrDefault(x => x.CategoryId == categoryId));
        }
    }
}
