using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class View_nhi_adjustMapConfig : EntityMappingConfiguration<View_nhi_adjust>
    {
        public override void Map(EntityTypeBuilder<View_nhi_adjust>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

