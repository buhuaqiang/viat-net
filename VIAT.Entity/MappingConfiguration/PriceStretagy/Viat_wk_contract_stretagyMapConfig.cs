using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_wk_contract_stretagyMapConfig : EntityMappingConfiguration<Viat_wk_contract_stretagy>
    {
        public override void Map(EntityTypeBuilder<Viat_wk_contract_stretagy>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

