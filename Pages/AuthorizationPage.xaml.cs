using Simple_Food_Delivery.Models;
using Simple_Food_Delivery.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

namespace Simple_Food_Delivery.Pages
{
    public partial class AuthorizationPage : Page
    {
        FCDBContext Context = new FCDBContext();
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(w => w.Title == "MainWindow");
            ActionsWithWindows.CloseWindow(mainWindow);
        }

        private void MaxB_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(w => w.Title == "MainWindow");
            ActionsWithWindows.MaxWindow(mainWindow);
        }

        private void MinB_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(w => w.Title == "MainWindow");
            ActionsWithWindows.MinWindow(mainWindow);
        }

        private void DownloadImageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*"; ;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Avatar.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(openFileDialog.FileName);

                    MyMessageBox.ShowMessage("Фото загружено");
                }
            }
            catch(Exception ex)
            {
                MyMessageBox.ShowMessage("Вы выбрали файл с неверным форматом!!",MyMessageBoxImages.Error, "ОШИБКА");
            }
        }

        private void RegB_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text != "" & PBox.Password != "" & Number.Text != "" & Email.Text != "" & Address.Text != "" & NameTB.Text != "" & SurNameTB.Text != "")
            {
                ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                Users user = new Users
                {
                    UserPassword = PBox.Password,
                    UserPhone = Number.Text,
                    UserAddress = Address.Text,
                    UserName = NameTB.Text,
                    UserSurName = SurNameTB.Text,
                    UserImage = imageSourceConverter.ConvertToString(Avatar.Source)
                };

                bool checkloginexist = HelpForRegistration_Authorization.IsLoginExists(LoginTB.Text);
                if(checkloginexist == true) { MyMessageBox.ShowMessage("Такой логин существует! Придумайте другое имя",MyMessageBoxImages.Error, "ОШИБКА"); return; }
                if(checkloginexist == false) { user.UserLogin = LoginTB.Text; }


                bool checkemail = HelpForRegistration_Authorization.IsValidEmail(Email.Text);
                if(checkemail == true) { user.UserEmail =  Email.Text; }
                if(checkemail == false) { MyMessageBox.ShowMessage("Повторите ввод электронной почты правильно или введите другой", MyMessageBoxImages.Error, "ОШИБКА"); return; }

                string NumberForMethod = Number.Text;
                bool checknumberphone = HelpForRegistration_Authorization.IsValidNumberPhone(ref NumberForMethod);
                if (checknumberphone == true) { user.UserPhone = NumberForMethod; }
                if (checknumberphone == false) { MyMessageBox.ShowMessage("Повторите ввод номера правильно или введите другой номер", MyMessageBoxImages.Error, "ОШИБКА"); return; }


                if (LastNameTB.Text != "") { user.UserLastName = LastNameTB.Text; }

                Context.Users.Add(user);
                Context.SaveChanges();
                MyMessageBox.ShowMessage("Вы успешно зарегистрировались!");
                Online.CurrentUser = user;
                MyLogger.WriteLogInDB(10, user.UserId, Context);
                NavigationService.Navigate(new MainPage());
                MainPage.IsNavigatedFromGreetingPageOrAuthorizationPageOrAfterOrder = true;
            };
            if (LoginTB.Text == "" & PBox.Password == "" & Number.Text == "" & Email.Text == "" & Address.Text == "" & NameTB.Text == "" & SurNameTB.Text == "")
            {
                MyMessageBox.ShowMessage("Не введены данные!", MyMessageBoxImages.Error, "ОШИБКА");
            }


        }
    }
}
