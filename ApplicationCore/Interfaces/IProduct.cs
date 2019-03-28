namespace ApplicationCore.Interfaces
{
    public interface IProduct
    {
        string Barcode { get; set; }
        string Description { get; set; }
        string ProductImage { get; set; }
        string StockNo { get; set; }
        string Unit { get; set; }
        decimal UnitPrice { get; set; }
        decimal WholesalePrice1 { get; set; }
        decimal WholesalePrice2 { get; set; }
    }
}