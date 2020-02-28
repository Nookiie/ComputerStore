using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ComputerStore.Data.Models;

namespace ComputerStore.Common
{
    /*
    When purchasing a single product no discount is applied.
    If the customer buys several products of the same category 5% discount is applied on those products.
    Only the first copy of product has the right to the reduction.
    If a shopping cart is invalid because the there are not enough products in stock meaningful error must be returned.
    */

    public static class ShoppingCartUtils
    {
        // Used primarily for Unit Tests and Debugging
        public static IList<string> DebugMessages { get; set; } = new List<string>();

        public static void SetTotalPriceWithDiscount(ShoppingCart cart)
        {
            DebugMessages.Clear();

            if (!IsCartValid(cart))
            {
                DebugMessages.Add("Error, cart is not valid");
                return;
            }

            if (cart.Orders.Count <= 0)
            {
                DebugMessages.Add("No discount applied, order count is empty");
            }
          
            else if (cart.Orders.Count == 1)
            {
                DebugMessages.Add("No discount applied, order count is only 1");
            }

            var allCategories = new List<Category>();
            foreach (var order in cart.Orders)
            {
                if (order.PurchaseQuantity > 1)
                {
                    SetDiscount(order);

                    DebugMessages.Add("Discount applied on: " + order.ID + ", due to quantity > 1");
                }
                else
                {
                    allCategories.Concat(order.ProductItem.Categories);
                }

                var dupeCategories = allCategories.GroupBy(x => x.Name)
                                          .Where(x => x.Count() > 1)
                                          .Select(x => x.Key)
                                          .ToList();

                if (dupeCategories.Any())
                {
                    foreach(var category in dupeCategories)
                    {
                        if (order.ProductItem.Categories.Where(x => x.Name == category).Any())
                        {
                            SetDiscount(order);
                        }
                    }
                }
            }

            SetCartTotalPrice(cart);
        }

        public static bool IsCartValid(ShoppingCart cart)
        {
            foreach (var order in cart.Orders)
            {
                if (order.PurchaseQuantity > order.ProductItem.Quantity)
                {
                    DebugMessages.Add(string.Format
                        ("Error, PurchaseQuantity is larger than StockQuantity of Item: {0}", order.ProductItem.Name));
                    return false;
                }
            }

            return true;
        }

        public static void SetCartTotalPrice(ShoppingCart cart)
        {
            foreach (var order in cart.Orders)
            {
                cart.TotalPrice += order.TotalPrice;
            }
        }

        public static void SetDiscount(ItemOrder order)
        {
            order.TotalPrice = (order.ProductItem.Price - (GlobalConstants.DEFAULT_DISCOUNT * order.ProductItem.Price))
                        + (order.ProductItem.Price * (order.PurchaseQuantity - 1));
        }
    }
}
