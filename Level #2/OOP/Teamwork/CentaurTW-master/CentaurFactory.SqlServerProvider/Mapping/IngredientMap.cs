using CentaurFactory.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentaurFactory.SqlServerProvider
{
    public class IngredientMap : EntityTypeConfiguration<Ingredient>
    {
        public IngredientMap()
        {
            this.ToTable("Ingredient");

            this.HasKey(x => x.Id);

            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Quantity).HasColumnName("Quantity");

            this.HasRequired(x => x.Product).WithMany(x => x.Ingredients);
            this.HasRequired(x => x.Dish).WithMany(x => x.Ingredients);
        }
    }
}
