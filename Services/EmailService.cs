using System;

namespace Simple_Food_Delivery.Services
{
    public static class EmailService
    {
        public static int SendPinCodeToEmail()
        {
            Random random = new Random();
            int pincode = random.Next(1000, 9999);
            MyMessageBox.ShowMessage(pincode.ToString());
            return pincode;
        }
    }
}
