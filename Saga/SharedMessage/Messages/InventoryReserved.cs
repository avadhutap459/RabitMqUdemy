using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedMessage.Messages
{
    public sealed record InventoryReserved(Guid orderId);
}
