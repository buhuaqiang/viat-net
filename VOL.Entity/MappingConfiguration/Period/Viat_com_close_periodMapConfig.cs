using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Viat_com_close_periodMapConfig : EntityMappingConfiguration<Viat_com_close_period>
    {
        public override void Map(EntityTypeBuilder<Viat_com_close_period>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

