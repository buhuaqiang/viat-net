using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_app_power_contract_custMapConfig : EntityMappingConfiguration<Viat_app_power_contract_cust>
    {
        public override void Map(EntityTypeBuilder<Viat_app_power_contract_cust>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

