using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Arcade_Launcher.Libraries
{
    public class LoginSystem
    {
        public static string FolderPath = Environment.CurrentDirectory + @"\Accounts";
        public class LoggedInAccount
        {
            public static string Username { get; set; }
            public static bool Admin { get; set; }
            public static int Credits { get; set; }
        }
        
        public class AccountInfo
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public bool Admin { get; set; }
            public int Credits { get; set; }
        }
        public enum Response
        {
            Logged_In,
            Wrong_Username,
            Wrong_Password
        }

        public static Response Login(string username, string password)
        {
            string json = File.ReadAllText(FolderPath + @"\Accounts.json");
            List<AccountInfo> AllAccounts = JsonConvert.DeserializeObject<List<AccountInfo>>(json);
            AccountInfo User = AllAccounts.Find(x => x.Username.ToLower() == username.ToLower());
            try
            {
                if (User.Password == password)
                {
                    LoggedInAccount.Username = User.Username;
                    LoggedInAccount.Admin = User.Admin;
                    LoggedInAccount.Credits = User.Credits;
                    return Response.Logged_In;
                }
                else
                {
                    return Response.Wrong_Password;
                }
            }
            catch
            {
                return Response.Wrong_Username;
            }
        }

        public static void CreateFiles()
        {
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            if (!File.Exists(FolderPath + @"\Accounts.json"))
            {
                AccountInfo Acc = new AccountInfo
                {
                    Username = "Guest",
                    Password = "NONE",
                    Admin = false,
                    Credits = 0
                };

                using (StreamWriter file = File.CreateText(FolderPath + @"\Accounts.json"))
                {
                    file.Write("[");
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, Acc);
                    file.Write("]");
                }
            }
        }
    }
}
