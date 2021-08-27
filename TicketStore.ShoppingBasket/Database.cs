using System;
using System.Collections.Generic;
using TicketStore.ShoppingBasket.Models;

namespace TicketStore.ShoppingBasket
{
    public static class Database
    {
        public static readonly List<BasketDto> Baskets = new List<BasketDto>
        {
            new BasketDto
            {
                BasketId = new Guid("5db78a27-bbd6-49bb-a776-4f6c7d729464"),
                NumberOfItems = 0,
                UserId = new Guid("1e15139a-fd4b-4d46-b124-7d5b97220ee9")
            }
        };

        public static readonly List<EventDto> Events = new List<EventDto>();

        public static readonly List<BasketLineDto> BasketLines = new List<BasketLineDto>();
    }
}
