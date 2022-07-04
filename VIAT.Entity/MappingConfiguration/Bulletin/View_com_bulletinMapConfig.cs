using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_com_bulletinMapConfig : EntityMappingConfiguration<View_com_bulletin>
    {
        public override void Map(EntityTypeBuilder<View_com_bulletin>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

