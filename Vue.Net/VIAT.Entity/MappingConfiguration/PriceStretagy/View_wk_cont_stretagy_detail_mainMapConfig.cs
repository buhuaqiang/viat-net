using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_wk_cont_stretagy_detail_mainMapConfig : EntityMappingConfiguration<View_wk_cont_stretagy_detail_main>
    {
        public override void Map(EntityTypeBuilder<View_wk_cont_stretagy_detail_main>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

