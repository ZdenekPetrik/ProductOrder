using System.Data.Entity.ModelConfiguration;

namespace DBProductOrder
{ 

    public class ProductConfigurations : EntityTypeConfiguration<Product>
    {
        public ProductConfigurations()
        {
             this.Property(s => s.ProductName)
                .IsRequired()
                .HasMaxLength(50);

    }
  }
}