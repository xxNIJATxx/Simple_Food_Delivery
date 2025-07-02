using Simple_Food_Delivery.Models;
using Simple_Food_Delivery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Simple_Food_Delivery.Pages
{
    public partial class OrdersPage : Page
    {
        FCDBContext Context = new FCDBContext();
        public List<Orders> orders { get; set; } = new List<Orders>();
        public OrdersPage()
        {
            InitializeComponent();
            if (Online.CurrentUser != null)
            {
                orders = Context.Orders.Where(w => w.UserId == Online.CurrentUser.UserId & w.OrderStatus == 1).ToList();
                LB.ItemsSource = orders;
            }
            if (Online.CurrentWorker != null)
            {
                if (Online.CurrentWorker.RoleId == 3)
                {
                    orders = Context.Orders.Where(w => w.OrderStatus == 1).ToList();
                    LB.ItemsSource = orders;
                }
                else
                {   
                    orders = Context.Orders.Where(w => w.UserId == Online.CurrentWorker.WorkerId & w.OrderStatus == 1).ToList();
                    LB.ItemsSource = orders;
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainPage.IsNavigatedFromGreetingPageOrAuthorizationPageOrAfterOrder == true)
            {
                NavigationService.RemoveBackEntry();
                MainPage.IsNavigatedFromGreetingPageOrAuthorizationPageOrAfterOrder = false;
            }

            if (orders.Count > 0)
            {
                List<ActionTypes> actiontypes = Context.ActionTypes.ToList();

                foreach (Orders item in LB.Items)
                {
                    var container = LB.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                    if (container != null)
                    {
                        Grid grid = WorkWithUIElements.FindVisualChild<Grid>(container);
                        if (grid != null & orders[0].OrderStatus == 1)
                        {
                            ActionTypes action = actiontypes.First(w => w.ActionTypeId == 1);
                            TextBlock tb = grid.Children.OfType<TextBlock>().Where(t => t.Name == "Status").First();
                            tb.Text = $"Статус: {action.ActionTitle}";
                        }
                    }
                }
            }
        }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button button = sender as Button;
                Grid grid = button.Parent as Grid;
                TextBlock tb = grid.Children.OfType<TextBlock>().First();

                string temps = "";
                int temp = 0;
                for (global::System.Int32 i = 0; i < tb.Text.Length; i++)
                {
                    if (i > 6)
                    {
                        temps += Convert.ToString(tb.Text[i]);
                    }
                }
                int.TryParse(temps, out temp);

                foreach (Orders item in LB.Items)
                {
                    if (item.OrderId == temp)
                    {
                        OrderDetails.SelectedItemOrderID = temp;
                        NavigationService.Navigate(new OrderDetails());
                    }
                }
            }
        }


        private void ActiveOrdersB_Click(object sender, RoutedEventArgs e)
        {
            if (Online.CurrentUser != null)
            {
                orders = Context.Orders.Where(w => w.UserId == Online.CurrentUser.UserId & w.OrderStatus == 1).ToList();
                LB.ItemsSource = orders;
            }
            if (Online.CurrentWorker != null)
            {
                orders = Context.Orders.Where(w => w.UserId == Online.CurrentWorker.WorkerId & w.OrderStatus == 1).ToList();
                LB.ItemsSource = orders;
            }
            MainPage.IsNavigatedFromGreetingPageOrAuthorizationPageOrAfterOrder = true;
            NavigationService.Navigate(new OrdersPage());
        }

        private void CompletedOrdersB_Click(object sender, RoutedEventArgs e)
        {
            if (Online.CurrentUser != null)
            {
                orders = Context.Orders.Where(w => w.UserId == Online.CurrentUser.UserId & w.OrderStatus != 1).ToList();
                LB.ItemsSource = orders;
            }
            if (Online.CurrentWorker != null)
            {
                orders = Context.Orders.Where(w => w.UserId == Online.CurrentWorker.WorkerId & w.OrderStatus != 1).ToList();
                LB.ItemsSource = orders;
            }
            if (orders.Count > 0)
            {
                List<ActionTypes> actiontypes = Context.ActionTypes.ToList();

                foreach (Orders item in LB.Items)
                {
                    var container = LB.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                    if (container != null)
                    {
                        Grid grid = WorkWithUIElements.FindVisualChild<Grid>(container);
                        if (grid != null & orders[0].OrderStatus != 1)
                        {
                            ActionTypes action = actiontypes.First(w => w.ActionTypeId == item.OrderStatus);
                            TextBlock tb = grid.Children.OfType<TextBlock>().First(t => t.Name == "Status");
                            tb.Text = $"Статус: {action.ActionTitle}";
                            int a = 5;
                        }
                    }
                }
                LB.ItemsSource = orders;
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
