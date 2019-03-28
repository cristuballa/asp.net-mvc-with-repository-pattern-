using ApplicationCore.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Product : BaseEntity, IProduct
    {
        public string Description { get; set; }
        public string Barcode { get; set; }
        [Display(Name = "Stock No")]
        public string StockNo { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name="Unit Price")]
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Wholesale Price 1")]
        public decimal WholesalePrice1 { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Wholesale Price 2")]
        public decimal WholesalePrice2 { get; set; }
        public string ProductImage { get; set; }
        public Category Category { get; set; }
    }
}
