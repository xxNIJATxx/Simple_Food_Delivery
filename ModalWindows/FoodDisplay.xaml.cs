using Simple_Food_Delivery.Models;
using Simple_Food_Delivery.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Simple_Food_Delivery.ModalWindows
{
    public partial class FoodDisplay : Window
    {
        FCDBContext Context = new FCDBContext();
        public static List<Products> products = new List<Products>();
        public FoodDisplay()
        {
            InitializeComponent();
            if(Online.CurrentWorker != null) { if(Online.CurrentWorker.RoleId == 3) { SelectB.Visibility = Visibility.Hidden; } }
            if (products.Count > 0)
            {
                Products product = products[0];
                FoodImage.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(product.ProductImage);
                Title.Text = product.ProductName;
                Description.Text = product.ProductDesc;
                string result = string.Format("{0:C0}", product.UnitPrice);
                SelectB.Content += " за " + result;
            }
        }

        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            FoodDisplay foodDisplay = System.Windows.Application.Current.Windows.OfType<FoodDisplay>().FirstOrDefault(w => w.Name == "FoodDisplayWindow");
            ActionsWithWindows.CloseWindow(foodDisplay);
        }

        private void SelectB_Click(object sender, RoutedEventArgs e)
        {
            if (Online.CurrentUser == null & Online.CurrentWorker == null)
            {
                MyMessageBox.ShowMessage("Чтобы вкусно поесть сперва нужно зарегистрироваться! Это займет всего пару минут :)", MyMessageBoxImages.Information);
                return;
            }
            Cart cart = new Cart();
            if(Online.CurrentUser != null) { cart.UserId = Online.CurrentUser.UserId;}
            if(Online.CurrentWorker != null) { cart.UserId = Online.CurrentWorker.WorkerId;}
            Products product = products[0];
            cart.ProductName = product.ProductName;
            cart.CountOfProduct = 1;
            cart.FoodPrice = product.UnitPrice;
            cart.FoodImage = product.ProductImage;

            bool ProductAlreadyExist = false;
            foreach (Cart item in Context.Cart)
            {
                if (item.UserId == cart.UserId & item.ProductName == cart.ProductName)
                {
                    ProductAlreadyExist = true;
                    cart.CountOfProduct += 1;
                    cart.CartActionId = item.CartActionId;
                    break;
                }
            }

            if (ProductAlreadyExist == true)
            {
                Context.Dispose();
                Context = new FCDBContext();
                Context.Cart.Update(cart);
                Context.SaveChanges();
            }
            else
            {
                Context.Cart.Add(cart);
                Context.SaveChanges();
            }

            MyMessageBox.ShowMessage("Еда успешно добавлена в корзину!");
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            this.Context.Dispose();
        }
    }
}
