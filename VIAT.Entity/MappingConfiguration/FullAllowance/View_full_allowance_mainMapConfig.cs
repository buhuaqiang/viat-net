using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_full_allowance_mainMapConfig : EntityMappingConfiguration<View_full_allowance_main>
    {
        public override void Map(EntityTypeBuilder<View_full_allowance_main>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

