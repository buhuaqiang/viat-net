using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_app_power_contract_mainMapConfig : EntityMappingConfiguration<View_app_power_contract_main>
    {
        public override void Map(EntityTypeBuilder<View_app_power_contract_main>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

