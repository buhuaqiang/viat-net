using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_wk_approve_level_settingMapConfig : EntityMappingConfiguration<Viat_wk_approve_level_setting>
    {
        public override void Map(EntityTypeBuilder<Viat_wk_approve_level_setting>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

