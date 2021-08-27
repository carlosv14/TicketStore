using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TicketStore.Gateway.Models;

namespace TicketStore.Gateway.Services
{
    public class ShoppingBasketService : IShoppingBasketService
    {
        private readonly HttpClient _httpClient;

        public ShoppingBasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<BasketDto> GetBasketByIdAsync(Guid id)
        {
            var basketResponse = await _httpClient.GetStringAsync($"ShoppingBaskets/{id}");
            var basketLinesResponse = await _httpClient.GetStringAsync($"ShoppingBaskets/{id}/BasketLines");
            var basket = JsonConvert.DeserializeObject<BasketDto>(basketResponse);
            var basketLines = JsonConvert.DeserializeObject<IEnumerable<BasketLineDto>>(basketLinesResponse);
            basket.BasketLines = basketLines;
            return basket;
        }

        public async Task<BasketLineDto> AddEventToBasketAsync(Guid basketId, CreateBasketLineDto lineToAdd)
        {
            var requestBodyJson = JsonConvert.SerializeObject(lineToAdd);
            var basketLinesResponse = await _httpClient.PostAsync($"ShoppingBaskets/{basketId}/BasketLines",
                new StringContent(requestBodyJson, Encoding.UTF8, "application/json"));
            basketLinesResponse.EnsureSuccessStatusCode();
            var responseBody = await basketLinesResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BasketLineDto>(responseBody);
        }
    }
}
