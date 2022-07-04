using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Sys_MenuMapConfig : EntityMappingConfiguration<Sys_Menu>
    {
        public override void Map(EntityTypeBuilder<Sys_Menu>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

