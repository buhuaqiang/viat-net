using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class View_cust_price_detailMapConfig : EntityMappingConfiguration<View_cust_price_detail>
    {
        public override void Map(EntityTypeBuilder<View_cust_price_detail>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

