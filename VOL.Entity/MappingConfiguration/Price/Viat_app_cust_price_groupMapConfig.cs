using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Viat_app_cust_price_groupMapConfig : EntityMappingConfiguration<Viat_app_cust_price_group>
    {
        public override void Map(EntityTypeBuilder<Viat_app_cust_price_group>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

