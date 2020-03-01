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

        public static bool SetTotalPriceWithDiscount(ShoppingCart cart)
        {
            DebugMessages.Clear();

            if (cart.IsPaid)
            {
                DebugMessages.Add("Cart has already been processed");
                return false;
            }

            if (!IsCartValid(cart))
            {
                DebugMessages.Add("Cart is not valid");
                cart.IsValid = false;

                return false;
            }


            var cartCategories = new Dictionary<IEnumerable<string>, decimal>();

            foreach (var order in cart.ItemOrders)
            {
                if (order.PurchaseQuantity > 1)
                {
                    SetDiscountByQuantity(order);

                    DebugMessages.Add("Discount applied on: " + order.ID + ", due to quantity > 1");
                    cartCategories.Add(order.ProductItem.CategoryObjects.Select(x => x.Name), 0);
                }
                else
                {
                    cartCategories.Add(order.ProductItem.CategoryObjects.Select(x => x.Name), order.ProductItem.Price);
                }
            }
            SetDiscountByCategory(cart, cartCategories);

            return true;
        }

        private static bool IsCartValid(ShoppingCart cart)
        {
            if (cart.ItemOrders.Count <= 0)
            {
                DebugMessages.Add("No order count is empty");
                return false;
            }
            else
            {
                foreach (var order in cart.ItemOrders)
                {
                    if (order.PurchaseQuantity > order.ProductItem.Quantity)
                    {
                        DebugMessages.Add(string.Format
                            ("Error, PurchaseQuantity is larger than StockQuantity of Item: {0}", order.ProductItem.Name));
                        return false;
                    }
                }
            }

            return true;
        }

        private static void SetCartTotalPrice(ShoppingCart cart)
        {
            foreach (var order in cart.ItemOrders)
            {
                cart.TotalPrice += order.TotalPrice;
            }
        }

        private static void SetDiscountByQuantity(ItemOrder itemOrder)
        {
            itemOrder.TotalPrice = itemOrder.ProductItem.Price * (itemOrder.PurchaseQuantity - GlobalConstants.DEFAULT_DISCOUNT);
        }

        private static void SetDiscountByCategory(ShoppingCart cart, Dictionary<IEnumerable<string>, decimal> cartCategories)
        {
            SetCartTotalPrice(cart);
            Dictionary<string, decimal> categories = new Dictionary<string, decimal>();
            foreach (var distionaryEntry in cartCategories)
            {
                foreach (string categoryName in distionaryEntry.Key)
                {
                    categories.Add(categoryName, distionaryEntry.Value);
                }
            }

            var dupeCategories = categories.GroupBy(x => x.Key);

            var sum = dupeCategories.Sum(x => x.Key);

            cart.TotalPrice -= sum * GlobalConstants.DEFAULT_DISCOUNT;
        }
    }
}
