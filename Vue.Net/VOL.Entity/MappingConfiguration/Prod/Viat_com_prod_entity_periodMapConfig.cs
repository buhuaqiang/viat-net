using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Viat_com_prod_entity_periodMapConfig : EntityMappingConfiguration<Viat_com_prod_entity_period>
    {
        public override void Map(EntityTypeBuilder<Viat_com_prod_entity_period>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

