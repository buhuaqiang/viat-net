using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Viat_app_power_contract_ship_dataMapConfig : EntityMappingConfiguration<Viat_app_power_contract_ship_data>
    {
        public override void Map(EntityTypeBuilder<Viat_app_power_contract_ship_data>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

