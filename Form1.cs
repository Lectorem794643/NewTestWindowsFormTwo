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
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace NewTestWindowsFormTwo
{
    public struct UserData
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
            Debug.WriteLine($"Id: {UserID}  Логин: {UserLogin} Имя пользователя: {UserName} Cтатус пароля: {UserPasswordStatus} Роль: {UserRole}");
        }
    }


    public partial class Form1 : Form
    {
        DataBase database = new DataBase();

        public Form1() //Main
        {
            InitializeComponent();
            SetNewUserDataSQL(dataGridView1);

        }


        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4));
        }

        private void SetNewUserDataSQL(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from test_table";
            SqlCommand command = new SqlCommand(queryString, database.getConnection());
            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
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
