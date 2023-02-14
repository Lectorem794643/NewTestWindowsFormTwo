using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTestWindowsFormTwo
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

/* ВСТАВКА С ЗАГОТОВКАМИ!!! 

using System;

struct UserData
{
   // Ячейки такие:
   // Id,  Логин, Имя пользователя, статус пароля, роль
   public string UserID;
   public string UserLogin;
   public string UserName;
   public string UserPasswordStatus;
   public string UserRole;

   public UserData(string ID, string Login, string Name, string PasswordStatus, string Role)
   {
       UserID = ID;
       UserLogin = Login;
       UserName = Name;
       UserPasswordStatus = PasswordStatus;
       UserRole = Role;
   }

   public void PrintUserData()
   {
       Console.WriteLine($"Id: {UserID}  Логин: {UserLogin} Имя пользователя: {UserName} Cтатус пароля: {UserPasswordStatus} Роль: {UserRole}");
   }
}

class HelloWorld
{
   static void Main()
   {
       string[] DataUserName = { "Вологодский Н.И.", "Кораблев В.И.   ",
   "Волков Р.А.     ", "Стержнев В.С.   ", "Августин A.A.   " };

       for (int i = 0; i < 5; i++)
       {
           UserData UserNewList;
           UserNewList = new UserData("001", DataUserName[i], DataUserName[i], "OK", "Кто-то");
           UserNewList.PrintUserData();
       }

   }
}
*/