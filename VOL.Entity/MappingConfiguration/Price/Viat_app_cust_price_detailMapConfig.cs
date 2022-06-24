using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Viat_app_cust_price_detailMapConfig : EntityMappingConfiguration<Viat_app_cust_price_detail>
    {
        public override void Map(EntityTypeBuilder<Viat_app_cust_price_detail>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

