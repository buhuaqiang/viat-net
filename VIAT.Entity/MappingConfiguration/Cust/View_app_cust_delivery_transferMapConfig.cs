using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_app_cust_delivery_transferMapConfig : EntityMappingConfiguration<View_app_cust_delivery_transfer>
    {
        public override void Map(EntityTypeBuilder<View_app_cust_delivery_transfer>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

