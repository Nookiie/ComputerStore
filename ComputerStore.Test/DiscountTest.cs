using ComputerStore.Common;
using ComputerStore.Data.Models;
using System.Collections.Generic;
using Xunit;

namespace ComputerStore.Test
{
    public class DiscountTest
    {
        [Fact]
        public void ApplyDiscountWhenCartHasNoItemsTest()
        {
            ShoppingCart cart = new ShoppingCart();
            DiscountCalculator.ApplyDiscount(cart);

            Assert.True(DiscountCalculator.DebugMessages.Contains("No discount applied, order count is empty"));
        }

        [Fact]
        public void ApplyDiscountWhenCartHasOneItemTest()
        {
            List<Category> categories = new List<Category>()
            {
                new Category("Keyboards", ""),
                new Category("Hardware", ""),
            };

            List<ProductItem> products = new List<ProductItem>()
            {
                new ProductItem("Keywire Keyboard", "", 20, (decimal) 129.40, categories),
            };

            List<ItemOrder> itemOrders = new List<ItemOrder>()
            {
                new ItemOrder(products[0], 12),
            };

            ShoppingCart cart = new ShoppingCart(itemOrders);
            DiscountCalculator.ApplyDiscount(cart);

            Assert.True(DiscountCalculator.DebugMessages.Contains("No discount applied, order count has only one item"));
        }

        [Fact]
        public void ApplyDiscountWhenCartHasTwoItemsDiscountTrueTest()
        {
            List<Category> categoriesKeyboard = new List<Category>()
            {
                new Category("Keyboards", ""),
                new Category("Hardware", ""),
            };

            List<Category> categoriesHeadset = new List<Category>()
            {
                new Category("Hardware", ""),
                new Category("Headsets", ""),
            };

            List<ProductItem> products = new List<ProductItem>()
            {
                new ProductItem("Intel's Core i9-9900K", "", 20, (decimal) 129.40, categoriesKeyboard),
                new ProductItem("Razer BlackWidow Keyboard", "", 20, (decimal) 52.20, categoriesHeadset),
            };

            List<ItemOrder> itemOrders = new List<ItemOrder>()
            {
                new ItemOrder(products[0], 2),
                new ItemOrder(products[1], 1),
            };

            ShoppingCart cart = new ShoppingCart(itemOrders);
            DiscountCalculator.ApplyDiscount(cart);

            Assert.True(DiscountCalculator.DebugMessages.Contains("Discount applied on"));
        }

        [Fact]
        public void ApplyDiscountWhenCartHasTwoItemsDiscountFalseTest()
        {

        }

        [Fact]
        public void InvalidShoppingCartTest()
        {
            List<Category> categoriesKeyboard = new List<Category>()
            {
                new Category("Keyboards", ""),
                new Category("Hardware", ""),
            };

            List<Category> categoriesHeadset = new List<Category>()
            {
                new Category("Hardware", ""),
                new Category("Headsets", ""),
            };

            List<ProductItem> products = new List<ProductItem>()
            {
                new ProductItem("Intel's Core i9-9900K", "", 20, (decimal) 129.40, categoriesKeyboard),
                new ProductItem("Razer BlackWidow Keyboard", "", 20, (decimal) 52.20, categoriesHeadset),
            };

            List<ItemOrder> itemOrders = new List<ItemOrder>()
            {
                new ItemOrder(products[0], 2),
                new ItemOrder(products[1], 25),
            };

            ShoppingCart cart = new ShoppingCart(itemOrders);
            DiscountCalculator.ApplyDiscount(cart);

            Assert.True(DiscountCalculator.DebugMessages.Contains("Error, cart is not valid"));
        }
    }
}