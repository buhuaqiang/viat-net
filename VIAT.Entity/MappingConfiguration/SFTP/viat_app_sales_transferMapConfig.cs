using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class viat_app_sales_transferMapConfig : EntityMappingConfiguration<viat_app_sales_transfer>
    {
        public override void Map(EntityTypeBuilder<viat_app_sales_transfer>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

