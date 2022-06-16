using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Viat_app_hp_contractMapConfig : EntityMappingConfiguration<Viat_app_hp_contract>
    {
        public override void Map(EntityTypeBuilder<Viat_app_hp_contract>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

