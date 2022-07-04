using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
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

