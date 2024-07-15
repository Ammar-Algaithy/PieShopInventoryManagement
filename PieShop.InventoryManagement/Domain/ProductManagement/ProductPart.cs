namespace PieShop.InventoryManagement.Domain.ProductManagement;
public partial class Product
{
    public static int StockThreshold = 5;

    public static void ChangeStockThreshhold(int newStockThreshhold)
    {
        if (newStockThreshhold > 0)
        {
            StockThreshold = newStockThreshhold;
        }
    }
    public void UpdateLowStock()
    {
        if (AmountInStock < StockThreshold) // for now fixed value
        {
            IsBelowStockThreshold = true;
        }
    }

    private void Log(string message)
    {
        Console.WriteLine(message);
    }
    private string CreateSimpleProductRepresentation()
    {
        return $"Product {Id} ({Name})";
    }
}