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
    public partial class UserPage : Form
    {
        public UserPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// occurs on first form load, filles in the users atributes to the texboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserPage_Load(object sender, EventArgs e)
        {
            TelnumBox.Maximum = 999999999;
            UserName.Text = MainPage.CurrentUser.ToString().ToUpper();
            UserAccess.Text = MainPage.CurrentUser.Access.ToString().ToUpper();
            UnderLine.Width = UserName.Width;
            FirstnameBox.Text = MainPage.CurrentUser.Firstname;
            LastnameBox.Text = MainPage.CurrentUser.Lastname;
            UsernameBox.Text = MainPage.CurrentUser.Username;
            EmailBox.Text = MainPage.CurrentUser.Email;
            TelnumBox.Text = MainPage.CurrentUser.Tel.ToString();
        }
        /// <summary>
        /// if current value doesnt match with the value in the textbox, the value will be updated in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommitChanges_Click(object sender, EventArgs e)
        {
            if (FirstnameBox.Text != MainPage.CurrentUser.Firstname)
            {
                MainPage.CurrentUser.Firstname = FirstnameBox.Text;
                MainPage.CurrentUser.UpdateFirstname("employee");
            }

            if (PasswordBox.Text.Length > 0)
            {
                MainPage.CurrentUser.Password = MainPage.CurrentUser.EncodePassword(PasswordBox.Text);
                MainPage.CurrentUser.UpdatePassword();
            }

            if (LastnameBox.Text != MainPage.CurrentUser.Lastname)
            {
                MainPage.CurrentUser.Lastname = LastnameBox.Text;
                MainPage.CurrentUser.UpdateLastname("employee");
            }

            if (UsernameBox.Text != MainPage.CurrentUser.Username)
            {
                MainPage.CurrentUser.Username = UsernameBox.Text;
                MainPage.CurrentUser.UpdateUsername();
            }

            if (EmailBox.Text != MainPage.CurrentUser.Email)
            {
                MainPage.CurrentUser.Email = EmailBox.Text;
                MainPage.CurrentUser.UpdateEmail("employee");
            }

            if (TelnumBox.Value != MainPage.CurrentUser.Tel)
            {
                MainPage.CurrentUser.Tel = Convert.ToInt32(TelnumBox.Text);
                MainPage.CurrentUser.UpdateTel("employee");
            }
            UserName.Text = MainPage.CurrentUser.ToString().ToUpper();
        }
        /// <summary>
        /// updates the name in heading
        /// </summary>
        public void UpdateUserName()
        {
            UserName.Text = MainPage.CurrentUser.ToString().ToUpper();
        }
    }
}
