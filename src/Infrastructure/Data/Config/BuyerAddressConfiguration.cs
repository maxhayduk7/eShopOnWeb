using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate;

namespace Microsoft.eShopWeb.Infrastructure.Data.Config
{
    public class BuyerAddressConfiguration : IEntityTypeConfiguration<BuyerAddress>
    {
        public void Configure(EntityTypeBuilder<BuyerAddress> builder)
        {
            builder.OwnsOne(buyer => buyer.Address, address =>
            {
                address.Property(a => a.Street1).HasMaxLength(100);
                address.Property(a => a.Street2).HasMaxLength(100);
                address.Property(a => a.City).HasMaxLength(100);
                address.Property(a => a.State).HasMaxLength(100);
                address.Property(a => a.ZipCode).HasMaxLength(100);
            });

            builder.Property(buyer => buyer.AddressVerified)
                .HasMaxLength(100);
        }
    }
}
