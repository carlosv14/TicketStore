using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketStore.Gateway.Models;

namespace TicketStore.Gateway.Services
{
    public interface IEventCatalogService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();

        Task<EventDto> GetEventByIdAsync(Guid id);

        Task<IEnumerable<EventDto>> GetEventsByCategoryAsync(Guid categoryId);
    }
}
