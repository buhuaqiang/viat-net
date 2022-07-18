using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_wk_bid_price_apply_mainMapConfig : EntityMappingConfiguration<View_wk_bid_price_apply_main>
    {
        public override void Map(EntityTypeBuilder<View_wk_bid_price_apply_main>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

