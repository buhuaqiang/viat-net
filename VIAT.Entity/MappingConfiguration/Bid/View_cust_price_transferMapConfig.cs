using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_cust_price_transferMapConfig : EntityMappingConfiguration<View_cust_price_transfer>
    {
        public override void Map(EntityTypeBuilder<View_cust_price_transfer>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

