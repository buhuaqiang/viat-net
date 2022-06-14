using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class View_cust_custgroup_pricegroupMapConfig : EntityMappingConfiguration<View_cust_custgroup_pricegroup>
    {
        public override void Map(EntityTypeBuilder<View_cust_custgroup_pricegroup>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

