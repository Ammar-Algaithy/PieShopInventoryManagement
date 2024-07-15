using PieShop.InventoryManagement.Domain.General;
using PieShop.InventoryManagement.Domain.ProductManagement;

namespace PieShop.InventoryManagement.Tests;

public class ProductTests
{
    [Fact]
    public void UseProduct_Reduces_AmountInStock()
    {
        //Arrange
        Product product = new Product(1, "Apple Pie", "A delicious apple pie with a flaky crust", UnitType.PerBox, 0, 100, new Price(50, Currency.Dollar));

        product.AddToStock(100);

        //Act
        product.UseProduct(20);

        //Assert
        Assert.Equal(80, product.AmountInStock);

    }


    [Fact]
    public void UseProduct_ItemsHigherThanStock_NoChangetoStock()
    {
        //Arrange
        Product product = new Product(2, "Cherry Pie", "A sweet cherry pie with a golden brown crust", UnitType.PerItem, 0, 40, new Price(99, Currency.Dollar));

        product.AddToStock(10);

        //Act
        product.UseProduct(100);
        //Assert
        Assert.Equal(10, product.AmountInStock);
    }

    [Fact]
    public void UseProduct_Reduces_AmountInStock_StockBelowTreshold()
    {
        //Arrange
        Product product = new Product(3, "Pumpkin Pie", "A traditional pumpkin pie perfect for the holidays", UnitType.PerBox, 0, 100, new Price(99, Currency.Dollar));

        int increaseValue = 100;
        
        product.AddToStock(increaseValue);

        //Act
        product.UseProduct(increaseValue - 1);

        //Assert
        Assert.True(product.IsBelowStockThreshold);
    }

    [Fact]
    public void IncreaseStock_AddsOne()
    {
        //Arrange
        Product product = new Product(4, "Blueberry Pie", "A fresh blueberry pie with a hint of lemon", UnitType.PerKg, 0, 25, new Price(19, Currency.Dollar));

        //Act
        product.AddToStock();

        //Assert
        Assert.Equal(1, product.AmountInStock);
    }

    [Fact]
    public void IncreaseStock_AddsPassedInValue_BelowMaxAmount()
    {
        //Arrange
        Product product = new Product(5, "Pecan Pie", "A rich pecan pie with a buttery crust", UnitType.PerItem, 0, 20, new Price(24, Currency.Dollar));

        //Act
        product.AddToStock(20);

        //Assert
        Assert.Equal(20, product.AmountInStock);
    }

    [Fact]
    public void IncreaseStock_AddsPassedInValue_AboveMaxAmount()
    {
        //Arrange
        Product product = new Product(5, "Pecan Pie", "A rich pecan pie with a buttery crust", UnitType.PerItem, 0, 100, new Price(24, Currency.Dollar));

        //Act
        product.AddToStock(300);

        //Assert
        Assert.Equal(100, product.AmountInStock);
    }
}
