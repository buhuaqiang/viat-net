using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class view_dist_marginMapConfig : EntityMappingConfiguration<view_dist_margin>
    {
        public override void Map(EntityTypeBuilder<view_dist_margin>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

