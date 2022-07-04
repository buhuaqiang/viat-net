using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_app_power_contract_ship_data_prod_listMapConfig : EntityMappingConfiguration<View_app_power_contract_ship_data_prod_list>
    {
        public override void Map(EntityTypeBuilder<View_app_power_contract_ship_data_prod_list>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

