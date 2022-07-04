using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_sys_deputy_popMapConfig : EntityMappingConfiguration<View_sys_deputy_pop>
    {
        public override void Map(EntityTypeBuilder<View_sys_deputy_pop>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

