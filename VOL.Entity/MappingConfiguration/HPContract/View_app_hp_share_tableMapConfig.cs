using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class View_app_hp_share_tableMapConfig : EntityMappingConfiguration<View_app_hp_share_table>
    {
        public override void Map(EntityTypeBuilder<View_app_hp_share_table>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

