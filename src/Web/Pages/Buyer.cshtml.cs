using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Pages
{
    public class BuyerModel : PageModel
    {
        private readonly IBuyerRepository _buyerRepository;

        public BuyerModel(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public int BuyerId { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task OnGet(int buyerId)
        {
            var buyer = await _buyerRepository.GetByIdWithAllProperties(buyerId);
            if (buyer == null)
            {
                ErrorMessage = "No buyer found for that Id.";
                return;
            }
            BuyerId = buyerId;
            Addresses = buyer.BuyerAddresses.Select(ba => ba.Address).ToList();
        }
    }
}
