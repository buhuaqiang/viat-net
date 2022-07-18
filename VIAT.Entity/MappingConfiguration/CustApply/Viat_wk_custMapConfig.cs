using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_wk_custMapConfig : EntityMappingConfiguration<Viat_wk_cust>
    {
        public override void Map(EntityTypeBuilder<Viat_wk_cust>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

