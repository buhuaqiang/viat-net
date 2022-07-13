using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_wk_cont_stretagy_detailMapConfig : EntityMappingConfiguration<Viat_wk_cont_stretagy_detail>
    {
        public override void Map(EntityTypeBuilder<Viat_wk_cont_stretagy_detail>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

