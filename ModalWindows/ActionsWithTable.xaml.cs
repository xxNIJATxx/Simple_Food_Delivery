using Simple_Food_Delivery.Models;
using Simple_Food_Delivery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Simple_Food_Delivery.ModalWindows
{
    public partial class ActionsWithTable : Window
    {
        FCDBContext Context = new FCDBContext();
        static string WhatTypeOfModelReceived;
        public static object ReceivedItem;
        public static bool IsChanged;
        public static bool IsLoginChanged;
        public static bool IsEmailChanged;
        public static bool IsPhoneChanged;
        public static bool IsNewItem;

        public static bool IsSMTHChangedOrAdded;

        public static bool IsItAdminData;

        
        public ActionsWithTable(bool IsItNewItem, object item)
        {
            InitializeComponent();

            if (IsItNewItem == false)
            {
                IsNewItem = false;
                if (item is Workers)
                {
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    Workers worker = item as Workers;
                    PropertyInfo[] properties = worker.GetType().GetProperties();
                    for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                    {
                        PropertyInfo property = properties[i + 1];
                        textboxes[i].Text = Convert.ToString(property.GetValue(worker));
                    }
                    WhatTypeOfModelReceived = "Сотрудник";
                    if(worker.RoleId == 1) { IsItAdminData = true; }
                    ReceivedItem = worker;
                }
                if (item is Users)
                {
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    for (global::System.Int32 i = 9; i < textblocks.Count; i++)
                    {
                        textblocks[i].Visibility = Visibility.Hidden; textboxes[i].Visibility = Visibility.Hidden;
                    }

                    Users user = item as Users;
                    PropertyInfo[] properties = user.GetType().GetProperties();
                    for (global::System.Int32 i = 0; i < textboxes.Count - 2; i++)
                    {
                        PropertyInfo property = properties[i + 1];
                        textboxes[i].Text = Convert.ToString(property.GetValue(user));
                    }
                    WhatTypeOfModelReceived = "Пользователь";
                    ReceivedItem = user;
                }
                if (item is Roles)
                {
                    string[] names = { "Роль", "Название роли", "Описание" };
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    Roles role = item as Roles;
                    PropertyInfo[] properties = role.GetType().GetProperties();
                    for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                    {
                        if (i == 5) { textboxes[i].IsReadOnly = true; continue; }
                        if (i == 6) { continue; }
                        if (i == 9) { continue; }
                        textboxes[i].Visibility = Visibility.Hidden;
                        textblocks[i].Visibility = Visibility.Hidden;
                    }
                    int[] numbers = { 5, 6, 9 };

                    for (global::System.Int32 i = 0; i < names.Length; i++)
                    {
                        int num = numbers[i];
                        textblocks[num].Text = names[i];
                        PropertyInfo property = properties[i];
                        textboxes[num].Text = Convert.ToString(property.GetValue(role));
                    }
                    WhatTypeOfModelReceived = "Роль";
                    ReceivedItem = role;
                }
                if (item is Products)
                {
                    string[] names = { "Имя товара", "Тип товара", "Цена", "Заказано", "Продано", "Осталось", "Фото товара", "Описание товара" };
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    Products product = item as Products;
                    PropertyInfo[] properties = product.GetType().GetProperties();
                    for (global::System.Int32 i = 8; i < textboxes.Count; i++)
                    {
                        textboxes[i].Visibility = Visibility.Hidden;
                        textblocks[i].Visibility = Visibility.Hidden;
                    }

                    for (global::System.Int32 i = 0; i < names.Length; i++)
                    {
                        textblocks[i].Text = names[i];

                        PropertyInfo property = properties[i + 1];
                        textboxes[i].Text = Convert.ToString(property.GetValue(product));
                    }
                    WhatTypeOfModelReceived = "Товар";
                    ReceivedItem = product;
                }
                if (item is ProductType)
                {
                    string[] names = { "ID типа товара", "Название типа товара" };
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    ProductType productType = item as ProductType;
                    PropertyInfo[] properties = productType.GetType().GetProperties();
                    for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                    {
                        if (i == 9) { continue; }
                        if (i == 10) { continue; }
                        textboxes[i].Visibility = Visibility.Hidden;
                        textblocks[i].Visibility = Visibility.Hidden;
                    }
                    int[] numbers = { 9, 10 };

                    for (global::System.Int32 i = 0; i < names.Length; i++)
                    {
                        int num = numbers[i];
                        textblocks[num].Text = names[i];
                        PropertyInfo property = properties[i];
                        textboxes[num].Text = Convert.ToString(property.GetValue(productType));
                    }
                    WhatTypeOfModelReceived = "Тип товара";
                    ReceivedItem = productType;
                }
                if (item is Orders)
                {
                    string[] names = { "ID курьера", "ID заказчика", "Адрес доставки", "Дата заказа", "Дата доставки", "Статус заказа", "Итоговая цена" };
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    Orders order = item as Orders;
                    PropertyInfo[] properties = order.GetType().GetProperties();
                    for (global::System.Int32 i = 7; i < textboxes.Count; i++)
                    {
                        textboxes[i].Visibility = Visibility.Hidden;
                        textblocks[i].Visibility = Visibility.Hidden;
                    }

                    for (global::System.Int32 i = 0; i < names.Length; i++)
                    {
                        textblocks[i].Text = names[i];

                        PropertyInfo property = properties[i + 1];
                        textboxes[i].Text = Convert.ToString(property.GetValue(order));
                    }
                    WhatTypeOfModelReceived = "Заказ";
                    ReceivedItem = order;
                }
                if (item is OrdersCompositions)
                {
                    string[] names = { "ID заказа", "Название товара", "Кол-во товара" };
                    int iteratorfornames = 0;

                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    OrdersCompositions ordersCompositions = item as OrdersCompositions;
                    PropertyInfo[] properties = ordersCompositions.GetType().GetProperties();
                    int[] numbers = { 1, 2, 5 };
                    for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                    {
                        if (i != 1 & i != 2 & i != 5)
                        {
                            textboxes[i].Visibility = Visibility.Hidden;
                            textblocks[i].Visibility = Visibility.Hidden;
                        }
                    }

                    int iteratoforproperties = 0;
                    for (global::System.Int32 i = 0; i < textblocks.Count; i++)
                    {
                        if (i != 1 & i != 2 & i != 5) { continue; }

                        textblocks[i].Text = names[iteratorfornames];
                        iteratorfornames++;

                        PropertyInfo property = properties[iteratoforproperties];
                        textboxes[i].Text = Convert.ToString(property.GetValue(ordersCompositions));
                        iteratoforproperties++;
                    }
                    WhatTypeOfModelReceived = "Состав заказа";
                    ReceivedItem = ordersCompositions;
                }
                if (item is Actions)
                {
                    string[] names = { "Тип действия", "Дата действия", "ID пользователя" };
                    int iteratorfornames = 0;

                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    Actions action = item as Actions;
                    PropertyInfo[] properties = action.GetType().GetProperties();
                    int[] numbers = { 1, 2, 5 };
                    for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                    {
                        if (i != 1 & i != 2 & i != 5)
                        {
                            textboxes[i].Visibility = Visibility.Hidden;
                            textblocks[i].Visibility = Visibility.Hidden;
                        }
                    }

                    int iteratoforproperties = 0;
                    for (global::System.Int32 i = 0; i < textblocks.Count; i++)
                    {
                        if (i != 1 & i != 2 & i != 5) { continue; }

                        textblocks[i].Text = names[iteratorfornames];
                        iteratorfornames++;

                        PropertyInfo property = properties[iteratoforproperties];
                        textboxes[i].Text = Convert.ToString(property.GetValue(action));
                        iteratoforproperties++;
                    }
                    WhatTypeOfModelReceived = "Действие";
                    ReceivedItem = action;
                }
                if (item is ActionTypes)
                {
                    string[] names = { "ID типа действия", "Название действия" };
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    ActionTypes actionTypes = item as ActionTypes;
                    PropertyInfo[] properties = actionTypes.GetType().GetProperties();
                    for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                    {
                        if (i == 9) { continue; }
                        if (i == 10) { continue; }
                        textboxes[i].Visibility = Visibility.Hidden;
                        textblocks[i].Visibility = Visibility.Hidden;
                    }
                    int[] numbers = { 9, 10 };

                    for (global::System.Int32 i = 0; i < names.Length; i++)
                    {
                        int num = numbers[i];
                        textblocks[num].Text = names[i];
                        PropertyInfo property = properties[i];
                        textboxes[num].Text = Convert.ToString(property.GetValue(actionTypes));
                    }
                    WhatTypeOfModelReceived = "Тип действия";
                    ReceivedItem = actionTypes;
                }
                if (item is Cart)
                {
                    string[] names = { "ID пользователя", "Название товара", "Кол-во товара", "Фото товара", "Цена" };
                    int iteratorfornames = 0;

                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    Cart cart = item as Cart;
                    PropertyInfo[] properties = cart.GetType().GetProperties();
                    int[] numbers = { 0, 3, 4, 7, 8, 11 };
                    for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                    {
                        if (i == 0 | i == 3 | i == 4 | i == 7 | i == 8 | i == 10 | i == 11)
                        {
                            textboxes[i].Visibility = Visibility.Hidden;
                            textblocks[i].Visibility = Visibility.Hidden;
                        }
                    }

                    int iteratoforproperties = 0;
                    for (global::System.Int32 i = 0; i < textblocks.Count; i++)
                    {
                        if (i == 0 | i == 3 | i == 4 | i == 7 | i == 8 | i == 10 | i == 11) { continue; }

                        textblocks[i].Text = names[iteratorfornames];
                        iteratorfornames++;

                        PropertyInfo property = properties[iteratoforproperties];
                        textboxes[i].Text = Convert.ToString(property.GetValue(cart));
                        iteratoforproperties++;
                    }
                    WhatTypeOfModelReceived = "Корзина";
                    ReceivedItem = cart;
                }
            }

            if (IsItNewItem == true)
            {
                IsNewItem = true;
                if (item is Workers)
                {
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    Workers worker = item as Workers;
                    WhatTypeOfModelReceived = "Сотрудник";
                }
                if (item is Users)
                {
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    for (global::System.Int32 i = 9; i < textblocks.Count; i++)
                    {
                        textblocks[i].Visibility = Visibility.Hidden; textboxes[i].Visibility = Visibility.Hidden;
                    }

                    Users user = item as Users;
                    WhatTypeOfModelReceived = "Пользователь";
                }
                if (item is Roles)
                {
                    string[] names = { "Роль", "Название роли", "Описание" };
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    Roles role = item as Roles;
                    PropertyInfo[] properties = role.GetType().GetProperties();
                    for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                    {
                        if (i == 5) { textboxes[i].IsReadOnly = true; continue; }
                        if (i == 6) { continue; }
                        if (i == 9) { continue; }
                        textboxes[i].Visibility = Visibility.Hidden;
                        textblocks[i].Visibility = Visibility.Hidden;
                    }
                    int[] numbers = { 5, 6, 9 };

                    for (global::System.Int32 i = 0; i < names.Length; i++)
                    {
                        int num = numbers[i];
                        textblocks[num].Text = names[i];
                    }
                    WhatTypeOfModelReceived = "Роль";
                }
                if (item is Products)
                {
                    string[] names = { "Имя товара", "Тип товара", "Цена", "Заказано", "Продано", "Осталось", "Фото товара", "Описание товара" };
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    Products product = item as Products;
                    PropertyInfo[] properties = product.GetType().GetProperties();
                    for (global::System.Int32 i = 8; i < textboxes.Count; i++)
                    {
                        textboxes[i].Visibility = Visibility.Hidden;
                        textblocks[i].Visibility = Visibility.Hidden;
                    }

                    for (global::System.Int32 i = 0; i < names.Length; i++)
                    {
                        textblocks[i].Text = names[i];
                    }
                    WhatTypeOfModelReceived = "Товар";
                }
                if (item is ProductType)
                {
                    string[] names = { "ID типа товара", "Название типа товара" };
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    ProductType productType = item as ProductType;
                    PropertyInfo[] properties = productType.GetType().GetProperties();
                    for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                    {
                        if (i == 9) { continue; }
                        if (i == 10) { continue; }
                        textboxes[i].Visibility = Visibility.Hidden;
                        textblocks[i].Visibility = Visibility.Hidden;
                    }
                    int[] numbers = { 9, 10 };

                    for (global::System.Int32 i = 0; i < names.Length; i++)
                    {
                        int num = numbers[i];
                        textblocks[num].Text = names[i];
                    }
                    WhatTypeOfModelReceived = "Тип товара";
                }
                if (item is Orders)
                {
                    string[] names = { "ID курьера", "ID заказчика", "Адрес доставки", "Дата заказа", "Дата доставки", "Статус заказа", "Итоговая цена" };
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    Orders order = item as Orders;
                    PropertyInfo[] properties = order.GetType().GetProperties();
                    for (global::System.Int32 i = 7; i < textboxes.Count; i++)
                    {
                        textboxes[i].Visibility = Visibility.Hidden;
                        textblocks[i].Visibility = Visibility.Hidden;
                    }

                    for (global::System.Int32 i = 0; i < names.Length; i++)
                    {
                        textblocks[i].Text = names[i];
                    }
                    WhatTypeOfModelReceived = "Заказ";
                }
                if (item is OrdersCompositions)
                {
                    string[] names = { "ID заказа", "Название товара", "Кол-во товара" };
                    int iteratorfornames = 0;

                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    OrdersCompositions ordersCompositions = item as OrdersCompositions;
                    PropertyInfo[] properties = ordersCompositions.GetType().GetProperties();
                    int[] numbers = { 1, 2, 5 };
                    for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                    {
                        if (i != 1 & i != 2 & i != 5)
                        {
                            textboxes[i].Visibility = Visibility.Hidden;
                            textblocks[i].Visibility = Visibility.Hidden;
                        }
                    }

                    for (global::System.Int32 i = 0; i < textblocks.Count; i++)
                    {
                        if (i != 1 & i != 2 & i != 5) { continue; }

                        textblocks[i].Text = names[iteratorfornames];
                        iteratorfornames++;
                    }
                    WhatTypeOfModelReceived = "Состав заказа";
                }
                if (item is Actions)
                {
                    string[] names = { "Тип действия", "Дата действия", "ID пользователя" };
                    int iteratorfornames = 0;

                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    Actions action = item as Actions;
                    PropertyInfo[] properties = action.GetType().GetProperties();
                    int[] numbers = { 1, 2, 5 };
                    for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                    {
                        if (i != 1 & i != 2 & i != 5)
                        {
                            textboxes[i].Visibility = Visibility.Hidden;
                            textblocks[i].Visibility = Visibility.Hidden;
                        }
                    }

                    for (global::System.Int32 i = 0; i < textblocks.Count; i++)
                    {
                        if (i != 1 & i != 2 & i != 5) { continue; }

                        textblocks[i].Text = names[iteratorfornames];
                        iteratorfornames++;
                    }
                    WhatTypeOfModelReceived = "Действие";
                }
                if (item is ActionTypes)
                {
                    string[] names = { "ID типа действия", "Название действия" };
                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    ActionTypes actionTypes = item as ActionTypes;
                    PropertyInfo[] properties = actionTypes.GetType().GetProperties();
                    for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                    {
                        if (i == 9) { continue; }
                        if (i == 10) { continue; }
                        textboxes[i].Visibility = Visibility.Hidden;
                        textblocks[i].Visibility = Visibility.Hidden;
                    }
                    int[] numbers = { 9, 10 };

                    for (global::System.Int32 i = 0; i < names.Length; i++)
                    {
                        int num = numbers[i];
                        textblocks[num].Text = names[i];
                    }
                    WhatTypeOfModelReceived = "Тип действия";
                }
                if (item is Cart)
                {
                    string[] names = { "ID пользователя", "Название товара", "Кол-во товара", "Фото товара", "Цена" };
                    int iteratorfornames = 0;

                    List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                    List<TextBlock> textblocks = Grid1.Children.OfType<TextBlock>().ToList();
                    Cart cart = item as Cart;
                    PropertyInfo[] properties = cart.GetType().GetProperties();
                    int[] numbers = { 0, 3, 4, 7, 8, 11 };
                    for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                    {
                        if (i == 0 | i == 3 | i == 4 | i == 7 | i == 8 | i == 10 | i == 11)
                        {
                            textboxes[i].Visibility = Visibility.Hidden;
                            textblocks[i].Visibility = Visibility.Hidden;
                        }
                    }

                    for (global::System.Int32 i = 0; i < textblocks.Count; i++)
                    {
                        if (i == 0 | i == 3 | i == 4 | i == 7 | i == 8 | i == 10 | i == 11) { continue; }

                        textblocks[i].Text = names[iteratorfornames];
                        iteratorfornames++;
                    }
                    WhatTypeOfModelReceived = "Корзина";
                }
            }
        }


        private void CloseB_Click(object sender, RoutedEventArgs e)
        {
            ActionsWithTable mainWindow = System.Windows.Application.Current.Windows.OfType<ActionsWithTable>().FirstOrDefault(w => w.Title == "ActionsWithTable");
            ActionsWithWindows.CloseWindow(mainWindow);
        }



        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (IsNewItem == false)
                {

                    if (WhatTypeOfModelReceived == "Сотрудник")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                        Workers worker = new Workers();
                        PropertyInfo[] properties = worker.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i + 1];
                            if (property.PropertyType == typeof(int)) { property.SetValue(worker, int.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(decimal)) { property.SetValue(worker, decimal.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(DateTime)) { property.SetValue(worker, DateTime.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(string)) { property.SetValue(worker, textboxes[i].Text); }
                        }
                        if (worker != ReceivedItem as Workers)
                        {
                            Workers temp = ReceivedItem as Workers;
                            if (worker.WorkerLogin != temp.WorkerLogin) { IsLoginChanged = true; }
                            if (worker.WorkerEmail != temp.WorkerEmail) { IsEmailChanged = true; }
                            if (worker.WorkerPhone != temp.WorkerPhone) { IsPhoneChanged = true; }
                            ReceivedItem = worker;
                            IsChanged = true;
                        }
                    }

                    if (WhatTypeOfModelReceived == "Пользователь")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        Users user = new Users();
                        PropertyInfo[] properties = user.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i + 1];
                            if (property.PropertyType == typeof(string)) { property.SetValue(user, textboxes[i].Text); }
                        }
                        if (user != ReceivedItem as Users)
                        {
                            Users temp = ReceivedItem as Users;
                            if (user.UserLogin != temp.UserLogin) { IsLoginChanged = true; }
                            if (user.UserEmail != temp.UserEmail) { IsEmailChanged = true; }
                            if (user.UserPhone != temp.UserPhone) { IsPhoneChanged = true; }
                            ReceivedItem = user;
                            IsChanged = true;
                        }
                    }
                    if (WhatTypeOfModelReceived == "Роль")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        Roles role = new Roles();
                        PropertyInfo[] properties = role.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i];
                            if (property.PropertyType == typeof(string)) { property.SetValue(role, textboxes[i].Text); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(role, int.Parse(textboxes[i].Text)); }
                        }
                        if (role != ReceivedItem as Roles) { ReceivedItem = role; IsChanged = true; }
                    }
                    if (WhatTypeOfModelReceived == "Товар")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        Products product = new Products();
                        PropertyInfo[] properties = product.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i + 1];
                            if (property.PropertyType == typeof(string)) { property.SetValue(product, textboxes[i].Text); }
                            if (property.PropertyType == typeof(decimal)) { property.SetValue(product, decimal.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(product, int.Parse(textboxes[i].Text)); }
                        }
                        if (product != ReceivedItem as Products) { ReceivedItem = product; IsChanged = true; }
                    }
                    if (WhatTypeOfModelReceived == "Тип товара")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        ProductType producttype = new ProductType();
                        PropertyInfo[] properties = producttype.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i];
                            if (property.PropertyType == typeof(string)) { property.SetValue(producttype, textboxes[i].Text); }
                            if (property.PropertyType == typeof(decimal)) { property.SetValue(producttype, decimal.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(producttype, int.Parse(textboxes[i].Text)); }
                        }
                        if (producttype != ReceivedItem as ProductType) { ReceivedItem = producttype; IsChanged = true; }
                    }
                    if (WhatTypeOfModelReceived == "Заказ")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        Orders order = new Orders();
                        PropertyInfo[] properties = order.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i + 1];
                            if (property.PropertyType == typeof(string)) { property.SetValue(order, textboxes[i].Text); }
                            if (property.PropertyType == typeof(decimal)) { property.SetValue(order, decimal.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(DateTime)) { property.SetValue(order, DateTime.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(order, int.Parse(textboxes[i].Text)); }
                        }
                        if (order != ReceivedItem as Orders) { ReceivedItem = order; IsChanged = true; }
                    }
                    if (WhatTypeOfModelReceived == "Состав заказа")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        OrdersCompositions ordersCompositions = new OrdersCompositions();
                        PropertyInfo[] properties = ordersCompositions.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i];
                            if (property.PropertyType == typeof(string)) { property.SetValue(ordersCompositions, textboxes[i].Text); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(ordersCompositions, int.Parse(textboxes[i].Text)); }
                        }
                        if (ordersCompositions != ReceivedItem as OrdersCompositions) { ReceivedItem = ordersCompositions; IsChanged = true; }
                    }
                    if (WhatTypeOfModelReceived == "Действие")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        Actions actions = new Actions();
                        PropertyInfo[] properties = actions.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i + 1];
                            if (property.PropertyType == typeof(string)) { property.SetValue(actions, textboxes[i].Text); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(actions, int.Parse(textboxes[i].Text)); }
                        }
                        if (actions != ReceivedItem as Actions) { ReceivedItem = actions; IsChanged = true; }
                    }
                    if (WhatTypeOfModelReceived == "Тип действия")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        ActionTypes actionttype = new ActionTypes();
                        PropertyInfo[] properties = actionttype.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i];
                            if (property.PropertyType == typeof(string)) { property.SetValue(actionttype, textboxes[i].Text); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(actionttype, int.Parse(textboxes[i].Text)); }
                        }
                        if (actionttype != ReceivedItem as ActionTypes) { ReceivedItem = actionttype; IsChanged = true; }
                    }
                    if (WhatTypeOfModelReceived == "Корзина")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        Cart cart = new Cart();
                        PropertyInfo[] properties = cart.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i];
                            if (property.PropertyType == typeof(string)) { property.SetValue(cart, textboxes[i].Text); }
                            if (property.PropertyType == typeof(decimal)) { property.SetValue(cart, decimal.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(cart, int.Parse(textboxes[i].Text)); }
                        }
                        if (cart != ReceivedItem as Cart) { ReceivedItem = cart; IsChanged = true; }
                    }
                    if (IsChanged == true)
                    {
                        if (IsItAdminData == true)
                        {
                            MyMessageBox.ShowMessage("Вы хотите изменить данные администратора! В целях безопасности пин-код выслан на почту данному администратору! Узнайте у администратора пин-код и введите!", MyMessageBoxImages.Information);
                            int pin = EmailService.SendPinCodeToEmail();
                            
                        }
                        IsSMTHChangedOrAdded = true;
                        bool result = MyMessageBox.ShowWithChoice("Изменить данные", MyMessageBoxImages.Information, "Подтверждение");
                        if(result == false) { ReceivedItem = null; this.Close(); }
                        else 
                        {
                            this.Close(); 
                        }
                    }
                }

                if (IsNewItem == true)
                {
                    if (WhatTypeOfModelReceived == "Сотрудник")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().ToList();
                        Workers worker = new Workers();
                        PropertyInfo[] properties = worker.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i + 1];
                            if (property.PropertyType == typeof(int)) { property.SetValue(worker, int.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(decimal)) { property.SetValue(worker, decimal.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(DateTime)) { property.SetValue(worker, DateTime.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(string)) { property.SetValue(worker, textboxes[i].Text); }
                        }
                        ReceivedItem = worker;
                        
                    }

                    if (WhatTypeOfModelReceived == "Пользователь")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        Users user = new Users();
                        PropertyInfo[] properties = user.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i + 1];
                            if (property.PropertyType == typeof(string)) { property.SetValue(user, textboxes[i].Text); }
                        }
                        ReceivedItem = user;
                        
                    }
                    if (WhatTypeOfModelReceived == "Роль")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible & t.IsEnabled == true).ToList();

                        Roles role = new Roles();
                        PropertyInfo[] properties = role.GetType().GetProperties();
                        for (global::System.Int32 i = 1; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i];
                            if (property.PropertyType == typeof(string)) { property.SetValue(role, textboxes[i].Text); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(role, int.Parse(textboxes[i].Text)); }
                        }
                        ReceivedItem = role;
                    }
                    if (WhatTypeOfModelReceived == "Товар")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        Products product = new Products();
                        PropertyInfo[] properties = product.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i + 1];
                            if (property.PropertyType == typeof(string)) { property.SetValue(product, textboxes[i].Text); }
                            if (property.PropertyType == typeof(decimal)) { property.SetValue(product, decimal.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(product, int.Parse(textboxes[i].Text)); }
                        } 
                        ReceivedItem = product;
                    }
                    if (WhatTypeOfModelReceived == "Тип товара")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        ProductType producttype = new ProductType();
                        PropertyInfo[] properties = producttype.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i];
                            if (property.PropertyType == typeof(string)) { property.SetValue(producttype, textboxes[i].Text); }
                            if (property.PropertyType == typeof(decimal)) { property.SetValue(producttype, decimal.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(producttype, int.Parse(textboxes[i].Text)); }
                        }
                        ReceivedItem = producttype;
                    }
                    if (WhatTypeOfModelReceived == "Заказ")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        Orders order = new Orders();
                        PropertyInfo[] properties = order.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i + 1];
                            if (property.PropertyType == typeof(string)) { property.SetValue(order, textboxes[i].Text); }
                            if (property.PropertyType == typeof(decimal)) { property.SetValue(order, decimal.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(DateTime)) { property.SetValue(order, DateTime.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(order, int.Parse(textboxes[i].Text)); }
                        }
                        ReceivedItem = order;
                    }
                    if (WhatTypeOfModelReceived == "Состав заказа")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        OrdersCompositions ordersCompositions = new OrdersCompositions();
                        PropertyInfo[] properties = ordersCompositions.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i];
                            if (property.PropertyType == typeof(string)) { property.SetValue(ordersCompositions, textboxes[i].Text); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(ordersCompositions, int.Parse(textboxes[i].Text)); }
                        }
                        ReceivedItem = ordersCompositions;
                    }
                    if (WhatTypeOfModelReceived == "Действие")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        Actions actions = new Actions();
                        PropertyInfo[] properties = actions.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i + 1];
                            if (property.PropertyType == typeof(string)) { property.SetValue(actions, textboxes[i].Text); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(actions, int.Parse(textboxes[i].Text)); }
                        }
                        ReceivedItem = actions;
                    }
                    if (WhatTypeOfModelReceived == "Тип действия")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible & t.IsEnabled == true).ToList();

                        ActionTypes actionttype = new ActionTypes();
                        PropertyInfo[] properties = actionttype.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i];
                            if (property.PropertyType == typeof(string)) { property.SetValue(actionttype, textboxes[i].Text); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(actionttype, int.Parse(textboxes[i].Text)); }
                        }
                        ReceivedItem = actionttype;
                    }
                    if (WhatTypeOfModelReceived == "Корзина")
                    {
                        List<TextBox> textboxes = Grid1.Children.OfType<TextBox>().Where(t => t.Visibility == Visibility.Visible).ToList();

                        Cart cart = new Cart();
                        PropertyInfo[] properties = cart.GetType().GetProperties();
                        for (global::System.Int32 i = 0; i < textboxes.Count; i++)
                        {
                            PropertyInfo property = properties[i];
                            if (property.PropertyType == typeof(string)) { property.SetValue(cart, textboxes[i].Text); }
                            if (property.PropertyType == typeof(decimal)) { property.SetValue(cart, decimal.Parse(textboxes[i].Text)); }
                            if (property.PropertyType == typeof(int)) { property.SetValue(cart, int.Parse(textboxes[i].Text)); }
                        }
                        ReceivedItem = cart;
                    }

                    if (ReceivedItem != null)
                    {
                        IsSMTHChangedOrAdded = true;
                        bool result = MyMessageBox.ShowWithChoice("Добавить данные?", MyMessageBoxImages.Information, "Подтверждение");
                        if (result == false) { ReceivedItem = null;  }
                        else { this.Close(); }
                    }

                }
            }
            catch (Exception)
            {
                MyMessageBox.ShowMessage("Убедитесь что вы заполнили все поля(кроме неактивных, фото в ЛК и отчества) и проверьте корретно ли введены данные в каждом поле!!", MyMessageBoxImages.Error, "ОШИБКА");

            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Context.Dispose();
            if (IsSMTHChangedOrAdded == false) ReceivedItem = null;
        }
    }
}
