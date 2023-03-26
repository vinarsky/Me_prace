using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega
{
    public partial class LoginPage : Form
    {

        MainPage Main = new MainPage();
        User User = new User();        

        public LoginPage()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Vypnout aplikaci?", "Shutdown", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            UserDAO UDAO = new UserDAO();
            User = UDAO.GetUserByName(UsernameTextBox.Text.ToString());
            if (User == null)
            {
                MessageBox.Show("Špatné jméno nebo heslo!");
                new Log("unsuccesful login", "user");
                return;
            }
            if (User.Password == User.EncodePassword(PasswordTextBox.Text.ToString()))
            {
                this.Hide();
                Main.Show();
                MainPage.CurrentUser = User;
                new Log("login", MainPage.CurrentUser.Username);
                return;
            }
            MessageBox.Show("Špatné jméno nebo heslo!");
            new Log("unsuccesful login", User.Username);
        }
    }
}
