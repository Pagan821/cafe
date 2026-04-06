using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Система_учета_заказов_в_кафешке.Forms;

namespace Система_учета_заказов_в_кафешке
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Показываем форму входа
            var loginForm = new LoginForm();
            Application.Run(loginForm);
        }
    }
}