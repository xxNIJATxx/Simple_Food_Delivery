using Simple_Food_Delivery.ModalWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Simple_Food_Delivery.Services
{
    public static class ActionsWithWindows
    {
        public static void CloseWindow<T>(T YourWindow)
        {
            if (YourWindow is MainWindow)
            {
                MainWindow mainWindow = System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(w => w.Title == "MainWindow");
                mainWindow.Close();
                return;
            }
            if (YourWindow is FoodDisplay)
            {
                FoodDisplay food = System.Windows.Application.Current.Windows.OfType<FoodDisplay>().FirstOrDefault(w => w.Name == "FoodDisplayWindow");
                food.Close();
                return;
            }
            if (YourWindow is MessageToSupport)
            {
                MessageToSupport support = System.Windows.Application.Current.Windows.OfType<MessageToSupport>().FirstOrDefault(w => w.Name == "MessageToSupportWindow");
                support.Close();
                return;
            }
            if (YourWindow is PersonalAccount)
            {
                PersonalAccount account = System.Windows.Application.Current.Windows.OfType<PersonalAccount>().FirstOrDefault(w => w.Name == "PersonalAccountWindow");
                account.Close();
                return;
            }
            if (YourWindow is MyMessageBox)
            {
                MyMessageBox myMessageBox = Application.Current.Windows.OfType<MyMessageBox>().FirstOrDefault(w => w.Title == "MyMessageBox");
                myMessageBox.Close();
                return;
            }
            if (YourWindow is ActionsWithTable)
            {
                ActionsWithTable actionsWithTable = Application.Current.Windows.OfType<ActionsWithTable>().FirstOrDefault(w => w.Title == "ActionsWithTable");
                actionsWithTable.Close();
                return;
            }
        }

        public static void MaxWindow<T>(T YourWindow)
        {
            if (YourWindow is MainWindow)
            {
                MainWindow mainWindow = System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(w => w.Title == "MainWindow");
                if(mainWindow.WindowState == WindowState.Maximized) { mainWindow.WindowState = WindowState.Normal; return; }
                mainWindow.WindowState = WindowState.Maximized;
                return;
            }
            if (YourWindow is FoodDisplay)
            {
                FoodDisplay food = System.Windows.Application.Current.Windows.OfType<FoodDisplay>().FirstOrDefault(w => w.Name == "FoodDisplayWindow");
                if (food.WindowState == WindowState.Maximized) { food.WindowState = WindowState.Normal; return; }
                food.WindowState = WindowState.Maximized;
                return;
            }
            if (YourWindow is MessageToSupport)
            {
                MessageToSupport support = System.Windows.Application.Current.Windows.OfType<MessageToSupport>().FirstOrDefault(w => w.Name == "MessageToSupportWindow");
                if (support.WindowState == WindowState.Maximized) { support.WindowState = WindowState.Normal; return; }
                support.WindowState = WindowState.Maximized;
                return;
            }
        }

        public static void MinWindow<T>(T YourWindow)
        {
            if (YourWindow is MainWindow)
            {
                MainWindow mainWindow = System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(w => w.Title == "MainWindow");
                mainWindow.WindowState = WindowState.Minimized;
                return;
            }
            if (YourWindow is FoodDisplay)
            {
                FoodDisplay food = System.Windows.Application.Current.Windows.OfType<FoodDisplay>().FirstOrDefault(w => w.Name == "FoodDisplayWindow");
                food.WindowState =WindowState.Minimized; 
                return;
            }
            if (YourWindow is MessageToSupport)
            {
                MessageToSupport support = System.Windows.Application.Current.Windows.OfType<MessageToSupport>().FirstOrDefault(w => w.Name == "MessageToSupportWindow");
                support.WindowState = WindowState.Minimized;
                return;
            }
            if (YourWindow is PersonalAccount)
            {
                PersonalAccount account = System.Windows.Application.Current.Windows.OfType<PersonalAccount>().FirstOrDefault(w => w.Name == "PersonalAccountWindow");
                account.WindowState = WindowState.Minimized;
                return;
            }
        }
    }
}
