using Simple_Food_Delivery.Models;
using Simple_Food_Delivery.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Simple_Food_Delivery.ModalWindows
{
    public partial class PersonalAccount : Window
    {
        FCDBContext Context = new FCDBContext();
        string FirstChangedTextBlock = "";
        public PersonalAccount()
        {
            InitializeComponent();
            if (Online.CurrentUser != null)
            {
                LoginTB.Text = Online.CurrentUser.UserLogin;
                PBox.Password = Online.CurrentUser.UserPassword;
                PhoneNumber.Text = Online.CurrentUser.UserPhone;
                Email.Text = Online.CurrentUser.UserEmail;
                Address.Text = Online.CurrentUser.UserAddress;
                try
                {
                    Avatar.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString(Online.CurrentUser.UserImage);
                }
                catch
                {
                    Avatar.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFrom(@"..\..\Resources\defaultavatar.png");
                }
                NameTB.Text = Online.CurrentUser.UserName;
                SurnameTB.Text = Online.CurrentUser.UserSurName;
                if(Online.CurrentUser.UserLastName != "" | Online.CurrentUser.UserLastName != null) { LastNameTB.Text = Online.CurrentUser.UserLastName; }
            }
            if (Online.CurrentWorker != null)
            {
                LoginTB.Text = Online.CurrentWorker.WorkerLogin;
                PBox.Password = Online.CurrentWorker.WorkerPassword;
                PhoneNumber.Text = Online.CurrentWorker.WorkerPhone;
                Email.Text = Online.CurrentWorker.WorkerEmail;
                Address.Text = Online.CurrentWorker.WorkerAddress;
                try
                {
                    Avatar.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString(Online.CurrentWorker.WorkerImage);
                }
                catch
                {
                    Avatar.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFrom(@"..\..\ModalWindows\defaultavatar.png");
                }
                NameTB.Text = Online.CurrentWorker.WorkerName;
                SurnameTB.Text = Online.CurrentWorker.WorkerSurName;
                if (Online.CurrentWorker.WorkerLastName != "" | Online.CurrentWorker.WorkerLastName != null) { LastNameTB.Text = Online.CurrentWorker.WorkerLastName; }
            }
        }

        private void ChangeInfoB_Click(object sender, RoutedEventArgs e)
        {
            ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
            if (Online.CurrentUser != null)
            {
                Users user = new Users()
                {
                    UserPassword = PBox.Password,
                    UserEmail = Email.Text,
                    UserPhone = PhoneNumber.Text,
                    UserAddress = Address.Text,
                    UserName = NameTB.Text,
                    UserSurName = SurnameTB.Text,
                    UserImage = imageSourceConverter.ConvertToString(Avatar.ImageSource)
                };

                if (LoginTB.Text != Online.CurrentUser.UserLogin)
                {
                    bool checkloginexist = HelpForRegistration_Authorization.IsLoginExists(LoginTB.Text);
                    if (checkloginexist == true) { MyMessageBox.ShowMessage("Такой логин существует! Придумайте другое имя", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                    if (checkloginexist == false) { user.UserLogin = LoginTB.Text; }
                }
                else { user.UserLogin = LoginTB.Text; }

                if (Email.Text != Online.CurrentUser.UserEmail)
                {
                    bool checkemail = HelpForRegistration_Authorization.IsValidEmail(Email.Text);
                    if (checkemail == true) { user.UserEmail = Email.Text; }
                    if (checkemail == false) { MyMessageBox.ShowMessage("Повторите ввод электронной почты правильно или введите другой", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                }

                if (PhoneNumber.Text != Online.CurrentUser.UserPhone)
                {
                    string NumberForMethod = PhoneNumber.Text;
                    bool checknumberphone = HelpForRegistration_Authorization.IsValidNumberPhone(ref NumberForMethod);
                    if (checknumberphone == true) { user.UserPhone = NumberForMethod; }
                    if (checknumberphone == false) { MyMessageBox.ShowMessage("Повторите ввод номера правильно или введите другой номер", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                }

                if (LastNameTB.Text != "") { user.UserLastName = LastNameTB.Text; }
                user.UserId = Online.CurrentUser.UserId;
                Context.Users.Update(user);
                Online.CurrentUser = user;
                Context.SaveChanges();
                WorkWithUIElements.DisableButton(ChangeInfoB);

                MyLogger.WriteLogInDB(11, user.UserId, Context);
                
                MyMessageBox.ShowMessage("Данные успешно обновлены!");
                
                Context = new FCDBContext();
            }

            if (Online.CurrentWorker != null)
            {
                Workers worker = new Workers()
                {
                    WorkerPassword = PBox.Password,
                    WorkerEmail = Email.Text,
                    WorkerPhone = PhoneNumber.Text,
                    WorkerAddress = Address.Text,
                    WorkerName = NameTB.Text,
                    WorkerSurName = SurnameTB.Text,
                    WorkerImage = imageSourceConverter.ConvertToString(Avatar.ImageSource),
                    StartWork = Online.CurrentWorker.StartWork,
                    RoleId = Online.CurrentWorker.RoleId
                };

                if (LoginTB.Text != Online.CurrentWorker.WorkerLogin)
                {
                    bool checkloginexist = HelpForRegistration_Authorization.IsLoginExists(LoginTB.Text);
                    if (checkloginexist == true) { MyMessageBox.ShowMessage("Такой логин существует! Придумайте другое имя", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                    if (checkloginexist == false) { worker.WorkerLogin = LoginTB.Text; }
                }
                else { worker.WorkerLogin = LoginTB.Text; }

                if (Email.Text != Online.CurrentWorker.WorkerEmail)
                {
                    bool checkemail = HelpForRegistration_Authorization.IsValidEmail(Email.Text);
                    if (checkemail == true) { worker.WorkerEmail = Email.Text; }
                    if (checkemail == false) { MyMessageBox.ShowMessage("Email введен неккоректно", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                }

                if (PhoneNumber.Text != Online.CurrentWorker.WorkerPhone)
                {
                    string NumberForMethod = PhoneNumber.Text;
                    bool checknumberphone = HelpForRegistration_Authorization.IsValidNumberPhone(ref NumberForMethod);
                    if (checknumberphone == true) { worker.WorkerPhone = NumberForMethod; }
                    if (checknumberphone == false) { MyMessageBox.ShowMessage("Номер телефона введен неккоректно", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                }

                if (LastNameTB.Text != "") { worker.WorkerLastName = LastNameTB.Text; }
                worker.WorkerId = Online.CurrentWorker.WorkerId;
                Context.Workers.Update(worker);
                Online.CurrentWorker = worker;
                Context.SaveChanges();
                WorkWithUIElements.DisableButton(ChangeInfoB);

                MyLogger.WriteLogInDB(11, worker.WorkerId, Context);
                
                MyMessageBox.ShowMessage("Данные успешно обновлены!");

                Context = new FCDBContext();
            }
        }



        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            PersonalAccount mainWindow = System.Windows.Application.Current.Windows.OfType<PersonalAccount>().FirstOrDefault(w => w.Title == "PersonalAccount");
            ActionsWithWindows.CloseWindow(mainWindow);
        }


        private void ChangeAvatarButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
                openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*"; ;
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Avatar.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString(openFileDialog.FileName);

                    ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                    if (Online.CurrentUser != null)
                    {
                        if (Online.CurrentUser.UserImage != imageSourceConverter.ConvertToString(Avatar.ImageSource)) { WorkWithUIElements.EnableButton(ChangeInfoB);}
                        else { WorkWithUIElements.DisableButton(ChangeInfoB);}
                    }
                    if (Online.CurrentWorker != null)
                    {
                        if (Online.CurrentWorker.WorkerImage != imageSourceConverter.ConvertToString(Avatar.ImageSource)) { WorkWithUIElements.EnableButton(ChangeInfoB);}
                        else { WorkWithUIElements.DisableButton(ChangeInfoB);}
                    }

                    MyMessageBox.ShowMessage("Фото загружено");

                }
            }
            catch (Exception)
            {
                MyMessageBox.ShowMessage("Вы выбрали файл с неверным форматом!!", "ОШИБКА");
            }
        }

        private void NameTB_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Online.CurrentUser != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "NameTB")
                {
                    if(Online.CurrentUser.UserName != NameTB.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "NameTB"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
            if (Online.CurrentWorker != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "NameTB")
                {
                    if (Online.CurrentWorker.WorkerName != NameTB.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "NameTB"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
        }
        private void SurnameNameTB_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Online.CurrentUser != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "SurnameTB")
                {
                    if (Online.CurrentUser.UserSurName != SurnameTB.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "SurnameTB"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
            if (Online.CurrentWorker != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "SurnameTB")
                {
                    if (Online.CurrentWorker.WorkerSurName != SurnameTB.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "SurnameTB"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
        }

        private void LastNameTB_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Online.CurrentUser != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "LastNameTB")
                {
                    if (Online.CurrentUser.UserLastName != LastNameTB.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "LastNameTB"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
            if (Online.CurrentWorker != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "LastNameTB")
                {
                    if (Online.CurrentWorker.WorkerLastName != LastNameTB.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "LastNameTB"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
        }

        private void LoginTB_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Online.CurrentUser != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "LoginTB")
                {
                    if (Online.CurrentUser.UserLogin != LoginTB.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "LoginTB"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
            if (Online.CurrentWorker != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "LoginTB")
                {
                    if (Online.CurrentWorker.WorkerLogin != LoginTB.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "LoginTB"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
        }

        private void PBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Online.CurrentUser != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "PBox")
                {
                    if (Online.CurrentUser.UserPassword != PBox.Password) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "PBox"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
            if (Online.CurrentWorker != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "PBox")
                {
                    if (Online.CurrentWorker.WorkerPassword != PBox.Password) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "PBox"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
        }

        private void PhoneNumber_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Online.CurrentUser != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "PhoneNumber")
                {
                    if (Online.CurrentUser.UserPhone != PhoneNumber.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "PhoneNumber"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
            if (Online.CurrentWorker != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "PhoneNumber")
                {
                    if (Online.CurrentWorker.WorkerPhone != PhoneNumber.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "PhoneNumber"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
        }

        private void Email_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Online.CurrentUser != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "Email")
                {
                    if (Online.CurrentUser.UserEmail != Email.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "Email"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
            if (Online.CurrentWorker != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "Email")
                {
                    if (Online.CurrentWorker.WorkerEmail != Email.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "Email"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
        }

        private void Address_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (Online.CurrentUser != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "Address")
                {
                    if (Online.CurrentUser.UserAddress != Address.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "Address"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
            if (Online.CurrentWorker != null)
            {
                if (FirstChangedTextBlock == "" | FirstChangedTextBlock == "Address")
                {
                    if (Online.CurrentWorker.WorkerAddress != Address.Text) { WorkWithUIElements.EnableButton(ChangeInfoB); FirstChangedTextBlock = "Address"; }
                    else { WorkWithUIElements.DisableButton(ChangeInfoB); FirstChangedTextBlock = ""; }
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Context.Dispose();
        }
    }
}
