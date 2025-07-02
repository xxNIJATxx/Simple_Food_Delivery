using Simple_Food_Delivery.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Simple_Food_Delivery.ModalWindows
{
    public partial class MessageToSupport : Window
    {
        List<Image> Images = new List<Image>();
        public MessageToSupport()
        {
            InitializeComponent();
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            MessageToSupport messageToSupport = System.Windows.Application.Current.Windows.OfType<MessageToSupport>().FirstOrDefault(w => w.Title == "MessageToSupport");
            ActionsWithWindows.CloseWindow(messageToSupport);
        }

        private void DownloadImages_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*"; ;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image image = new Image();
                image.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(openFileDialog.FileName);
                Images.Add(image);
                FileNameTB.Text = $"Загружено {Images.Count} фото";
            }
        }
        private void SendMessageB_Click(object sender, RoutedEventArgs e)
        {
            if (EmailTB.Text == "")
            {
                MyMessageBox.ShowMessage("Введите электронную почту!", MyMessageBoxImages.Warning); return;
            }
            if (EmailTB.Text != "")
            {
                bool result = HelpForRegistration_Authorization.IsValidEmail(EmailTB.Text);
                if(result == false) { MyMessageBox.ShowMessage("Введите электронную почту корректно!", MyMessageBoxImages.Error); return; }
            }
            if(MessageTB.Text == "") { MyMessageBox.ShowMessage("Введите сообщение!"); return; }

            Images.Clear();
            bool messageBoxResult = MyMessageBox.ShowWithChoice("Отправить сообщение?", "Подтверждение");
            if (messageBoxResult == true)
            {
                MyMessageBox.ShowMessage("Сообщение успешно отправлено! Ожидайте ответа в ближайшее время!");
            }
            if (messageBoxResult == false)
            {
                Close();
            }
        }
    }
}
