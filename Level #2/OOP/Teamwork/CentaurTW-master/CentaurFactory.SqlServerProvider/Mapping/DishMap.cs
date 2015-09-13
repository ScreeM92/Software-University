using CentaurFactory.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentaurFactory.SqlServerProvider.Mapping
{
    public class DishMap : EntityTypeConfiguration<Dish>
    {
        public DishMap()
        {
            this.ToTable("Dish");

            this.HasKey(x => x.Id);

            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Name).HasColumnName("Name");
            this.Property(x => x.Price).HasColumnName("Price");
        }
    }
}
