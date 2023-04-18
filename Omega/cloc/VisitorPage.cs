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
    public partial class VisitorForm : Form
    {
        private Access neededLevel = Access.basic_access;
        BindingSource source = new BindingSource();
        public static List<Visitor> Visitors = new List<Visitor>();

        public Access NeededLevel
        {
            get { return neededLevel; }
        }
        public VisitorForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// occurs on first form load, filles in the all visitors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisitorForm_Load(object sender, EventArgs e)
        {            
            TelnumBox.Maximum = 999999999;
            source.DataSource = Visitors;
            dataGridView.DataSource = source;

            dataGridView.Columns["ID"].Visible = false;
        }
        /// <summary>
        /// adds employee in to array and database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            Visitor Visitor = new Visitor();
            Visitor.Firstname = FirstnameBox.Text;
            Visitor.Lastname = LastnameBox.Text;
            Visitor.Email = EmailBox.Text;
            Visitor.Tel = Convert.ToInt32(TelnumBox.Value);

            FirstnameBox.Clear();
            LastnameBox.Clear();
            EmailBox.Clear();
            TelnumBox.Value = 0;

            if (Visitor.Insert()) //if adding in to database fails, it doenst add to the array of employees
            {
                Visitors.Add(Visitor);
                new Log("Added visitor: " + Visitor.ToString(), MainPage.CurrentUser.Username);
                source.ResetBindings(false);
            }
        }
        /// <summary>
        /// deletes selected visitor from array and database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int row = dataGridView.SelectedCells[0].RowIndex;

            if (dataGridView.SelectedCells[0].Value == null)
                return;

            Visitor VisitorToDelete = Visitors.FirstOrDefault(u => u.ID == (int)dataGridView.Rows[row].Cells[0].Value);

            DialogResult result = MessageBox.Show("Smazat " + VisitorToDelete.ToString() + "?", "Smazat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (VisitorToDelete.Delete()) //if delete from database fails, it doesnt delete it from the array
                {
                    Visitors.Remove(VisitorToDelete);
                    new Log("deleted user: " + VisitorToDelete.ToString(), MainPage.CurrentUser.Username);
                }                    
                dataGridView.Refresh();
            }
        }

        /// <summary>
        /// event occurs when you finish cell edit with pressing enter, updates the changed column in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView.SelectedCells[0].RowIndex;
            int column = dataGridView.SelectedCells[0].ColumnIndex;

            Visitor VisitorToUpdate = Visitors.FirstOrDefault(u => u.ID == (int)dataGridView.Rows[row].Cells[0].Value);
            VisitorToUpdate.Update(dataGridView.Columns[column].Name.ToString());
        }

        /// <summary>
        /// event occurs when there is an error in datagridview, this ensures that program doesnt crash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
