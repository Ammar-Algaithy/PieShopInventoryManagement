using System.Text;
using PieShop.InventoryManagement.Domain.General;
namespace PieShop.InventoryManagement.Domain.ProductManagement;
public partial class Product
{
    private int id;
    private string name = string.Empty;
    private string? description;
    public int Id 
    { 
        get { return id; }
        set
        {
            id = value;
        }
    }
    public string Name 
    { 
        get { return name; }
        set
        {
            name = value.Length > 50 ? value[..50] : value;
        } 
    }
    public string? Description 
    { 
        get { return description; }
        set 
        {
            if (value == null)
            {
                description = string.Empty;
            }
            else
            {
                description = value.Length > 250 ? value[..250] : value;
            }
        }
    }
    public int MaxItemsInstock { get; set; }
    public UnitType UnitType { get; set; }
    public int AmountInStock { get; private set; } 
    public bool IsBelowStockThreshold { get; private set; }
    public Price Price { get; set; }

    public Product(int id) : this(id, string.Empty)
    {
    }
    public Product(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public Product(int id, string name, string description, UnitType unitType, int amountInStock, int maxItemsInstock, Price price) 
    {
        Id = id;
        Name = name;
        Description = description;
        UnitType = unitType;
        AmountInStock = amountInStock;
        MaxItemsInstock = maxItemsInstock;
        Price = price;
        UpdateLowStock();

    }

    public void UseProduct(int items)
    {
        if (items <= AmountInStock)
        {
            AmountInStock -= items;
            UpdateLowStock();

            Log($"Amount is stock updated. Now, only {AmountInStock} left in stock.");
        }
        else
        {
            Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}." +
            $"{AmountInStock} available, but {items} requested.");
        }
    }

    public void AddToStock()
    {
        AmountInStock++;
    }

    public void AddToStock(int amount)
    {
        int newStock = AmountInStock + amount;
        if (newStock <= MaxItemsInstock)
        {
            AmountInStock += amount;
        }
        else
        {
            AmountInStock = MaxItemsInstock;
            Log($"{CreateSimpleProductRepresentation()} stock overflow. {newStock} is {AmountInStock}" +
            $" Item(s) orderd that could not be stored.");
        }
        if (AmountInStock > StockThreshold)
        {
            IsBelowStockThreshold = false;
        }
    }
    

    public void reduceStock(int items, string reason)
    {
        if (items <= AmountInStock)
        {
            AmountInStock -= items;
        }
        else
        {
            AmountInStock = 0;
        }
        Log(reason);
    }

    public string DisplayDetails()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{Id} {Name} \n{description}\n {Price} \n {AmountInStock} item(s) in stock");
        if (IsBelowStockThreshold)
        {
            sb.Append("\n!! STOCK NOW!!");
        }
        return sb.ToString();
    }

}