using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_com_notify_templateMapConfig : EntityMappingConfiguration<Viat_com_notify_template>
    {
        public override void Map(EntityTypeBuilder<Viat_com_notify_template>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

