using Microsoft.EntityFrameworkCore;
using Simple_Food_Delivery.ModalWindows;
using Simple_Food_Delivery.Models;
using Simple_Food_Delivery.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Simple_Food_Delivery.Pages
{
    public partial class OrderDetails : Page
    {
        public static int SelectedItemOrderID;
        FCDBContext Context = new FCDBContext();

        List<Orders> orders = new List<Orders>();
        List<OrdersCompositions> ordersCompositions = new List<OrdersCompositions>();
        List<ActionTypes> actionTypes = new List<ActionTypes>();
        public OrderDetails()
        {
            InitializeComponent();
            orders = Context.Orders.Where(w => w.OrderId == SelectedItemOrderID).ToList();
            ordersCompositions = Context.OrdersCompositions.Where(w => w.OrderId == SelectedItemOrderID).ToList();
            actionTypes = Context.ActionTypes.ToList();

            IC1.ItemsSource = orders;
            IC2.ItemsSource = ordersCompositions;
            if (orders[0].OrderStatus != 1) 
            { 
                LowGrid.Visibility = Visibility.Hidden;
                LowSV.SetValue(Grid.RowSpanProperty, 3);
                IC2.SetValue(Grid.RowSpanProperty, 3);
                LastRow.Height = new GridLength(0);
            }
            if (Online.CurrentWorker != null)
            {
                if(Online.CurrentWorker.RoleId == 3) { AcceptB.Visibility = Visibility.Visible; }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in IC1.Items)
            {
                var container = IC1.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                if (container != null)
                {
                    Grid grid = WorkWithUIElements.FindVisualChild<Grid>(container);
                    if (grid != null)
                    {
                        TextBlock names = grid.Children.OfType<TextBlock>().Where(t => t.Name == "Names").First();
                        TextBlock emailandphone = grid.Children.OfType<TextBlock>().Where(t => t.Name == "EmailAndPhone").First();
                        TextBlock status = grid.Children.OfType<TextBlock>().Where(t => t.Name == "StatusTB").First();
                        
                        ActionTypes actionType = actionTypes.First(w => w.ActionTypeId == orders[0].OrderStatus);
                        status.Text = "Статус:" + " " + actionType.ActionTitle;
                        if (Online.CurrentUser != null)
                        {
                            names.Text = Online.CurrentUser.UserName + "  " + Online.CurrentUser.UserSurName;
                            emailandphone.Text = Online.CurrentUser.UserEmail + "  " + Online.CurrentUser.UserPhone;
                        }
                        if (Online.CurrentWorker != null)
                        {
                            names.Text = Online.CurrentWorker.WorkerName + "  " + Online.CurrentWorker.WorkerSurName;
                            emailandphone.Text = Online.CurrentWorker.WorkerEmail + "  " + Online.CurrentWorker.WorkerPhone;
                        }
                    }
                }
            }

            foreach (var item in IC2.Items)
            {
                var container = IC2.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                if (container != null)
                {
                    Grid grid = WorkWithUIElements.FindVisualChild<Grid>(container);
                    if (grid != null )
                    {
                        Image productimage = grid.Children.OfType<Image>().Where(t => t.Name == "ProductImage").First();
                        TextBlock foodprice = grid.Children.OfType<TextBlock>().Where(t => t.Name == "FoodPrice").First();
                        TextBlock productname = grid.Children.OfType<TextBlock>().Where(t => t.Name == "Title").First();

                        Products product = Context.Products.Where(p => p.ProductName == productname.Text).First();
                        productimage.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(product.ProductImage);
                        foodprice.Text = Convert.ToString(product.UnitPrice);
                        string temp = "";
                        for (global::System.Int32 i = 0; i < foodprice.Text.Length; i++)
                        {
                            if (foodprice.Text[i] != ',') { temp += Convert.ToString(foodprice.Text[i]); }
                            else { break; }
                        }
                        foodprice.Text = temp + "₽";
                    }
                }
            }
        }

        private void OtmenaB_Click(object sender, RoutedEventArgs e)
        {
            if (Online.CurrentUser != null)
            {
                bool result = MyMessageBox.ShowWithChoice("Вы действительно хотите отменить заказ? :(", MyMessageBoxImages.Warning);
                if (result == true)
                {
                    var temp = Context.Orders.First(w => w.OrderId == SelectedItemOrderID);
                    temp.OrderStatus = 2;


                    Context.Orders.Update(temp);
                    Context.SaveChanges();
                    MyLogger.WriteLogInDB(2, Online.CurrentUser.UserId, Context);
                    
                    WorkWithUIElements.MathWithCountsOfProducts(ordersCompositions, temp.OrderStatus);

                    MyMessageBox.ShowMessage("Заказ отменен :(");
                    NavigationService.Navigate(new OrdersPage());
                }
            }
            if (Online.CurrentWorker != null)
            {
                if (Online.CurrentWorker.RoleId == 3)
                {
                    bool result = MyMessageBox.ShowWithChoice("Вы действительно хотите отказаться от заказа?", MyMessageBoxImages.Warning);
                    if (result == true)
                    {
                        MyLogger.WriteLogInDB(3, Online.CurrentWorker.WorkerId, Context);
                        MyMessageBox.ShowMessage("Вы отказались от заказа :(");
                    }
                }
                if (Online.CurrentWorker.RoleId != 3)
                {
                    bool result = MyMessageBox.ShowWithChoice("Вы действительно хотите отменить заказ?", MyMessageBoxImages.Warning);
                    if (result == true)
                    {
                        var temp = Context.Orders.First(w => w.OrderId == SelectedItemOrderID);
                        temp.OrderStatus = 4;
                        Context.Orders.Update(temp);
                        Context.SaveChanges();
                        MyLogger.WriteLogInDB(4, Online.CurrentWorker.WorkerId, Context);

                        WorkWithUIElements.MathWithCountsOfProducts(ordersCompositions, temp.OrderStatus);

                        MyMessageBox.ShowMessage("Заказ отменен");
                        NavigationService.Navigate(new OrdersPage());
                    }
                }
            }
        }

        private void CallB_Click(object sender, RoutedEventArgs e)
        {
            Workers courer = Context.Workers.First(w => w.RoleId == orders[0].CourierId);
            Clipboard.SetText(courer.WorkerPhone);
            MyMessageBox.ShowMessage("Номер телефона скопирован в буфер обмена", MyMessageBoxImages.Information);
        }

        private void MessageToSupportB_Click(object sender, RoutedEventArgs e)
        {
            MessageToSupport mts = new MessageToSupport();
            mts.ShowDialog();
        }

        private void AcceptB_Click(object sender, RoutedEventArgs e)
        {
            if (Online.CurrentWorker != null)
            {
                if (Online.CurrentWorker.RoleId == 3)
                {
                    bool result = MyMessageBox.ShowWithChoice("Вы доставили заказ?", MyMessageBoxImages.Warning);
                    if (result == true)
                    {
                        MyLogger.WriteLogInDB(5, Online.CurrentWorker.WorkerId, Context);
                        MyMessageBox.ShowMessage("Ура!");
                        var temp = Context.Workers.First(w => w.WorkerId == Online.CurrentWorker.WorkerId);
                        temp.Salary += 500;
                        Context.Workers.Update(temp);
                        Context.SaveChanges();

                        WorkWithUIElements.MathWithCountsOfProducts(ordersCompositions, 5);
                    }
                }
            }
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
    }
}
