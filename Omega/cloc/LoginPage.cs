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

        /// <summary>
        /// event occures when user clicks exit button to shut down the app
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Vypnout aplikaci?", "Shutdown", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        /// <summary>
        /// event occuers when user clicks login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            UserDAO UDAO = new UserDAO();
            User = UDAO.GetUserByName(UsernameTextBox.Text.ToString());//gets user with inserted username
            if (User == null)//if user is null, then the username isnt in database
            {
                MessageBox.Show("Špatné jméno nebo heslo!");
                new Log("unsuccesful login", "user");
                return;
            }
            if (User.Password == User.EncodePassword(PasswordTextBox.Text.ToString()))//if users password is the same as insert password by user, the login is succesful
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

        private void LoginPage_Load(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = true;//ensures that password will be invisible while typing it in
        }
    }
}
