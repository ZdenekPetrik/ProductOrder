using System.Data.Entity.ModelConfiguration;

namespace DBProductOrder
{ 

    public class ProductConfigurations : EntityTypeConfiguration<Product>
    {
        // ahoj ja jsem oprava
        public ProductConfigurations()
        {
             this.Property(s => s.ProductName)
                .IsRequired()
                .HasMaxLength(50);

    }
  }
}