namespace PieShop.InventoryManagement.Domain.OrderManagement;
using System.Text;
public class Order
{
    public int Id { get; private set;}
    public DateTime OrderFulfilmentDate { get; private set;}
    public List<OrderItem> OrderItems { get; }
    public bool Fulfilled { get; set; } = false;

    public Order()
    {
        Id = new Random().Next(99999999);
        int numOfSeconds = new Random().Next(100);
        OrderFulfilmentDate = DateTime.Now.AddSeconds(numOfSeconds);
        OrderItems = new List<OrderItem>();
    }

    public string ShowOrderDetails()
    {
        StringBuilder orderDetails = new StringBuilder();

        orderDetails.AppendLine($"Order ID: {Id}");
        orderDetails.AppendLine($"Order fulfilment date: {OrderFulfilmentDate.ToShortTimeString()}");

        if (OrderItems != null)
        {
            foreach (OrderItem item in OrderItems)
            {
                orderDetails.AppendLine($"{item.ProductId}. {item.ProductName}: {item.AmountOrdered}");
            }
        }

        return orderDetails.ToString();
    }
}