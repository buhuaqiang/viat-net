using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_app_cust_delivery_transferMapConfig : EntityMappingConfiguration<Viat_app_cust_delivery_transfer>
    {
        public override void Map(EntityTypeBuilder<Viat_app_cust_delivery_transfer>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

