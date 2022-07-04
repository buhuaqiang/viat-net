using VIAT.Entity.MappingConfiguration;
using VIAT.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VIAT.Entity.MappingConfiguration
{
    public class App_TransactionAvgPriceMapConfig : EntityMappingConfiguration<App_TransactionAvgPrice>
    {
        public override void Map(EntityTypeBuilder<App_TransactionAvgPrice>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

