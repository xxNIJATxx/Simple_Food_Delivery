using Simple_Food_Delivery.ModalWindows;
using Simple_Food_Delivery.Models;
using Simple_Food_Delivery.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Simple_Food_Delivery.Pages
{
    public partial class MainPage : Page
    {
        FCDBContext Context = new FCDBContext();
        List<Products> products = new List<Products>();
        static public bool IsNavigatedFromGreetingPageOrAuthorizationPageOrAfterOrder;
        public MainPage()
        {
            InitializeComponent();
            if (Online.CurrentUser != null | Online.CurrentWorker != null) { SignOutB.Visibility = Visibility.Visible; }
            if(Online.CurrentWorker != null)
            {
                if (Online.CurrentWorker.WorkerId != 3)
                {
                    ToManagePage.Visibility = Visibility.Visible;
                }
                if (Online.CurrentWorker.WorkerId == 3)
                {
                    FeedBackB.Visibility = Visibility.Hidden;
                    GoToCartB.Visibility = Visibility.Hidden;
                }
            }
            products = Context.Products.Where(p => p.CountLeft > 0).ToList();
            LB.ItemsSource = products;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack & IsNavigatedFromGreetingPageOrAuthorizationPageOrAfterOrder == true)
            {
                NavigationService.RemoveBackEntry();
                NavigationService.RemoveBackEntry();
                IsNavigatedFromGreetingPageOrAuthorizationPageOrAfterOrder = false;
            }
        }



        private void SelectB_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button button = sender as Button;
                Grid grid = button.Parent as Grid;
                TextBlock tb = grid.Children.OfType<TextBlock>().First();

                foreach (Products item in LB.Items)
                {
                    if (item.ProductName == tb.Text)
                    {
                        LB.SelectedItem= item;
                    }
                }
            }
            if (LB.SelectedItem != null)
            {
                Products product = (Products)LB.SelectedItem;
                FoodDisplay.products.Add(product);
                FoodDisplay foodDisplay = new FoodDisplay();

                MainGrid.Opacity = 0.5;
                foodDisplay.ShowDialog();
                MainGrid.Opacity = 1;
                LB.SelectedItem = null;
                FoodDisplay.products.Clear();
            }
        }
        private void LB_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            LB.SelectedItem = null;
        }

        private void PA_Click(object sender, RoutedEventArgs e)
        {
            if (Online.CurrentUser != null)
            {
                PersonalAccount personalAccount = new PersonalAccount();
                MainGrid.Opacity = 0.5;
                personalAccount.ShowDialog();
                MainGrid.Opacity = 1;
            }
            if (Online.CurrentWorker != null)
            {
                PersonalAccount personalAccount = new PersonalAccount();
                MainGrid.Opacity = 0.5;
                personalAccount.ShowDialog();
                MainGrid.Opacity = 1;
            }
            if (Online.CurrentUser == null & Online.CurrentWorker == null)
            {
                NavigationService.Navigate(new GreetingPage());
            }
        }
        private void FeedBackB_Click(object sender, RoutedEventArgs e)
        {
            MessageToSupport messageToSupport = new MessageToSupport();
            MainGrid.Opacity = 0.5;
            messageToSupport.ShowDialog();
            MainGrid.Opacity = 1;
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

        private void SignOutB_Click(object sender, RoutedEventArgs e)
        {
            Online.CurrentWorker = null; Online.CurrentUser = null;
            SignOutB.Visibility = Visibility.Hidden;
            ToManagePage.Visibility = Visibility.Hidden;
            NavigationService.Navigate(new MainPage());
            IsNavigatedFromGreetingPageOrAuthorizationPageOrAfterOrder = true;
        }



        private void AllFoodsB_Click(object sender, RoutedEventArgs e)
        {
            products = Context.Products.Where(p => p.CountLeft > 0).ToList();
            LB.ItemsSource = products;
        }

        private void BurgersB_Click(object sender, RoutedEventArgs e)
        {
            products = Context.Products.Where(x => x.ProductTypeId == 1 & x.CountLeft > 0).ToList();
            LB.ItemsSource = products;
        }

        private void Shaverma_Click(object sender, RoutedEventArgs e)
        {
            products = Context.Products.Where(x => x.ProductTypeId == 2 & x.CountLeft > 0).ToList();
            LB.ItemsSource = products;
        }

        private void Sashliki_Click(object sender, RoutedEventArgs e)
        {
            products = Context.Products.Where(x => x.ProductTypeId == 3 & x.CountLeft > 0).ToList();
            LB.ItemsSource = products;
        }
        private void Pizza_Click(object sender, RoutedEventArgs e)
        {
            products = Context.Products.Where(x => x.ProductTypeId == 4 & x.CountLeft > 0).ToList();
            LB.ItemsSource = products;
        }
        private void Sushi_Click(object sender, RoutedEventArgs e)
        {
            products = Context.Products.Where(x => x.ProductTypeId == 5 & x.CountLeft > 0).ToList();
            LB.ItemsSource = products;
        }
        private void Salates_Click(object sender, RoutedEventArgs e)
        {
            products = Context.Products.Where(x => x.ProductTypeId == 6 & x.CountLeft > 0).ToList();
            LB.ItemsSource = products;
        }

        private void Drinks_Click(object sender, RoutedEventArgs e)
        {
            products = Context.Products.Where(x => x.ProductTypeId == 7 & x.CountLeft > 0).ToList();
            LB.ItemsSource = products;
        }
        private void Souses_Click(object sender, RoutedEventArgs e)
        {
            products = Context.Products.Where(x => x.ProductTypeId == 8 & x.CountLeft > 0).ToList();
            LB.ItemsSource = products;
        }

        private void GoToCartB_Click(object sender, RoutedEventArgs e)
        {
            if (Online.CurrentUser == null & Online.CurrentWorker == null)
            {
                NavigationService.Navigate(new GreetingPage());
            }
            else
            {
                NavigationService.Navigate(new CartPage());
            }
        }

        private void ToOrdersPage_Click(object sender, RoutedEventArgs e)
        {
            if (Online.CurrentUser == null & Online.CurrentWorker == null)
            {
                NavigationService.Navigate(new GreetingPage());
            }
            else
            {
                NavigationService.Navigate(new OrdersPage());
            }
        }

        private void ToManagePage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagingPage());
        }
    }
}
