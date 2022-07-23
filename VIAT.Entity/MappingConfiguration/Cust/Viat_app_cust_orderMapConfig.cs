using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class Viat_app_cust_orderMapConfig : EntityMappingConfiguration<Viat_app_cust_order>
    {
        public override void Map(EntityTypeBuilder<Viat_app_cust_order>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

