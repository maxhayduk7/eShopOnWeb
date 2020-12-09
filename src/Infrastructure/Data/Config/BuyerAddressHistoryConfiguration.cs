using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate;

namespace Microsoft.eShopWeb.Infrastructure.Data.Config
{
    public class BuyerAddressHistoryConfiguration : IEntityTypeConfiguration<BuyerAddressHistory>
    {
        public void Configure(EntityTypeBuilder<BuyerAddressHistory> builder)
        {
            builder.OwnsOne(buyer => buyer.PreviousAddress, address =>
            {
                address.Property(a => a.Street1).HasMaxLength(100);
                address.Property(a => a.Street2).HasMaxLength(100);
                address.Property(a => a.City).HasMaxLength(100);
                address.Property(a => a.State).HasMaxLength(100);
                address.Property(a => a.ZipCode).HasMaxLength(100);
            });
        }
    }
}
