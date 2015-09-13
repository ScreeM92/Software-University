namespace CentaurFactory.ExcelModel
{
    using System;
    using System.Text;

    public class DeliveryInfo
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal PricePerUnit { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("ProductId {0}\n", this.ProductId);
            sb.AppendFormat("Quantity {0}\n", this.Quantity);
            sb.AppendFormat("PricePerUnit {0}\n", this.PricePerUnit);
            sb.AppendFormat("Month {0}\n", this.Month);
            sb.AppendFormat("Year {0}\n", this.Year);

            return sb.ToString();
        }
    }
}
