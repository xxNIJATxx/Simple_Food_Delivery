using Simple_Food_Delivery.Models;
using System;

namespace Simple_Food_Delivery.Services
{
    public class MyLogger
    {
        public static void WriteLogInDB(int ActionTypeID, int UserID, FCDBContext Context)
        {
            Actions action = new Actions();
            action.ActionTypeId = ActionTypeID;
            action.DateOfAction = DateTime.Now;
            action.UserId = UserID;
            Context.Actions.Add(action);
            Context.SaveChanges();
        }
    }
}
