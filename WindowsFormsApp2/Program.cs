using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using WindowsFormsApp2;
using Npgsql;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ваша строка подключения к базе данных PostgreSQL
            string connectionString = "Host=195.46.187.72;Port=5432;Username=postgres;Password=1337;Database=LibraryDB";

            // Создайте экземпляры BookManager и UserManager с передачей строки подключения
            var userManager = new UserManager(connectionString); // Передаем строку подключения
            var loginForm = new LoginForm(userManager);

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                var mainForm = new Form1(loginForm.AuthenticatedUser);
                Application.Run(mainForm);
            }
        }
    }
}
