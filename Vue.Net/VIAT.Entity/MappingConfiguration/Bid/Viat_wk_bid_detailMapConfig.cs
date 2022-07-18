using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_wk_bid_detailMapConfig : EntityMappingConfiguration<Viat_wk_bid_detail>
    {
        public override void Map(EntityTypeBuilder<Viat_wk_bid_detail>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

