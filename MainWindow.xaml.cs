using Simple_Food_Delivery.ModalWindows;
using Simple_Food_Delivery.Pages;
using Simple_Food_Delivery.Services;
using System.Runtime.Remoting.Contexts;
using System.Windows;

namespace Simple_Food_Delivery
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new GreetingPage();

            
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch(System.Exception ex)
            {

            }
        }
    }  
}
