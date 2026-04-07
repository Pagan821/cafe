using System;
using System.Windows.Forms;
using Система_учета_заказов_в_кафешке.Database;

namespace Система_учета_заказов_в_кафешке.Forms
{
    public partial class LoginForm : Form
    {
        private DatabaseService _db;

        public LoginForm()
        {
            _db = DatabaseService.Instance;
            InitializeComponent();
            this.FormClosing += LoginForm_FormClosing;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_db != null && _db is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите имя пользователя и пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role;
            if (_db.AuthenticateUser(username, password, out role))
            {
                MessageBox.Show($"Добро пожаловать, {username}!", "Успешно",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                MainForm mainForm = new MainForm(username, role);
                mainForm.Show();

                this.Hide();

                mainForm.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}