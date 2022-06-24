using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Viat_app_hp_contract_shareMapConfig : EntityMappingConfiguration<Viat_app_hp_contract_share>
    {
        public override void Map(EntityTypeBuilder<Viat_app_hp_contract_share>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

