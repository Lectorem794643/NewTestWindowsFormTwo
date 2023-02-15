using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NewTestWindowsFormTwo
{
    public enum EnumUserPasswordStatus // !!!
    { 
        outdated,  // устарел
        relevant   // актуален
    }

    public enum EnumUserRole // !!!
    { 
        administrator, // Администратор
        editor,        // Редактор
        user           // Пользователь
    }


    public struct UserData
    {
        // Ячейки такие:
        // Id,  Логин, Имя пользователя, статус пароля, роль
        public string UserID;
        public string UserLogin;
        public string UserName;
        public EnumUserPasswordStatus UserPasswordStatus;
        public EnumUserRole UserRole;

        public UserData(string ID, string Login, string Name, EnumUserPasswordStatus PasswordStatus, EnumUserRole Role)
        {
            UserID = ID;
            UserLogin = Login;
            UserName = Name;
            UserPasswordStatus = PasswordStatus;
            UserRole = Role;
        }

        
        public void PrintUserData()
        {
            Debug.WriteLine($"Id: {UserID}  Логин: {UserLogin} Имя пользователя: {UserName} Cтатус пароля: {UserPasswordStatus} Роль: {UserRole}");
        }
    }


    public partial class Form1 : Form
    {
        public Form1() //Main
        {
            InitializeComponent();
            // startNewTable(); ?


            string[] DataUserName = { "Вологодский Н.И.", "Кораблев В.И.",
            "Волков Р.А.", "Стержнев В.С.", "Августин A.A." };

            UserData[] ListTest = new UserData[5];

            for (int i = 0; i < 5; i++) 
            {
                ListTest[i] = new UserData("00" + (i + 1).ToString(), DataUserName[i], DataUserName[i], EnumUserPasswordStatus.relevant, EnumUserRole.administrator); // создали структуру

                SetNewUserData(ListTest[i]); // на табличку
                ListTest[i].PrintUserData(); //вывод в консоль
            }

        }

        public void SetNewUserData(UserData NewRows)
        {
            DataGridViewCell ID = new DataGridViewTextBoxCell();
            DataGridViewCell Login = new DataGridViewTextBoxCell();
            DataGridViewCell Name = new DataGridViewTextBoxCell();
            DataGridViewCell PasswordStatus = new DataGridViewTextBoxCell();
            DataGridViewCell Role = new DataGridViewTextBoxCell();

            ID.Value = NewRows.UserID;
            Login.Value = NewRows.UserLogin;
            Name.Value = NewRows.UserName;
            PasswordStatus.Value = NewRows.UserPasswordStatus;
            Role.Value = NewRows.UserRole;

            DataGridViewRow NewRow = new DataGridViewRow();
            NewRow.Cells.AddRange(ID, Login, Name, PasswordStatus, Role);
            dataGridView1.Rows.Add(NewRow);

        }
    }
}
