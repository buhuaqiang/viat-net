using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class View_com_close_period_marginMapConfig : EntityMappingConfiguration<View_com_close_period_margin>
    {
        public override void Map(EntityTypeBuilder<View_com_close_period_margin>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

