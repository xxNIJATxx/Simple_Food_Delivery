using Simple_Food_Delivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Simple_Food_Delivery.Services
{
    public static class WorkWithUIElements
    {
        public static void EnableButton(Button UIElement)
        {
          UIElement.IsEnabled = true;
        }
        public static void DisableButton(Button UIElement)
        {
            UIElement.IsEnabled = false;
        }

        public static decimal SumAllPrices(FCDBContext Context, int UserID)
        {
            decimal local = 0;
            foreach (Cart item in Context.Cart)
            {
                if (item.UserId == UserID)
                {
                    local += item.FoodPrice * item.CountOfProduct;
                }
            }
            if(Context.Cart.Count() == 0) { return 0; }
            return local;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj)
       where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }

            return null;
        }

        public static bool IsPropertyContainsWord(object property, string WordForSearch)
        {
            string temp = Convert.ToString(property);
            if(temp.Contains(WordForSearch)) { return true; }
            else { return false; }
        }

        public static void MathWithCountsOfProducts(List<OrdersCompositions> ordersCompositions, int orderstatus)
        {
            FCDBContext Context = new FCDBContext();

            if (orderstatus == 5)
            {
                foreach (var item in ordersCompositions)
                {
                    Products product = Context.Products.First(p => p.ProductName == item.Product);

                    product.UnitsSaled += item.CountOfProduct;
                    product.UnitsOnOrder -= item.CountOfProduct;
                    Context.Products.Update(product);
                    Context.SaveChanges();
                }
            }
            if (orderstatus != 5)
            {
                foreach (var item in ordersCompositions)
                {
                    Products product = Context.Products.First(p => p.ProductName == item.Product);

                    product.UnitsOnOrder -= item.CountOfProduct;
                    product.CountLeft += item.CountOfProduct;
                    Context.Products.Update(product);
                    Context.SaveChanges();
                }
            }
        }
    }
}
