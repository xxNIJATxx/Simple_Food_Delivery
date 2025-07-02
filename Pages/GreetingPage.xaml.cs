
using Simple_Food_Delivery.Models;
using Simple_Food_Delivery.Pages;
using Simple_Food_Delivery.Services;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Simple_Food_Delivery
{
    public partial class GreetingPage : Page
    {
        FCDBContext Context = new FCDBContext();
        public GreetingPage()
        {
            InitializeComponent();
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

        //АВТОРИЗАЦИЯ
        private void EnterB_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text != "" & PBox.Password != "" & LoginTB.Text != null & PBox.Password != null)
            {
                if (Context.Users.Count() > 0)
                {
                    foreach (Users user in Context.Users)
                    {
                        if (user.UserLogin == LoginTB.Text & user.UserPassword == PBox.Password)
                        {
                            MainPage.IsNavigatedFromGreetingPageOrAuthorizationPageOrAfterOrder = true;
                            Online.CurrentUser = user;
                            NavigationService.Navigate(new MainPage());
                            return;
                        }
                    }
                }
                if (Context.Workers.Count() > 0)
                {
                    foreach (Workers worker in Context.Workers)
                    {
                        if (worker.WorkerLogin == LoginTB.Text & worker.WorkerPassword == PBox.Password)
                        {
                            MainPage.IsNavigatedFromGreetingPageOrAuthorizationPageOrAfterOrder = true;
                            Online.CurrentWorker = worker;
                            NavigationService.Navigate(new MainPage());
                            return;

                        }
                    }
                    MyMessageBox.ShowMessage("Введены неверные данные!", MyMessageBoxImages.Error, "ОШИБКА");
                    return;
                }
                else
                {
                    MyMessageBox.ShowMessage("Неверно введены данные!", MyMessageBoxImages.Error, "ОШИБКА"); return;
                }
                
            }
            else
            {
                MyMessageBox.ShowMessage("Не введены данные!", MyMessageBoxImages.Error, "ОШИБКА!"); return;
            }
        }
    }
}
