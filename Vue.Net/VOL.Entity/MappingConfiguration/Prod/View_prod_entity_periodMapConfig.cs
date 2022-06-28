using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class View_prod_entity_periodMapConfig : EntityMappingConfiguration<View_prod_entity_period>
    {
        public override void Map(EntityTypeBuilder<View_prod_entity_period>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

