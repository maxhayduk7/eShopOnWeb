using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.Web.Pages
{
    public class BuyerModel : PageModel
    {
        private readonly IAsyncRepository<Buyer> _buyerRepository;

        public BuyerModel(IAsyncRepository<Buyer> buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public int BuyerId { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public string ErrorMessage { get; set; } = string.Empty;

        public async Task OnGetAsync(int buyerId)
        {
            var spec = new BuyerByIdWithAllPropertiesSpecification(buyerId);
            var buyer = await _buyerRepository.FirstOrDefaultAsync(spec);
            if (buyer == null)
            {
                ErrorMessage = "No buyer found for that Id.";
                return;
            }

            // modify an address
            var currentAddress = buyer.BuyerAddresses.First().Address;
            var newAddress = new Address(currentAddress.Street1, currentAddress.Street2, currentAddress.City,
                currentAddress.State, DateTime.Now.Ticks.ToString());
            buyer.BuyerAddresses.First().UpdateAddress(newAddress);
            await _buyerRepository.UpdateAsync(buyer);

            BuyerId = buyerId;
            Addresses = buyer.BuyerAddresses.Select(ba => ba.Address).ToList();
        }
    }
}
