using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using Npgsql;

namespace WindowsFormsApp2
{
    public partial class LoginForm : Form
    {
        private readonly UserManager _userManager;
        public User AuthenticatedUser { get; private set; }

        public LoginForm(UserManager userManager)
        {
            _userManager = userManager;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            var user = _userManager.Authenticate(username, password);

            if (user != null)
            {
                // Если пользователь найден, сохраняем его и закрываем форму
                AuthenticatedUser = user;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                // Если логин или пароль неверные, показываем сообщение об ошибке
                lblError.Visible = true;
            }
        }
    }
}

