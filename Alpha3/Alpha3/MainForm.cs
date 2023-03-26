using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alpha3
{
    public partial class MainForm : Form
    {
        Form CurrentForm = null;

        CustomerForm CustomerPage = new CustomerForm();
        ProductForm ProductPage = new ProductForm();
        EmployeeForm EmployeePage = new EmployeeForm();
        OrderForm OrderPage = new OrderForm();
        StoreForm StorePage = new StoreForm();
        ImportForm ImportPage = new ImportForm();

        MessageBoxButtons button = MessageBoxButtons.YesNo;
        MessageBoxIcon icon = MessageBoxIcon.Question;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenSection(EmployeePage);
        }
        /// <summary>
        /// Metoda otevírá jednotlivé Forms (CustomerPage, ProductPage, ...) v Panelu na Hlavním formuláři
        /// </summary>
        /// <param name="NewUserForm">Název formuláře který se má otevřít</param>
        public void OpenSection(Form NewUserForm)
        {
            if (CurrentForm != null)
            {
                CurrentForm.Hide();//zavreni stareho formuláře
            }
            CurrentForm = NewUserForm;
            NewUserForm.TopLevel = false;
            NewUserForm.FormBorderStyle = FormBorderStyle.None;
            NewUserForm.Dock = DockStyle.Fill;
            this.Content.Controls.Add(NewUserForm);
            this.Content.Tag = NewUserForm;
            NewUserForm.Show();
        }        
        /// <summary>
        /// Metoda je eventem který se spustí kliknutím na stlačítko 'Exit', po kliknutí se aplikace zeptá zda uživatel chce aplikaci zavřít, podle rozhodnutí jí bud zavře nebo nic neudělá
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Vypnout aplikaci?", "Shutdown", button, icon);
            if (result == DialogResult.Yes)
            {
                MySqlConnection conn = DatabaseConnection.GetConnection();
                using (MySqlCommand command = new MySqlCommand("commit;", conn))
                {
                    command.ExecuteNonQuery();
                }
                Application.Exit();
            }
        }

        //Metody níže pouze otevírají jednotlivé formuláře

        private void EmplyeeButton_Click(object sender, EventArgs e)
        {
            OpenSection(EmployeePage);
        }

        private void ProductsButton_Click(object sender, EventArgs e)
        {
            OpenSection(ProductPage);
        }

        private void CustomerMenu_Click(object sender, EventArgs e)
        {
            OpenSection(CustomerPage);
        }

        private void OrderButton_Click_1(object sender, EventArgs e)
        {
            OpenSection(OrderPage);
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            OpenSection(ImportPage);
        }

        private void Storesbutton_Click(object sender, EventArgs e)
        {
            OpenSection(StorePage);
        }
    }
}
