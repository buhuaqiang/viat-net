using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_sys_deputyMapConfig : EntityMappingConfiguration<View_sys_deputy>
    {
        public override void Map(EntityTypeBuilder<View_sys_deputy>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

