using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class BuyerRepository : EfRepository<Buyer>, IBuyerRepository
    {
        public BuyerRepository(CatalogContext dbContext) : base(dbContext)
        {
        }

        public Task<Buyer> GetByIdWithAllProperties(int id)
        {
            return _dbContext.Buyers
                .Include(b => b.BuyerAddresses)
                .Include(b => b.PaymentMethods)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
