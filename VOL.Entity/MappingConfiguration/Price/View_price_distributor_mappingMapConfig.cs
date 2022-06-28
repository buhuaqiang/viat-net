using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class View_price_distributor_mappingMapConfig : EntityMappingConfiguration<View_price_distributor_mapping>
    {
        public override void Map(EntityTypeBuilder<View_price_distributor_mapping>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

