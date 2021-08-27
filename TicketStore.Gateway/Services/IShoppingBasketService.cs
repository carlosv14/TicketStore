using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketStore.Gateway.Models;

namespace TicketStore.Gateway.Services
{
    public interface IShoppingBasketService
    {
        Task<BasketDto> GetBasketByIdAsync(Guid id);

        Task<BasketLineDto> AddEventToBasketAsync(Guid basketId, CreateBasketLineDto lineToAdd);
    }
}
