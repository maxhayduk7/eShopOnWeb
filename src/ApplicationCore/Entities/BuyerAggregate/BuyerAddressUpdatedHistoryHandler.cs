using MediatR;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate
{
    public class BuyerAddressUpdatedHistoryHandler : INotificationHandler<BuyerAddressUpdatedEvent>
    {
        private readonly IAsyncRepository<BuyerAddressHistory> _asyncRepository;

        public BuyerAddressUpdatedHistoryHandler(IAsyncRepository<BuyerAddressHistory> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }
        public Task Handle(BuyerAddressUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var entity = new BuyerAddressHistory() { PreviousAddress = notification.PreviousValue, BuyerAddressId = notification.BuyerAddressId };

            return _asyncRepository.AddAsync(entity, cancellationToken);
        }
    }
}