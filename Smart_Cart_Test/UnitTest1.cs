using Xunit;
using System;
using System.Collections.Generic;
using Smart_Cart;

namespace Smart_Cart_Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddingItemToShoppingCart()
        {
            // Arrange
            ShoppingCart.items = new List<string>();

            // Act
            ShoppingCart.items.Add("Apple");

            // Assert
            Assert.Equal("Apple", ShoppingCart.items[0]);
        }

        [Fact]
        public void TestRemoveItemFromShoppingCart()
        {
            //Arreng
            ShoppingCart.items = new List<string>();
            ShoppingCart.items.Add("Apple");
            ShoppingCart.items.Add("Milk");
            ShoppingCart.items.Add("Bread");

            //Act
            ShoppingCart.items.Remove("Apple");

            //Assert
            Assert.DoesNotContain("Apple", ShoppingCart.items);
        }

        [Fact]
        public void TestTotalCostCalculation()
        {
            // Arrange
            ShoppingCart.items = new List<string> { "Apple", "Milk", "Bread", "Tshirt", "Smartphone" };

            // Act
            int totalCost = ShoppingCart.CalculateTotalPrice();

            // Assert
            int expectedTotal = (int)Food.Apple + (int)Food.Milk + (int)Food.Bread + (int)Clothing.Tshirt + (int)Electronics.Smartphone;
            Assert.Equal(expectedTotal, totalCost);
        }
    }
}