﻿using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface IReservationService
    {
        void ReserveItems(IEnumerable<OrderItem> orderedItems);
    }
}
