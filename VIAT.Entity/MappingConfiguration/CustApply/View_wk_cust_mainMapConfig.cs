using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_wk_cust_mainMapConfig : EntityMappingConfiguration<View_wk_cust_main>
    {
        public override void Map(EntityTypeBuilder<View_wk_cust_main>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

