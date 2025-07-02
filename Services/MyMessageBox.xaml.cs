using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Simple_Food_Delivery.Services
{
    public enum MyMessageBoxImages
    {
        Information = 1,
        Error,
        Warning
    }
    public partial class MyMessageBox : Window
    {
        private static bool IsYesButtonClicked = false;
        public MyMessageBox()
        {
            InitializeComponent();
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            MyMessageBox myMessageBox = Application.Current.Windows.OfType<MyMessageBox>().FirstOrDefault(w => w.Title == "MyMessageBox");
            ActionsWithWindows.CloseWindow(myMessageBox);
        }

        public static void ShowMessage(string Message, string Caption = "")
        {
            MyMessageBox myMessageBox = new MyMessageBox();
            myMessageBox.ImageForMessageBox.Visibility = Visibility.Collapsed;
            myMessageBox.CaptionTB.Text = Caption;
            myMessageBox.MessageTB.Text = Message;
            
            myMessageBox.MessageTB.SetValue(Grid.ColumnProperty, 0);
            myMessageBox.MessageTB.SetValue(Grid.ColumnSpanProperty, 3);
            myMessageBox.MessageTB.HorizontalAlignment = HorizontalAlignment.Center;
            myMessageBox.ShowDialog();
        }
        public static void ShowMessage(string Message, MyMessageBoxImages myMessageBoxImage,  string Caption = "")
        {
            MyMessageBox myMessageBox = new MyMessageBox();
            switch(myMessageBoxImage)
            {
                case (MyMessageBoxImages.Information):
                    myMessageBox.ImageForMessageBox.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resources\information.png");
                    break;
                case (MyMessageBoxImages.Warning):
                    myMessageBox.ImageForMessageBox.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resources\warning.png");
                    break;
                case (MyMessageBoxImages.Error):
                    myMessageBox.ImageForMessageBox.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resources\error.png");
                    break;
            }
            myMessageBox.CaptionTB.Text = Caption;
            myMessageBox.MessageTB.Text = Message;


            myMessageBox.ShowDialog();
        }
        public static bool ShowWithChoice(string Message, string Caption = "")
        {
            MyMessageBox myMessageBox = new MyMessageBox();
            myMessageBox.CloseB.IsEnabled = false;
            myMessageBox.YesB.Visibility = Visibility.Visible;
            myMessageBox.NoB.Visibility = Visibility.Visible;

            myMessageBox.ImageForMessageBox.Visibility = Visibility.Collapsed;
            myMessageBox.CaptionTB.Text = Caption;
            myMessageBox.MessageTB.Text = Message;
            myMessageBox.MessageTB.Margin = new Thickness(0);
            myMessageBox.MessageTB.SetValue(Grid.ColumnProperty, 0);
            myMessageBox.MessageTB.SetValue(Grid.ColumnSpanProperty, 3);
            myMessageBox.MessageTB.HorizontalAlignment = HorizontalAlignment.Center;
            myMessageBox.ShowDialog();
            return IsYesButtonClicked;
        }
        public static bool ShowWithChoice(string Message, MyMessageBoxImages myMessageBoxImage, string Caption = "")
        {
            MyMessageBox myMessageBox = new MyMessageBox();
            myMessageBox.CloseB.IsEnabled = false;
            myMessageBox.YesB.Visibility = Visibility.Visible;
            myMessageBox.NoB.Visibility = Visibility.Visible;
            switch (myMessageBoxImage)
            {
                case (MyMessageBoxImages.Information):
                    myMessageBox.ImageForMessageBox.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resources\information.png");
                    break;
                case (MyMessageBoxImages.Warning):
                    myMessageBox.ImageForMessageBox.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resources\warning.png");
                    break;
                case (MyMessageBoxImages.Error):
                    myMessageBox.ImageForMessageBox.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(@"..\..\Resources\error.png");
                    break;
            }
            myMessageBox.CaptionTB.Text = Caption;
            myMessageBox.MessageTB.Text = Message;


            myMessageBox.ShowDialog();
            return IsYesButtonClicked;
        }


        private void NoB_Click(object sender, RoutedEventArgs e)
        {
            IsYesButtonClicked = false;
            this.Close();
        }

        private void YesB_Click(object sender, RoutedEventArgs e)
        {
            IsYesButtonClicked = true;
            this.Close();
        }
    }
}
