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
            ShoppingCartUtils.SetTotalPriceWithDiscount(cart);

            Assert.True(ShoppingCartUtils.DebugMessages.Contains("No discount applied, order count is empty"));
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
                new ItemOrder(products[0], 1),
            };

            ShoppingCart cart = new ShoppingCart(itemOrders);
            ShoppingCartUtils.SetTotalPriceWithDiscount(cart);

            Assert.Equal((decimal) 129.40, cart.TotalPrice);
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
            ShoppingCartUtils.SetTotalPriceWithDiscount(cart);

            Assert.Equal((decimal) 304.53, cart.TotalPrice);
        }

        [Fact]
        public void ApplyDiscountWhenCartHasTwoItemsDiscountFalseTest()
        {
            List<Category> categoriesKeyboard = new List<Category>()
            {
                new Category("Keyboards", ""),
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
                new ItemOrder(products[0], 1),
                new ItemOrder(products[1], 1),
            };

            ShoppingCart cart = new ShoppingCart(itemOrders);
            ShoppingCartUtils.SetTotalPriceWithDiscount(cart);

            Assert.Equal((decimal) 181.60, cart.TotalPrice);
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
                new ItemOrder(products[1], 25), // 25 (PurchasedQuantity) > 20 (StockQuantity)
            };

            ShoppingCart cart = new ShoppingCart(itemOrders);
            ShoppingCartUtils.SetTotalPriceWithDiscount(cart);

            Assert.True(ShoppingCartUtils.DebugMessages.Contains("Error, cart is not valid"));
        }
    }
}