using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_app_hp_contract_allw_sumMapConfig : EntityMappingConfiguration<Viat_app_hp_contract_allw_sum>
    {
        public override void Map(EntityTypeBuilder<Viat_app_hp_contract_allw_sum>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

