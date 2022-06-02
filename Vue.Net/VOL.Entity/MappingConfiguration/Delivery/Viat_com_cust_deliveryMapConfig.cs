using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class Viat_com_cust_deliveryMapConfig : EntityMappingConfiguration<Viat_com_cust_delivery>
    {
        public override void Map(EntityTypeBuilder<Viat_com_cust_delivery>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

