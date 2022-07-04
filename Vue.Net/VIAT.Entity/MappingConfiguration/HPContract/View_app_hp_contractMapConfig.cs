using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_app_hp_contractMapConfig : EntityMappingConfiguration<View_app_hp_contract>
    {
        public override void Map(EntityTypeBuilder<View_app_hp_contract>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

