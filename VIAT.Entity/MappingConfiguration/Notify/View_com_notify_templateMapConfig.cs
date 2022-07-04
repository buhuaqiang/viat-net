using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_com_notify_templateMapConfig : EntityMappingConfiguration<View_com_notify_template>
    {
        public override void Map(EntityTypeBuilder<View_com_notify_template>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

