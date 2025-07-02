using Simple_Food_Delivery.ModalWindows;
using Simple_Food_Delivery.Models;
using Simple_Food_Delivery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Simple_Food_Delivery.Pages
{
    public partial class ManagingPage : Page
    {
        FCDBContext Context = new FCDBContext();
        List<Users> users;
        List<Workers> workers;
        List<Roles> roles;
        List<ProductType> productTypes;
        List<Products> products;
        List<OrdersCompositions> ordersCompositions;
        List<Orders> orders;
        List<Cart> carts;
        List<ActionTypes> actionTypes;
        List<Actions> actions;

        public ManagingPage()
        {
            InitializeComponent();
            if (DG.Items.Count == 0) Border1.Visibility = Visibility.Hidden;
            if (Online.CurrentWorker != null)
            {

                if (Online.CurrentWorker.RoleId == 2)
                {
                    ChoiceTable.Items.Clear();
                    string[] names = { "Продукты", "Типы продуктов", "Заказы", "Состав заказов" };
                    for (global::System.Int32 i = 0; i < names.Length; i++)
                    {
                        TextBlock tb = new TextBlock();
                        tb.Text = names[i];
                        ChoiceTable.Items.Add(tb);
                    }
                }
            }
            
        }

        private void ChoiceTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChoiceTable.SelectedItem != null)
            {
                ForTopCB.Visibility = Visibility.Collapsed;
                if (ChoiceTable.SelectedItem is TextBlock)
                {
                    TextBlock tb = ChoiceTable.SelectedItem as TextBlock;
                    switch (tb.Text)
                    {
                        case "Пользователи":
                            try
                            {
                            users = Context.Users.ToList();

                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            Border1.Visibility = Visibility.Visible;
                            DG.ItemsSource = users;
                            workers = null;
                            roles= null;
                            productTypes = null;
                            products= null;
                            ordersCompositions= null;
                            orders= null;
                            carts= null;
                            actionTypes= null;
                            actions= null;
                            break;
                        case "Сотрудники":
                            workers = Context.Workers.ToList();
                            Border1.Visibility = Visibility.Visible;
                            DG.ItemsSource = workers;
                            users = null;
                            roles = null;
                            productTypes = null;
                            products = null;
                            ordersCompositions = null;
                            orders = null;
                            carts = null;
                            actionTypes = null;
                            actions = null;
                            break;
                        case "Роли":
                            roles = Context.Roles.ToList();
                            Border1.Visibility = Visibility.Visible;
                            DG.ItemsSource = roles;
                            users = null;
                            workers = null;
                            productTypes = null;
                            products = null;
                            ordersCompositions = null;
                            orders = null;
                            carts = null;
                            actionTypes = null;
                            actions = null;
                            break;
                        case "Заказы":
                            orders = Context.Orders.ToList();
                            Border1.Visibility = Visibility.Visible;
                            DG.ItemsSource = orders;
                            users = null;
                            workers = null;
                            roles = null;
                            productTypes = null;
                            products = null;
                            ordersCompositions = null;
                            carts = null;
                            actionTypes = null;
                            actions = null;
                            break;
                        case "Состав заказов":
                            ordersCompositions = Context.OrdersCompositions.ToList();
                            Border1.Visibility = Visibility.Visible;
                            DG.ItemsSource = ordersCompositions;
                            users = null;
                            workers = null;
                            roles = null;
                            productTypes = null;
                            products = null;
                            orders = null;
                            carts = null;
                            actionTypes = null;
                            actions = null;
                            break;
                        case "Продукты":
                            products = Context.Products.ToList();
                            Border1.Visibility = Visibility.Visible;
                            DG.ItemsSource = products;
                            users = null;
                            workers = null;
                            roles = null;
                            productTypes = null;
                            ordersCompositions = null;
                            orders = null;
                            carts = null;
                            actionTypes = null;
                            actions = null;
                            break;
                        case "Типы продуктов":
                            productTypes = Context.ProductType.ToList();
                            Border1.Visibility = Visibility.Visible;
                            DG.ItemsSource = productTypes;
                            users = null;
                            workers = null;
                            roles = null;
                            products = null;
                            ordersCompositions = null;
                            orders = null;
                            carts = null;
                            actionTypes = null;
                            actions = null;
                            break;
                        case "Корзины":
                            carts = Context.Cart.ToList();
                            Border1.Visibility = Visibility.Visible;
                            DG.ItemsSource = carts;
                            users = null;
                            workers = null;
                            roles = null;
                            productTypes = null;
                            products = null;
                            ordersCompositions = null;
                            orders = null;
                            actionTypes = null;
                            actions = null;
                            break;
                        case "Логи":
                            actions = Context.Actions.ToList();
                            Border1.Visibility = Visibility.Visible;
                            DG.ItemsSource = actions;
                            users = null;
                            workers = null;
                            roles = null;
                            productTypes = null;
                            products = null;
                            ordersCompositions = null;
                            orders = null;
                            carts = null;
                            actionTypes = null;
                            break;
                        case "Типы действий":
                            actionTypes = Context.ActionTypes.ToList();
                            Border1.Visibility = Visibility.Visible;
                            DG.ItemsSource = actionTypes;
                            users = null;
                            workers = null;
                            roles = null;
                            productTypes = null;
                            products = null;
                            ordersCompositions = null;
                            orders = null;
                            carts = null;
                            actions = null;
                            break;
                    }
                }

            }
        }

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            if (users != null)
            {
                Users user = new Users();
                ActionsWithTable actionsWithTable = new ActionsWithTable(true, user);
                actionsWithTable.ShowDialog();
                if (ActionsWithTable.ReceivedItem != null)
                {
                    user = ActionsWithTable.ReceivedItem as Users;
                    
                    bool checkloginexist = HelpForRegistration_Authorization.IsLoginExists(user.UserLogin);
                    if (checkloginexist == true) { MyMessageBox.ShowMessage("Такой логин существует! Придумайте другое имя", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                    
                    bool checkemail = HelpForRegistration_Authorization.IsValidEmail(user.UserEmail);
                    if (checkemail == false) { MyMessageBox.ShowMessage("Повторите ввод электронной почты правильно или введите другой", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                    
                    string NumberForMethod = user.UserPhone;
                    bool checknumberphone = HelpForRegistration_Authorization.IsValidNumberPhone(ref NumberForMethod);
                    if (checknumberphone == false) { MyMessageBox.ShowMessage("Повторите ввод номера правильно или введите другой номер", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                    
                    try
                    {
                        Context.Users.Update(user);
                        Context.SaveChanges();
                        users.Clear(); users = Context.Users.ToList();
                        DG.ItemsSource = users;
                        ActionsWithTable.IsNewItem = false;
                    }
                    catch (Exception)
                    {
                        MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                        return;
                    }
                }

            }
            if (workers != null)
            {
                Workers worker = new Workers();
                ActionsWithTable actionsWithTable = new ActionsWithTable(true, worker);
                actionsWithTable.ShowDialog();
                if (ActionsWithTable.ReceivedItem != null)
                {
                    worker = ActionsWithTable.ReceivedItem as Workers;
                    
                    bool checkloginexist = HelpForRegistration_Authorization.IsLoginExists(worker.WorkerLogin);
                    if (checkloginexist == true) { MyMessageBox.ShowMessage("Такой логин существует! Придумайте другое имя", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                    
                    bool checkemail = HelpForRegistration_Authorization.IsValidEmail(worker.WorkerEmail);
                    if (checkemail == false) { MyMessageBox.ShowMessage("Повторите ввод электронной почты правильно или введите другой", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                    
                    string NumberForMethod = worker.WorkerPhone;
                    bool checknumberphone = HelpForRegistration_Authorization.IsValidNumberPhone(ref NumberForMethod);
                    if (checknumberphone == false) { MyMessageBox.ShowMessage("Повторите ввод номера правильно или введите другой номер", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                    
                    try
                    {
                        Context.Workers.Add(worker);
                        Context.SaveChanges();
                        workers.Clear(); workers = Context.Workers.ToList();
                        DG.ItemsSource = workers;
                        ActionsWithTable.IsChanged = false;
                    }
                    catch (Exception)
                    {
                        MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                        return;
                    }
                }

            }
            if (roles != null)
            {
                Roles item = new Roles();
                ActionsWithTable actionsWithTable = new ActionsWithTable(true, item);
                actionsWithTable.ShowDialog();
                if (ActionsWithTable.ReceivedItem != null)
                {
                    item = ActionsWithTable.ReceivedItem as Roles;
                    try
                    {
                        Context.Roles.Add(item);
                        Context.SaveChanges();
                        roles.Clear(); roles = Context.Roles.ToList();
                        DG.ItemsSource = roles; ActionsWithTable.IsChanged = false;
                    }
                    catch (Exception)
                    {
                        MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                        return;
                    }
                }

            }
            if (products != null)
            {
                Products item = new Products();
                ActionsWithTable actionsWithTable = new ActionsWithTable(true, item);
                actionsWithTable.ShowDialog();
                if (ActionsWithTable.ReceivedItem != null)
                {
                    item = ActionsWithTable.ReceivedItem as Products;
                    try
                    {
                        Context.Products.Add(item);
                        Context.SaveChanges();
                        products.Clear(); products = Context.Products.ToList();
                        DG.ItemsSource = products; ActionsWithTable.IsChanged = false;
                    }
                    catch (Exception)
                    {
                        MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                        return;
                    }
                }

            }
            if (productTypes != null)
            {
                ProductType item = new ProductType();
                ActionsWithTable actionsWithTable = new ActionsWithTable(true, item);
                actionsWithTable.ShowDialog();
                if (ActionsWithTable.ReceivedItem != null)
                {
                    item = ActionsWithTable.ReceivedItem as ProductType;
                    try
                    {
                        Context.ProductType.Add(item);
                        Context.SaveChanges();
                        productTypes.Clear(); productTypes = Context.ProductType.ToList();
                        DG.ItemsSource = productTypes; ActionsWithTable.IsChanged = false;
                    }
                    catch (Exception)
                    {
                        MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                        return;
                    }
                }
            }
            if (ordersCompositions != null)
            {

                OrdersCompositions item = new OrdersCompositions();
                ActionsWithTable actionsWithTable = new ActionsWithTable(true, item);
                actionsWithTable.ShowDialog();
                if (ActionsWithTable.ReceivedItem != null)
                {
                    item = ActionsWithTable.ReceivedItem as OrdersCompositions;
                    try
                    {
                        Context.OrdersCompositions.Add(item);
                        Context.SaveChanges();
                        ordersCompositions.Clear(); ordersCompositions = Context.OrdersCompositions.ToList();
                        DG.ItemsSource = ordersCompositions; ActionsWithTable.IsChanged = false;
                    }
                    catch (Exception)
                    {
                        MyMessageBox.ShowMessage("Возможно заказа с таким ID не существует!", MyMessageBoxImages.Error, "ОШИБКА");
                        return;
                    }
                }

            }
            if (orders != null)
            {

                Orders item = new Orders();
                ActionsWithTable actionsWithTable = new ActionsWithTable(true, item);
                actionsWithTable.ShowDialog();
                if (ActionsWithTable.ReceivedItem != null)
                {
                    item = ActionsWithTable.ReceivedItem as Orders;
                    try
                    {
                        Context.Orders.Add(item);
                        Context.SaveChanges();
                        orders.Clear(); orders = Context.Orders.ToList();
                        DG.ItemsSource = orders; ActionsWithTable.IsChanged = false;
                    }
                    catch (Exception)
                    {
                        MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                        return;
                    }
                }

            }

            if (carts != null)
            {
                Cart item = new Cart();
                ActionsWithTable actionsWithTable = new ActionsWithTable(true, item);
                actionsWithTable.ShowDialog();
                if (ActionsWithTable.ReceivedItem != null)
                {
                    item = ActionsWithTable.ReceivedItem as Cart;
                    try
                    {
                        Context.Cart.Add(item);
                        Context.SaveChanges();
                        carts.Clear(); carts = Context.Cart.ToList();
                        DG.ItemsSource = carts; ActionsWithTable.IsChanged = false;
                    }
                    catch (Exception)
                    {
                        MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                        return;
                    }
                }

            }
            if (actionTypes != null)
            {

                ActionTypes item = new ActionTypes();
                ActionsWithTable actionsWithTable = new ActionsWithTable(true, item);
                actionsWithTable.ShowDialog();
                if (ActionsWithTable.ReceivedItem != null)
                {
                    item = ActionsWithTable.ReceivedItem as ActionTypes;
                    try
                    {
                        Context.ActionTypes.Add(item);
                        Context.SaveChanges();
                        actionTypes.Clear(); actionTypes = Context.ActionTypes.ToList();
                        DG.ItemsSource = actionTypes; ActionsWithTable.IsChanged = false;
                    }
                    catch (Exception)
                    {
                        MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                        return;
                    }
                }

            }
            if (actions != null)
            {
                Actions item = new Actions();
                ActionsWithTable actionsWithTable = new ActionsWithTable(true, item);
                actionsWithTable.ShowDialog();
                if (ActionsWithTable.ReceivedItem != null)
                {
                    item = ActionsWithTable.ReceivedItem as Actions;
                    try
                    {
                        Context.Actions.Add(item);
                        Context.SaveChanges();
                        actions.Clear(); actions = Context.Actions.ToList();
                        DG.ItemsSource = actions; ActionsWithTable.IsChanged = false;
                    }
                    catch (Exception)
                    {
                        MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                        return;
                    }
                }

            }
            if(Online.CurrentWorker ==  null) { MyLogger.WriteLogInDB(9, 0, Context); }
            else { MyLogger.WriteLogInDB(9, Online.CurrentWorker.WorkerId, Context); }
        }

        private void ChangeB_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {
                if (users != null)
                {
                    if (users.Count > 0)
                    {
                        Users user = DG.SelectedItem as Users;
                        ActionsWithTable actionsWithTable = new ActionsWithTable(false, user);
                        actionsWithTable.ShowDialog();
                        if (ActionsWithTable.IsChanged == true & ActionsWithTable.ReceivedItem != null)
                        {
                            int ID = user.UserId;
                            user = ActionsWithTable.ReceivedItem as Users;
                            user.UserId = ID;
                            if (ActionsWithTable.IsLoginChanged == true)
                            {
                                bool checkloginexist = HelpForRegistration_Authorization.IsLoginExists(user.UserLogin);
                                if (checkloginexist == true) { MyMessageBox.ShowMessage("Такой логин существует! Придумайте другое имя", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                            }
                            if (ActionsWithTable.IsEmailChanged == true)
                            {
                                bool checkemail = HelpForRegistration_Authorization.IsValidEmail(user.UserEmail);
                                if (checkemail == false) { MyMessageBox.ShowMessage("Повторите ввод электронной почты правильно или введите другой", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                            }
                            if (ActionsWithTable.IsPhoneChanged == true)
                            {
                                string NumberForMethod = user.UserPhone;
                                bool checknumberphone = HelpForRegistration_Authorization.IsValidNumberPhone(ref NumberForMethod);
                                if (checknumberphone == false) { MyMessageBox.ShowMessage("Повторите ввод номера правильно или введите другой номер", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                            }

                            try
                            {
                                var temp = Context.Users.First(w => w.UserId == ID);
                                PropertyInfo[] properties = temp.GetType().GetProperties();
                                PropertyInfo[] properties1 = user.GetType().GetProperties();
                                for (global::System.Int32 i = 0; i < properties.Length; i++)
                                {
                                    PropertyInfo property = properties[i];
                                    property.SetValue(temp, properties1[i].GetValue(user));
                                }
                                Context.Users.Update(temp);
                                Context.SaveChanges();
                                users.Clear(); users = Context.Users.ToList();
                                DG.ItemsSource = users;
                                ActionsWithTable.IsChanged = false;
                            }
                            catch (Exception)
                            {
                                MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                                return;
                            }
                        }
                    }
                }
                if (workers != null)
                {
                    if (workers.Count > 0)
                    {
                        Workers worker = DG.SelectedItem as Workers;
                        ActionsWithTable actionsWithTable = new ActionsWithTable(false, worker);
                        actionsWithTable.ShowDialog();
                        if (ActionsWithTable.IsChanged == true & ActionsWithTable.ReceivedItem != null)
                        {
                            int ID = worker.WorkerId;
                            worker = ActionsWithTable.ReceivedItem as Workers;
                            worker.WorkerId = ID;
                            if (ActionsWithTable.IsLoginChanged == true)
                            {
                                bool checkloginexist = HelpForRegistration_Authorization.IsLoginExists(worker.WorkerLogin);
                                if (checkloginexist == true) { MyMessageBox.ShowMessage("Такой логин существует! Придумайте другое имя", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                            }
                            if (ActionsWithTable.IsEmailChanged == true)
                            {
                                bool checkemail = HelpForRegistration_Authorization.IsValidEmail(worker.WorkerEmail);
                                if (checkemail == false) { MyMessageBox.ShowMessage("Повторите ввод электронной почты правильно или введите другой", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                            }
                            if (ActionsWithTable.IsPhoneChanged == true)
                            {
                                string NumberForMethod = worker.WorkerPhone;
                                bool checknumberphone = HelpForRegistration_Authorization.IsValidNumberPhone(ref NumberForMethod);
                                if (checknumberphone == false) { MyMessageBox.ShowMessage("Повторите ввод номера правильно или введите другой номер", MyMessageBoxImages.Error, "ОШИБКА"); return; }
                            }

                            try
                            {
                                var temp = Context.Workers.First(w => w.WorkerId == ID);
                                PropertyInfo[] properties = temp.GetType().GetProperties();
                                PropertyInfo[] properties1 = worker.GetType().GetProperties();
                                for (global::System.Int32 i = 0; i < properties.Length; i++)
                                {
                                    PropertyInfo property = properties[i];
                                    property.SetValue(temp, properties1[i].GetValue(worker));
                                }
                                Context.Workers.Update(temp);
                                Context.SaveChanges();
                                workers.Clear(); workers = Context.Workers.ToList();
                                DG.ItemsSource = workers;
                                ActionsWithTable.IsChanged = false;
                            }
                            catch (Exception)
                            {
                                MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                                return;
                            }
                        }
                    }
                }
                if (roles != null)
                {
                    if (roles.Count > 0)
                    {
                        Roles item = DG.SelectedItem as Roles;
                        ActionsWithTable actionsWithTable = new ActionsWithTable(false, item);
                        actionsWithTable.ShowDialog();
                        if (ActionsWithTable.IsChanged == true & ActionsWithTable.ReceivedItem != null)
                        {
                            int ID = item.RoleId;
                            item = ActionsWithTable.ReceivedItem as Roles;
                            item.RoleId = ID;
                            try
                            {
                                var temp = Context.Roles.First(w => w.RoleId == ID);
                                PropertyInfo[] properties = temp.GetType().GetProperties();
                                PropertyInfo[] properties1 = item.GetType().GetProperties();
                                for (global::System.Int32 i = 0; i < properties.Length; i++)
                                {
                                    PropertyInfo property = properties[i];
                                    property.SetValue(temp, properties1[i].GetValue(item));
                                }
                                Context.Roles.Update(temp);
                                Context.SaveChanges();
                                roles.Clear(); roles = Context.Roles.ToList();
                                DG.ItemsSource = roles; ActionsWithTable.IsChanged = false;
                            }
                            catch (Exception)
                            {
                                MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                                return;
                            }
                        }
                    }
                }
                if (products != null)
                {
                    if (products.Count > 0)
                    {
                        Products item = DG.SelectedItem as Products;
                        ActionsWithTable actionsWithTable = new ActionsWithTable(false, item);
                        actionsWithTable.ShowDialog();
                        if (ActionsWithTable.IsChanged == true & ActionsWithTable.ReceivedItem != null)
                        {
                            int ID = item.ProductId;
                            item = ActionsWithTable.ReceivedItem as Products;
                            item.ProductId = ID;
                            try
                            {
                                var temp = Context.Products.First(w => w.ProductId == ID);
                                PropertyInfo[] properties = temp.GetType().GetProperties();
                                PropertyInfo[] properties1 = item.GetType().GetProperties();
                                for (global::System.Int32 i = 0; i < properties.Length; i++)
                                {
                                    PropertyInfo property = properties[i];
                                    property.SetValue(temp, properties1[i].GetValue(item));
                                }
                                Context.Products.Update(temp);
                                Context.SaveChanges();
                                products.Clear(); products = Context.Products.ToList();
                                DG.ItemsSource = products; ActionsWithTable.IsChanged = false;
                            }
                            catch (Exception)
                            {
                                MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                                return;
                            }
                        }
                    }
                }
                if (productTypes != null)
                {
                    if (productTypes.Count > 0)
                    {
                        ProductType item = DG.SelectedItem as ProductType;
                        ActionsWithTable actionsWithTable = new ActionsWithTable(false, item);
                        actionsWithTable.ShowDialog();
                        if (ActionsWithTable.IsChanged == true & ActionsWithTable.ReceivedItem != null)
                        {
                            int ID = item.ProductTypeId;
                            item = ActionsWithTable.ReceivedItem as ProductType;
                            item.ProductTypeId = ID;
                            try
                            {
                                var temp = Context.ProductType.First(w => w.ProductTypeId == ID);
                                PropertyInfo[] properties = temp.GetType().GetProperties();
                                PropertyInfo[] properties1 = item.GetType().GetProperties();
                                for (global::System.Int32 i = 0; i < properties.Length; i++)
                                {
                                    PropertyInfo property = properties[i];
                                    property.SetValue(temp, properties1[i].GetValue(item));
                                }
                                Context.ProductType.Update(temp);
                                Context.SaveChanges();
                                productTypes.Clear(); productTypes = Context.ProductType.ToList();
                                DG.ItemsSource = productTypes; ActionsWithTable.IsChanged = false;
                            }
                            catch (Exception)
                            {
                                MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                                return;
                            }
                        }
                    }
                }
                if (ordersCompositions != null)
                {
                    if (ordersCompositions.Count > 0)
                    {
                        OrdersCompositions item = DG.SelectedItem as OrdersCompositions;
                        ActionsWithTable actionsWithTable = new ActionsWithTable(false, item);
                        actionsWithTable.ShowDialog();
                        if (ActionsWithTable.IsChanged == true & ActionsWithTable.ReceivedItem != null)
                        {
                            int ID = item.UselessColumn;
                            item = ActionsWithTable.ReceivedItem as OrdersCompositions;
                            item.UselessColumn = ID;
                            try
                            {
                                var temp = Context.OrdersCompositions.First(w => w.UselessColumn == ID);
                                PropertyInfo[] properties = temp.GetType().GetProperties();
                                PropertyInfo[] properties1 = item.GetType().GetProperties();
                                for (global::System.Int32 i = 0; i < properties.Length; i++)
                                {
                                    PropertyInfo property = properties[i];
                                    property.SetValue(temp, properties1[i].GetValue(item));
                                }
                                Context.OrdersCompositions.Update(temp);
                                Context.SaveChanges();
                                ordersCompositions.Clear(); ordersCompositions = Context.OrdersCompositions.ToList();
                                DG.ItemsSource = products; ActionsWithTable.IsChanged = false;
                            }
                            catch (Exception)
                            {
                                MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                                return;
                            }
                        }
                    }
                }
                if (orders != null)
                {
                    if (orders.Count > 0)
                    {
                        Orders item = DG.SelectedItem as Orders;
                        ActionsWithTable actionsWithTable = new ActionsWithTable(false, item);
                        actionsWithTable.ShowDialog();
                        if (ActionsWithTable.IsChanged == true & ActionsWithTable.ReceivedItem != null)
                        {
                            int ID = item.OrderId;
                            item = ActionsWithTable.ReceivedItem as Orders;
                            item.OrderId = ID;
                            try
                            {
                                var temp = Context.Orders.First(w => w.OrderId == ID);
                                PropertyInfo[] properties = temp.GetType().GetProperties();
                                PropertyInfo[] properties1 = item.GetType().GetProperties();
                                for (global::System.Int32 i = 0; i < properties.Length; i++)
                                {
                                    PropertyInfo property = properties[i];
                                    property.SetValue(temp, properties1[i].GetValue(item));
                                }
                                Context.Orders.Update(temp);
                                Context.SaveChanges();
                                orders.Clear(); orders = Context.Orders.ToList();
                                DG.ItemsSource = orders; ActionsWithTable.IsChanged = false;
                            }
                            catch (Exception)
                            {
                                MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                                return;
                            }
                        }
                    }
                }

                if (carts != null)
                {
                    if (carts.Count > 0)
                    {
                        Cart item = DG.SelectedItem as Cart;
                        ActionsWithTable actionsWithTable = new ActionsWithTable(false, item);
                        actionsWithTable.ShowDialog();
                        if (ActionsWithTable.IsChanged == true & ActionsWithTable.ReceivedItem != null)
                        {
                            int ID = item.CartActionId;
                            item = ActionsWithTable.ReceivedItem as Cart;
                            item.CartActionId = ID;
                            try
                            {
                                var temp = Context.Cart.First(w => w.CartActionId == ID);
                                PropertyInfo[] properties = temp.GetType().GetProperties();
                                PropertyInfo[] properties1 = item.GetType().GetProperties();
                                for (global::System.Int32 i = 0; i < properties.Length; i++)
                                {
                                    PropertyInfo property = properties[i];
                                    property.SetValue(temp, properties1[i].GetValue(item));
                                }
                                Context.Cart.Update(temp);
                                Context.SaveChanges();
                                carts.Clear(); carts = Context.Cart.ToList();
                                DG.ItemsSource = carts; ActionsWithTable.IsChanged = false;
                            }
                            catch (Exception)
                            {
                                MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                                return;
                            }
                        }
                    }
                }
                if (actionTypes != null)
                {
                    if (actionTypes.Count > 0)
                    {
                        ActionTypes item = DG.SelectedItem as ActionTypes;
                        ActionsWithTable actionsWithTable = new ActionsWithTable(false, item);
                        actionsWithTable.ShowDialog();
                        if (ActionsWithTable.IsChanged == true & ActionsWithTable.ReceivedItem != null)
                        {
                            int ID = item.ActionTypeId;
                            item = ActionsWithTable.ReceivedItem as ActionTypes;
                            item.ActionTypeId = ID;
                            try
                            {
                                var temp = Context.ActionTypes.First(w => w.ActionTypeId == ID);
                                PropertyInfo[] properties = temp.GetType().GetProperties();
                                PropertyInfo[] properties1 = item.GetType().GetProperties();
                                for (global::System.Int32 i = 0; i < properties.Length; i++)
                                {
                                    PropertyInfo property = properties[i];
                                    property.SetValue(temp, properties1[i].GetValue(item));
                                }
                                Context.ActionTypes.Update(temp);
                                Context.SaveChanges();
                                actionTypes.Clear(); actionTypes = Context.ActionTypes.ToList();
                                DG.ItemsSource = actionTypes; ActionsWithTable.IsChanged = false;
                            }
                            catch (Exception)
                            {
                                MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                                return;
                            }
                        }
                    }
                }
                if (actions != null)
                {
                    if (actions.Count > 0)
                    {
                        Actions item = DG.SelectedItem as Actions;
                        ActionsWithTable actionsWithTable = new ActionsWithTable(false, item);
                        actionsWithTable.ShowDialog();
                        if (ActionsWithTable.IsChanged == true & ActionsWithTable.ReceivedItem != null)
                        {
                            int ID = item.ActionId;
                            item = ActionsWithTable.ReceivedItem as Actions;
                            item.ActionId = ID;
                            try
                            {
                                var temp = Context.Actions.First(w => w.ActionId == ID);
                                PropertyInfo[] properties = temp.GetType().GetProperties();
                                PropertyInfo[] properties1 = item.GetType().GetProperties();
                                for (global::System.Int32 i = 0; i < properties.Length; i++)
                                {
                                    PropertyInfo property = properties[i];
                                    property.SetValue(temp, properties1[i].GetValue(item));
                                }
                                Context.Actions.Update(temp);
                                Context.SaveChanges();
                                actions.Clear(); actions = Context.Actions.ToList();
                                DG.ItemsSource = actions; ActionsWithTable.IsChanged = false;
                            }
                            catch (Exception)
                            {
                                MyMessageBox.ShowMessage("Не пишите ничего в столбце с ID!", MyMessageBoxImages.Error, "ОШИБКА");
                                return;
                            }
                        }
                    }
                }
                if (Online.CurrentWorker == null) { MyLogger.WriteLogInDB(7, 0, Context); }
                else { MyLogger.WriteLogInDB(7, Online.CurrentWorker.WorkerId, Context); }
            }
        }

        private void DelB_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {

                if (users != null)
                {
                    if (users.Count > 0)
                    {
                        Users user = DG.SelectedItem as Users;
                        try
                        {
                            Context.Users.Remove(user);
                            Context.SaveChanges();
                            users.Clear(); users = Context.Users.ToList();
                            DG.ItemsSource = users;
                        }
                        catch (Exception)
                        {
                            MyMessageBox.ShowMessage("Не получится удалить пользователя, проверьте другие таблицы, где есть его ID!", MyMessageBoxImages.Error, "ОШИБКА");
                            return;
                        }
                    }
                }
                if (workers != null)
                {
                    if (workers.Count > 0)
                    {
                        Workers worker = DG.SelectedItem as Workers;
                        if(worker.WorkerId == 1) { return; }
                        try
                        {
                            Context.Workers.Remove(worker);
                            Context.SaveChanges();
                            workers.Clear(); workers = Context.Workers.ToList();
                            DG.ItemsSource = workers;
                        }
                        catch (Exception)
                        {
                            MyMessageBox.ShowMessage("Попробуйте еще раз или проверьте другие таблицы, связанные с этой!", MyMessageBoxImages.Error, "ОШИБКА");
                            return;
                        }
                    }
                }
                if (roles != null)
                {
                    if (roles.Count > 0)
                    {
                        Roles item = DG.SelectedItem as Roles;
                        try
                        {
                            Context.Roles.Remove(item);
                            Context.SaveChanges();
                            roles.Clear(); roles = Context.Roles.ToList();
                            DG.ItemsSource = roles;
                        }
                        catch (Exception)
                        {
                            MyMessageBox.ShowMessage("Попробуйте еще раз или проверьте другие таблицы, связанные с этой!", MyMessageBoxImages.Error, "ОШИБКА");
                            return;
                        }
                    }
                }
                if (products != null)
                {
                    if (products.Count > 0)
                    {
                        Products item = DG.SelectedItem as Products;
                        try
                        {
                            Context.Products.Remove(item);
                            Context.SaveChanges();
                            products.Clear(); products = Context.Products.ToList();
                            DG.ItemsSource = products;
                        }
                        catch (Exception)
                        {
                            MyMessageBox.ShowMessage("Попробуйте еще раз или проверьте другие таблицы, связанные с этой!", MyMessageBoxImages.Error, "ОШИБКА");
                            return;
                        }
                    }
                }
                if (productTypes != null)
                {
                    if (productTypes.Count > 0)
                    {
                        ProductType item = DG.SelectedItem as ProductType;
                        try
                        {
                            Context.ProductType.Remove(item);
                            Context.SaveChanges();
                            productTypes.Clear(); productTypes = Context.ProductType.ToList();
                            DG.ItemsSource = productTypes;
                        }
                        catch (Exception)
                        {
                            MyMessageBox.ShowMessage("Попробуйте еще раз или проверьте другие таблицы, связанные с этой!", MyMessageBoxImages.Error, "ОШИБКА");
                            return;
                        }
                    }
                }
                if (ordersCompositions != null)
                {
                    if (ordersCompositions.Count > 0)
                    {
                        OrdersCompositions item = DG.SelectedItem as OrdersCompositions;
                        try
                        {
                            Context.OrdersCompositions.Remove(item);
                            Context.SaveChanges();
                            ordersCompositions.Clear(); ordersCompositions = Context.OrdersCompositions.ToList();
                            DG.ItemsSource = ordersCompositions;
                        }
                        catch (Exception)
                        {
                            MyMessageBox.ShowMessage("Попробуйте еще раз или проверьте другие таблицы, связанные с этой!", MyMessageBoxImages.Error, "ОШИБКА");
                            return;
                        }
                    }
                }
                if (orders != null)
                {
                    if (orders.Count > 0)
                    {


                        Orders item = DG.SelectedItem as Orders;
                        try
                        {
                            Context.Orders.Remove(item);
                            Context.SaveChanges();
                            orders.Clear(); orders = Context.Orders.ToList();
                            DG.ItemsSource = orders;
                        }
                        catch (Exception ex)
                        {
                            MyMessageBox.ShowMessage("Попробуйте еще раз или проверьте другие таблицы, связанные с этой!", MyMessageBoxImages.Error, "ОШИБКА");
                            return;
                        }
                    }
                }

                if (carts != null)
                {
                    if (carts.Count > 0)
                    {
                        Cart item = DG.SelectedItem as Cart;
                        try
                        {
                            Context.Cart.Remove(item);
                            Context.SaveChanges();
                            carts.Clear(); carts = Context.Cart.ToList();
                            DG.ItemsSource = carts;
                        }
                        catch (Exception)
                        {
                            MyMessageBox.ShowMessage("Попробуйте еще раз или проверьте другие таблицы, связанные с этой!", MyMessageBoxImages.Error, "ОШИБКА");
                            return;
                        }
                    }
                }
                if (actionTypes != null)
                {
                    if (actionTypes.Count > 0)
                    {
                        ActionTypes item = DG.SelectedItem as ActionTypes;
                        try
                        {
                            Context.ActionTypes.Remove(item);
                            Context.SaveChanges();
                            actionTypes.Clear(); actionTypes = Context.ActionTypes.ToList();
                            DG.ItemsSource = actionTypes;
                        }
                        catch (Exception)
                        {
                            MyMessageBox.ShowMessage("Попробуйте еще раз или проверьте другие таблицы, связанные с этой!", MyMessageBoxImages.Error, "ОШИБКА");
                            return;
                        }
                    }
                }
                if (actions != null)
                {
                    if (actions.Count > 0)
                    {
                        Actions item = DG.SelectedItem as Actions;
                        try
                        {
                            Context.Actions.Remove(item);
                            Context.SaveChanges();
                            actions.Clear(); actions = Context.Actions.ToList();
                            DG.ItemsSource = actions;
                        }
                        catch (Exception)
                        {
                            MyMessageBox.ShowMessage("Попробуйте еще раз или проверьте другие таблицы, связанные с этой!", MyMessageBoxImages.Error, "ОШИБКА");
                            return;
                        }
                    }
                }
                if (Online.CurrentWorker == null) { MyLogger.WriteLogInDB(8, 0, Context); }
                else { MyLogger.WriteLogInDB(8, Online.CurrentWorker.WorkerId, Context); }
            }
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




        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortCB.SelectedItem != null)
            {
                ForSortCB.Visibility = Visibility.Collapsed;
                if (SortCB.SelectedItem is TextBlock)
                {
                    TextBlock tb = SortCB.SelectedItem as TextBlock;
                    if (tb.Text == "Сначала новые записи")
                    {
                        if (users != null)
                        {
                            if (users.Count > 0)
                            {
                                users = users.OrderByDescending(r => r.UserId).ToList();
                                DG.ItemsSource = users;
                            }
                        }
                        if (workers != null)
                        {
                            if (workers.Count > 0)
                            {
                                workers = workers.OrderByDescending(r => r.WorkerId).ToList();
                                DG.ItemsSource = workers;
                            }
                        }
                        if (roles != null)
                        {
                            if (roles.Count > 0)
                            {
                                roles = roles.OrderByDescending(r => r.RoleId).ToList();
                                DG.ItemsSource = roles;
                            }
                        }
                        if (productTypes != null)
                        {
                            if (productTypes.Count > 0)
                            {
                                productTypes = productTypes.OrderByDescending(r => r.ProductTypeId).ToList();
                                DG.ItemsSource = productTypes;
                            }
                        }
                        if (products != null)
                        {
                            if (products.Count > 0)
                            {
                                products = products.OrderByDescending(r => r.ProductId).ToList();
                                DG.ItemsSource = products;
                            }
                        }
                        if (ordersCompositions != null)
                        {
                            if (ordersCompositions.Count > 0)
                            {
                                ordersCompositions = ordersCompositions.OrderByDescending(r => r.OrderId).ToList();
                                DG.ItemsSource = ordersCompositions;
                            }
                        }
                        if (orders != null)
                        {
                            if (orders.Count > 0)
                            {
                                orders = orders.OrderByDescending(r => r.OrderId).ToList();
                                DG.ItemsSource = orders;
                            }
                        }
                        if (carts != null)
                        {
                            if (carts.Count > 0)
                            {
                                carts = carts.OrderByDescending(r => r.CartActionId).ToList();
                                DG.ItemsSource = carts;
                            }
                        }
                        if (actionTypes != null)
                        {
                            if (actionTypes.Count > 0)
                            {
                                actionTypes = actionTypes.OrderByDescending(r => r.ActionTypeId).ToList();
                                DG.ItemsSource = actionTypes;
                            }
                        }
                        if (actions != null)
                        {
                            if (actions.Count > 0)
                            {
                                actions = actions.OrderByDescending(r => r.ActionId).ToList();
                                DG.ItemsSource = actions;
                            }
                        }  
                    }

                    if (tb.Text == "Сначала старые записи")
                    {
                        {
                            if (users != null)
                            {
                                if (users.Count > 0)
                                {
                                    users = users.OrderBy(r => r.UserId).ToList();
                                    DG.ItemsSource = users;
                                }
                            }
                            if (workers != null)
                            {
                                if (workers.Count > 0)
                                {
                                    workers = workers.OrderBy(r => r.WorkerId).ToList();
                                    DG.ItemsSource = workers;
                                }
                            }
                            if (roles != null)
                            {
                                if (roles.Count > 0)
                                {
                                    roles = roles.OrderBy(r => r.RoleId).ToList();
                                    DG.ItemsSource = roles;
                                }
                            }
                            if (productTypes != null)
                            {
                                if (productTypes.Count > 0)
                                {
                                    productTypes = productTypes.OrderBy(r => r.ProductTypeId).ToList();
                                    DG.ItemsSource = productTypes;
                                }
                            }
                            if (products != null)
                            {
                                if (products.Count > 0)
                                {
                                    products = products.OrderBy(r => r.ProductId).ToList();
                                    DG.ItemsSource = products;
                                }
                            }
                            if (ordersCompositions != null)
                            {
                                if (ordersCompositions.Count > 0)
                                {
                                    ordersCompositions = ordersCompositions.OrderBy(r => r.OrderId).ToList();
                                    DG.ItemsSource = ordersCompositions;
                                }
                            }
                            if (orders != null)
                            {
                                if (orders.Count > 0)
                                {
                                    orders = orders.OrderBy(r => r.OrderId).ToList();
                                    DG.ItemsSource = orders;
                                }
                            }
                            if (carts != null)
                            {
                                if (carts.Count > 0)
                                {
                                    carts = carts.OrderBy(r => r.CartActionId).ToList();
                                    DG.ItemsSource = carts;
                                }
                            }
                            if (actionTypes != null)
                            {
                                if (actionTypes.Count > 0)
                                {
                                    actionTypes = actionTypes.OrderBy(r => r.ActionTypeId).ToList();
                                    DG.ItemsSource = actionTypes;
                                }
                            }
                            if (actions != null)
                            {
                                if (actions.Count > 0)
                                {
                                    actions = actions.OrderBy(r => r.ActionId).ToList();
                                    DG.ItemsSource = actions;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SearchB_Click(object sender, RoutedEventArgs e)
        {
            if (SearchTB.Text != "Поиск..." & SearchTB.Text != "")
            {
                if (users != null)
                {
                    if (users.Count > 0)
                    {
                        List<Users> templist = new List<Users>();
                        foreach (var item in users)
                        {
                            bool globalresult = false;
                            PropertyInfo[] properties = item.GetType().GetProperties();
                            foreach (var property in properties)
                            {
                                if (property.GetGetMethod().IsVirtual == false)
                                {
                                    bool localresult = WorkWithUIElements.IsPropertyContainsWord(property.GetValue(item), SearchTB.Text);
                                    if (localresult == true) { globalresult = true; break; }
                                }
                            }
                            if (globalresult == true) { templist.Add(item); }
                        }
                        
                        DG.ItemsSource = templist;
                    }
                }
                if (workers != null)
                {
                    if (workers.Count > 0)
                    {
                        List<Workers> templist = new List<Workers>();
                        foreach (var item in workers)
                        {
                            bool globalresult = false;
                            PropertyInfo[] properties = item.GetType().GetProperties();
                            foreach (var property in properties)
                            {
                                if (property.GetGetMethod().IsVirtual == false)
                                {
                                    bool localresult = WorkWithUIElements.IsPropertyContainsWord(property.GetValue(item), SearchTB.Text);
                                    if (localresult == true) { globalresult = true; break; }
                                }
                            }
                            if (globalresult == true) { templist.Add(item); }
                        }

                        DG.ItemsSource = templist;
                    }
                }
                if (roles != null)
                {
                    if (roles.Count > 0)
                    {
                        List<Roles> templist = new List<Roles>();
                        foreach (var item in roles)
                        {
                            bool globalresult = false;
                            PropertyInfo[] properties = item.GetType().GetProperties();
                            foreach (var property in properties)
                            {
                                if (property.GetGetMethod().IsVirtual == false)
                                {
                                    bool localresult = WorkWithUIElements.IsPropertyContainsWord(property.GetValue(item), SearchTB.Text);
                                    if (localresult == true) { globalresult = true; break; }
                                }
                            }
                            if (globalresult == true) { templist.Add(item); }
                        }

                        DG.ItemsSource = templist;
                    }
                }
                if (productTypes != null)
                {
                    if (productTypes.Count > 0)
                    {
                        List<ProductType> templist = new List<ProductType>();
                        foreach (var item in productTypes)
                        {
                            bool globalresult = false;
                            PropertyInfo[] properties = item.GetType().GetProperties();
                            foreach (var property in properties)
                            {
                                if (property.GetGetMethod().IsVirtual == false)
                                {
                                    bool localresult = WorkWithUIElements.IsPropertyContainsWord(property.GetValue(item), SearchTB.Text);
                                    if (localresult == true) { globalresult = true; break; }
                                }
                            }
                            if (globalresult == true) { templist.Add(item); }
                        }

                        DG.ItemsSource = templist;
                    }
                }
                if (products != null)
                {
                    if (products.Count > 0)
                    {
                        List<Products> templist = new List<Products>();
                        foreach (var item in products)
                        {
                            bool globalresult = false;
                            PropertyInfo[] properties = item.GetType().GetProperties();
                            foreach (var property in properties)
                            {
                                if (property.GetGetMethod().IsVirtual == false)
                                {
                                    bool localresult = WorkWithUIElements.IsPropertyContainsWord(property.GetValue(item), SearchTB.Text);
                                    if (localresult == true) { globalresult = true; break; }
                                }
                            }
                            if (globalresult == true) { templist.Add(item); }
                        }

                        DG.ItemsSource = templist;
                    }
                }
                if (ordersCompositions != null)
                {
                    if (ordersCompositions.Count > 0)
                    {
                        List<OrdersCompositions> templist = new List<OrdersCompositions>();
                        foreach (var item in ordersCompositions)
                        {
                            bool globalresult = false;
                            PropertyInfo[] properties = item.GetType().GetProperties();
                            foreach (var property in properties)
                            {
                                if (property.GetGetMethod().IsVirtual == false)
                                {
                                    bool localresult = WorkWithUIElements.IsPropertyContainsWord(property.GetValue(item), SearchTB.Text);
                                    if (localresult == true) { globalresult = true; break; }
                                }
                            }
                            if (globalresult == true) { templist.Add(item); }
                        }

                        DG.ItemsSource = templist;
                    }
                }
                if (orders != null)
                {
                    if (orders.Count > 0)
                    {
                        List<Orders> templist = new List<Orders>();
                        foreach (var item in orders)
                        {
                            bool globalresult = false;
                            PropertyInfo[] properties = item.GetType().GetProperties();
                            foreach (var property in properties)
                            {
                                if (property.GetGetMethod().IsVirtual == false)
                                {
                                    bool localresult = WorkWithUIElements.IsPropertyContainsWord(property.GetValue(item), SearchTB.Text);
                                    if (localresult == true) { globalresult = true; break; }
                                }
                            }
                            if (globalresult == true) { templist.Add(item); }
                        }

                        DG.ItemsSource = templist;
                    }
                }
                if (carts != null)
                {
                    if (carts.Count > 0)
                    {
                        List<Cart> templist = new List<Cart>();
                        foreach (var item in carts)
                        {
                            bool globalresult = false;
                            PropertyInfo[] properties = item.GetType().GetProperties();
                            foreach (var property in properties)
                            {
                                if (property.GetGetMethod().IsVirtual == false)
                                {
                                    bool localresult = WorkWithUIElements.IsPropertyContainsWord(property.GetValue(item), SearchTB.Text);
                                    if (localresult == true) { globalresult = true; break; }
                                }
                            }
                            if (globalresult == true) { templist.Add(item); }
                        }

                        DG.ItemsSource = templist;
                    }
                }
                if (actionTypes != null)
                {
                    if (actionTypes.Count > 0)
                    {
                        List<ActionTypes> templist = new List<ActionTypes>();
                        foreach (var item in actionTypes)
                        {
                            bool globalresult = false;
                            PropertyInfo[] properties = item.GetType().GetProperties();
                            foreach (var property in properties)
                            {
                                if (property.GetGetMethod().IsVirtual == false)
                                {
                                    bool localresult = WorkWithUIElements.IsPropertyContainsWord(property.GetValue(item), SearchTB.Text);
                                    if (localresult == true) { globalresult = true; break; }
                                }
                            }
                            if (globalresult == true) { templist.Add(item); }
                        }

                        DG.ItemsSource = templist;
                    }
                }
                if (actions != null)
                {
                    if (actions.Count > 0)
                    {
                        List<Actions> templist = new List<Actions>();
                        foreach (var item in actions)
                        {
                            bool globalresult = false;
                            PropertyInfo[] properties = item.GetType().GetProperties();
                            foreach (var property in properties)
                            {
                                if (property.GetGetMethod().IsVirtual == false)
                                {
                                    bool localresult = WorkWithUIElements.IsPropertyContainsWord(property.GetValue(item), SearchTB.Text);
                                    if (localresult == true) { globalresult = true; break; }
                                }
                            }
                            if (globalresult == true) { templist.Add(item); }
                        }

                        DG.ItemsSource = templist;
                    }
                }
            }
            if (SearchTB.Text == "Поиск..." | SearchTB.Text == "")
            {
                if (users != null)
                {
                    DG.ItemsSource = users;
                }
                if (workers != null)
                {
                    DG.ItemsSource = workers;
                }
                if (roles != null)
                {
                    DG.ItemsSource = roles;
                }
                if (productTypes != null)
                {
                    DG.ItemsSource = productTypes;
                }
                if (products != null)
                {
                    DG.ItemsSource = products;
                }
                if (ordersCompositions != null)
                {
                    DG.ItemsSource = ordersCompositions;
                }
                if (orders != null)
                {
                    DG.ItemsSource = orders;
                }
                if (carts != null)
                {
                    DG.ItemsSource = carts;
                }
                if (actionTypes != null)
                {
                    DG.ItemsSource = actionTypes;
                }
                if (actions != null)
                {
                    DG.ItemsSource = actions;
                }
            }
        }

        private void SearchTB_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(SearchTB.Text == "Поиск...") { SearchTB.Text = ""; }
        }

        private void SearchTB_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (SearchTB.Text == "" & SearchTB.IsFocused == false) { SearchTB.Text = "Поиск..."; }
        }

    }
}
