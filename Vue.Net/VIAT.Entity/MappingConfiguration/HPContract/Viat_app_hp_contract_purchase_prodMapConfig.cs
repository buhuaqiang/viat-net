using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_app_hp_contract_purchase_prodMapConfig : EntityMappingConfiguration<Viat_app_hp_contract_purchase_prod>
    {
        public override void Map(EntityTypeBuilder<Viat_app_hp_contract_purchase_prod>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

