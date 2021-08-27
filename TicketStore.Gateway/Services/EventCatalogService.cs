using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TicketStore.Gateway.Models;

namespace TicketStore.Gateway.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly HttpClient _httpClient;

        public EventCatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _httpClient.GetStringAsync("Categories");
            return JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<EventDto> GetEventByIdAsync(Guid id)
        {
            var eventData = await _httpClient.GetStringAsync($"Events/{id}");
            return JsonConvert.DeserializeObject<EventDto>(eventData);
        }

        public async Task<IEnumerable<EventDto>> GetEventsByCategoryAsync(Guid categoryId)
        {
            var eventData = await _httpClient.GetStringAsync($"Events?categoryId={categoryId}");
            return JsonConvert.DeserializeObject<IEnumerable<EventDto>>(eventData);
        }
    }
}
