using Simple_Food_Delivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simple_Food_Delivery.Services
{
    public static class HelpForRegistration_Authorization
    {
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                bool IsEmailExist = IsEmailExists(addr.Address);
                if(IsEmailExist == false) { return addr.Address == trimmedEmail; }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidNumberPhone(ref string Nomer)
        {
            try
            {
                if(Nomer.Length == 15) { return true; }
                if (Nomer.Length == 11)
                {
                    string CorrectedNumber = "";
                    for (global::System.Int32 i = 0; i < Nomer.Length; i++)
                    {
                        if (i == 0)
                        {
                            CorrectedNumber = Convert.ToString(Nomer[i]);
                        }
                        if (i > 0)
                        {
                            if (i == Nomer.Length - 1)
                            {
                                CorrectedNumber += Convert.ToString(Nomer[i]); break;
                            }
                            if (i == 1)
                            {
                                if (Nomer[i] != '(') { CorrectedNumber += "("; }
                                else { CorrectedNumber += Convert.ToString(Nomer[i]); }
                            }
                            if (i < 4)
                            {
                                CorrectedNumber += Convert.ToString(Nomer[i]); continue;
                            }
                            if (i == 4)
                            {
                                if (Nomer[i] != ')') { CorrectedNumber += ")"; }
                                else { CorrectedNumber += Convert.ToString(Nomer[i]); continue; }
                            }
                            if (i < 7)
                            {
                                CorrectedNumber += Convert.ToString(Nomer[i]); continue;
                            }
                            if (i == 7)
                            {
                                if (Nomer[i] != '-') { CorrectedNumber += "-"; }
                                else { CorrectedNumber += Convert.ToString(Nomer[i]); continue; }
                            }
                            if (i < 9)
                            {
                                CorrectedNumber += Convert.ToString(Nomer[i]); continue;
                            }
                            if (i == 9)
                            {
                                if (Nomer[i] != '-') { CorrectedNumber += "-" + Convert.ToString(Nomer[i]); }
                                else { CorrectedNumber += Convert.ToString(Nomer[i]); continue; }
                            }
                            if (i > 9)
                            {
                                CorrectedNumber += Convert.ToString(Nomer[i]); continue;
                            }
                        }
                    }

                    Match match = Regex.Match(CorrectedNumber, @"8\(9\d{2}\)\d{3}-\d{2}-\d{2}", RegexOptions.IgnoreCase);
                    if(match.Success == true) 
                    {
                        bool IsPhoneExist = IsPhoneNumberExists(CorrectedNumber);
                        if (IsPhoneExist == false)
                        {
                            Nomer = CorrectedNumber; 
                            return true; 
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else { return false; }
                }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }

        public static bool IsLoginExists(string Login)
        {
            FCDBContext Context = new FCDBContext();
            foreach (Users user in Context.Users)
            {
                if (user.UserLogin == Login)
                {
                    return true;
                }
            }
            foreach (Workers worker in Context.Workers)
            {
                if (worker.WorkerLogin == Login)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsEmailExists(string Email)
        {
            FCDBContext Context = new FCDBContext();
            foreach (Users user in Context.Users)
            {
                if (user.UserEmail == Email)
                {
                    return true;
                }
            }
            foreach (Workers worker in Context.Workers)
            {
                if (worker.WorkerEmail == Email)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool IsPhoneNumberExists(string PhoneNumber)
        {
            FCDBContext Context = new FCDBContext();
            foreach (Users user in Context.Users)
            {
                if (user.UserPhone == PhoneNumber)
                {
                    return true;
                }
            }
            foreach (Workers worker in Context.Workers)
            {
                if (worker.WorkerPhone == PhoneNumber)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
