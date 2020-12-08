using Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface IBuyerRepository
    {
        Task<Buyer> GetByIdWithAllProperties(int id);
    }
}
