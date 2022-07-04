using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_full_allowance_reverseMapConfig : EntityMappingConfiguration<View_full_allowance_reverse>
    {
        public override void Map(EntityTypeBuilder<View_full_allowance_reverse>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

