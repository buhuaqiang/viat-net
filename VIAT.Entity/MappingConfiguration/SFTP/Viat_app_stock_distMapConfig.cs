using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_app_stock_distMapConfig : EntityMappingConfiguration<Viat_app_stock_dist>
    {
        public override void Map(EntityTypeBuilder<Viat_app_stock_dist>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

