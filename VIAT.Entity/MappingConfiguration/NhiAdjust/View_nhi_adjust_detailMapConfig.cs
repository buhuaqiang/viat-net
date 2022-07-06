using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_nhi_adjust_detailMapConfig : EntityMappingConfiguration<View_nhi_adjust_detail>
    {
        public override void Map(EntityTypeBuilder<View_nhi_adjust_detail>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

