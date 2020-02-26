using System;
using System.Collections.Generic;
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

    public static class DiscountCalculator
    {
        // Used primarily for Unit Tests
        public static IList<string> DebugMessages { get; set; }

        public static void ApplyDiscount(ShoppingCart cart)
        {
            DebugMessages.Clear();

            if (!cart.IsValid)
            {
                DebugMessages.Add("Error, cart is not valid");
                return;
            }

            if (cart.Orders.Count < 0)
            {
                DebugMessages.Add("No discount applied, order count is empty");
                return;
            }

            else if (cart.Orders.Count == 1)
            {
                DebugMessages.Add("No discount applied, order count is only 1");
                return;
            }

            foreach (var order in cart.Orders)
            {
                if (order.PurchaseQuantity > 1)
                {
                    order.TotalPrice = (GlobalConstants.DEFAULT_DISCOUNT * order.ProductItem.Price)
                        + (order.ProductItem.Price * (order.PurchaseQuantity - 1));

                    DebugMessages.Add("Discount applied on: " + order.ID + ", due to quantity > 1");
                }
            }
        }
    }
}
