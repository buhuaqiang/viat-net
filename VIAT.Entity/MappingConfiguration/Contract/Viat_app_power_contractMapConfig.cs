using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_app_power_contractMapConfig : EntityMappingConfiguration<Viat_app_power_contract>
    {
        public override void Map(EntityTypeBuilder<Viat_app_power_contract>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

