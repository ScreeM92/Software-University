using CentaurFactory.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentaurFactory.SqlServerProvider.Mapping
{
    public class ProductTypeMap : EntityTypeConfiguration<ProductType>
    {
        public ProductTypeMap()
        {
            this.ToTable("ProductType");

            this.HasKey(x => x.Id);

            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50);
        }
    }
}

