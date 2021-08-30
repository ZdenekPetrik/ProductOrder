using System.Data.Entity.ModelConfiguration;

namespace DBProductOrder
{ 

    public class CustomerConfigurations : EntityTypeConfiguration<Customer>
    {
        public CustomerConfigurations()
        {
            this.Property(s => s.ClientName)
                .IsRequired()
                .HasMaxLength(50);

           

    }
  }
}