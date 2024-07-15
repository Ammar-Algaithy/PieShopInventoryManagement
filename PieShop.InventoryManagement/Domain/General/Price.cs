namespace PieShop.InventoryManagement.Domain.General;

public class Price
{
    public double ItemPrice { get; set; }
    public Currency Currency { get; set; }

    public override string ToString()
    {
        return $"{ItemPrice} {Currency}";
    }
    public Price(double itemPrice, Currency currency)
    {
        ItemPrice = itemPrice;
        Currency = currency;
    }
}