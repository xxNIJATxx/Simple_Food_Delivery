using Microsoft.EntityFrameworkCore;
using Simple_Food_Delivery.Models;
using Simple_Food_Delivery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Simple_Food_Delivery.Pages
{
    public partial class CartPage : Page
    {
        FCDBContext Context = new FCDBContext();
        List<Cart> carts = new List<Cart>();
        public CartPage()
        {
            InitializeComponent();

            if (Online.CurrentUser != null)
            {
                carts = Context.Cart.Where(u => u.UserId == Online.CurrentUser.UserId).ToList();
            }
            if (Online.CurrentWorker != null)
            {
                carts = Context.Cart.Where(u => u.UserId == Online.CurrentWorker.WorkerId).ToList();
            }

            IC1.ItemsSource = carts;
            decimal temp = 0;
            foreach (var item in carts)
            {
                temp += item.FoodPrice;
            }
            FinalPrice.Text += " " + string.Format("{0:C0}", temp);


        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(w => w.Title == "MainWindow");
            ActionsWithWindows.CloseWindow(mainWindow);
        }

        private void MaxB_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(w => w.Title == "MainWindow");
            ActionsWithWindows.MaxWindow(mainWindow);
        }

        private void MinB_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(w => w.Title == "MainWindow");
            ActionsWithWindows.MinWindow(mainWindow);
        }



        private void DelB_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Grid grid = button.Parent as Grid;
            TextBlock tb = grid.Children.OfType<TextBlock>().First();

            foreach (Cart item in IC1.Items)
            {
                if (item.ProductName == tb.Text)
                {
                    Context.Remove(item);
                    Context.SaveChanges();
                    
                    decimal temp = WorkWithUIElements.SumAllPrices(Context, item.UserId);
                    FinalPrice.Text = "Итого: ";
                    FinalPrice.Text += string.Format("{0:C0}", temp);

                    if (Online.CurrentUser != null)
                    {
                        carts = Context.Cart.Where(u => u.UserId == Online.CurrentUser.UserId).ToList();
                    }
                    if (Online.CurrentWorker != null)
                    {
                        carts = Context.Cart.Where(u => u.UserId == Online.CurrentWorker.WorkerId).ToList();
                    }

                    IC1.ItemsSource = carts;
                }
            }
        }

        private void MinusB_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Grid grid = button.Parent as Grid;
            TextBlock tb = grid.Children.OfType<TextBlock>().First();

            foreach (Cart item in IC1.Items)
            {
                if (item.ProductName == tb.Text)
                {
                    if (item.CountOfProduct > 1) 
                    {
                        item.CountOfProduct -= 1;
                        Context.Cart.Update(item);
                        Context.SaveChanges();

                        decimal temp = WorkWithUIElements.SumAllPrices(Context, item.UserId);
                        FinalPrice.Text = "Итого: ";
                        FinalPrice.Text += string.Format("{0:C0}", temp);

                        if (Online.CurrentUser != null)
                        {
                            carts = Context.Cart.Where(u => u.UserId == Online.CurrentUser.UserId).ToList();
                        }
                        if (Online.CurrentWorker != null)
                        {
                            carts = Context.Cart.Where(u => u.UserId == Online.CurrentWorker.WorkerId).ToList();
                        }

                        IC1.ItemsSource = carts;
                    }

                    else { MyMessageBox.ShowMessage("Количество еды не может быть ниже 1!", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                }
            }
        }
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Grid grid = button.Parent as Grid;
            TextBlock tb = grid.Children.OfType<TextBlock>().First();

            foreach (Cart item in IC1.Items)
            {
                if (item.ProductName == tb.Text)
                {
                    if (item.CountOfProduct > 0)
                    {
                        item.CountOfProduct += 1;
                        Context.Cart.Update(item);
                        Context.SaveChanges();

                        decimal temp = WorkWithUIElements.SumAllPrices(Context, item.UserId);
                        FinalPrice.Text = "Итого: ";
                        FinalPrice.Text += string.Format("{0:C0}", temp);

                        if (Online.CurrentUser != null)
                        {
                            carts = Context.Cart.Where(u => u.UserId == Online.CurrentUser.UserId).ToList();
                        }
                        if (Online.CurrentWorker != null)
                        {
                            carts = Context.Cart.Where(u => u.UserId == Online.CurrentWorker.WorkerId).ToList();
                        }

                        IC1.ItemsSource = carts;
                    }
                }
            }
        }


        private void MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            Workers worker = Context.Workers.First(w => w.RoleId == 3);
            Orders order = new Orders()
            {
                OrderStatus = 1,
                CourierId = worker.WorkerId,
                OrderDate = DateTime.Now
            };
            
            if(Online.CurrentUser != null) 
            { 
                order.UserId = Online.CurrentUser.UserId;
                order.UserAddress = Online.CurrentUser.UserAddress;
                order.FinalPrice = WorkWithUIElements.SumAllPrices(Context, Online.CurrentUser.UserId);
            }
            if (Online.CurrentWorker != null)
            {
                order.UserId = Online.CurrentWorker.WorkerId;
                order.UserAddress = Online.CurrentWorker.WorkerAddress;
                order.FinalPrice = WorkWithUIElements.SumAllPrices(Context, Online.CurrentWorker.WorkerId);
            }
            DateTime dateTime = DateTime.Now;
            DateTime newdateTime = dateTime.AddMinutes(30);
            order.DeliveryDate = newdateTime;

            if (carts.Count < 2 & carts.Count > 0)
            {
                OrdersCompositions ordersCompositions = new OrdersCompositions();
                Context.Orders.Add(order);
                Context.SaveChanges();

                Cart item = carts[0];
                ordersCompositions.Product = item.ProductName;
                ordersCompositions.CountOfProduct = item.CountOfProduct;
                ordersCompositions.OrderId = order.OrderId;
                Context.OrdersCompositions.Add(ordersCompositions);
                Context.SaveChanges();

                Products thisproduct = Context.Products.FirstOrDefault(x => x.ProductName == item.ProductName);
                thisproduct.UnitsOnOrder += item.CountOfProduct;
                thisproduct.CountLeft -= item.CountOfProduct;
                Context.Products.Update(thisproduct);
                Context.SaveChanges();

                Context.Cart.Remove(item);
                Context.SaveChanges();
                carts.Clear();
                IC1.ItemsSource = carts;
            }
            if (carts.Count > 1)
            {
                Context.Orders.Add(order);
                Context.SaveChanges();

                foreach (Cart item in carts)
                {
                    OrdersCompositions ordersCompositions = new OrdersCompositions();
                    ordersCompositions.Product = item.ProductName;
                    ordersCompositions.CountOfProduct = item.CountOfProduct;
                    ordersCompositions.OrderId = order.OrderId;
                    Context.OrdersCompositions.Add(ordersCompositions);
                    Context.SaveChanges();

                    Products thisproduct = Context.Products.FirstOrDefault(x => x.ProductName == item.ProductName);
                    thisproduct.UnitsOnOrder += item.CountOfProduct;
                    thisproduct.CountLeft -= item.CountOfProduct;
                    Context.Products.Update(thisproduct);
                    Context.SaveChanges();
                }

                Context.Cart.RemoveRange(carts);
                Context.SaveChanges();
                carts.Clear();
                IC1.ItemsSource = carts;
            }
            if(Online.CurrentUser != null) { MyLogger.WriteLogInDB(6, Online.CurrentUser.UserId, Context); }
            if(Online.CurrentWorker != null) { MyLogger.WriteLogInDB(6, Online.CurrentWorker.WorkerId, Context); }
            MyMessageBox.ShowMessage("Заказ успешно оформлен! Еда будет у вас в течении 30 минут :)");
            MainPage.IsNavigatedFromGreetingPageOrAuthorizationPageOrAfterOrder = true;
            NavigationService.Navigate(new MainPage());
        }
    }
}
