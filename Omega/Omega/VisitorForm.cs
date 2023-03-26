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
        VisitorDAO VDAO = new VisitorDAO();

        public Access NeededLevel
        {
            get { return neededLevel; }
        }
        public VisitorForm()
        {
            InitializeComponent();
        }

        private void VisitorForm_Load(object sender, EventArgs e)
        {
            source.DataSource = VDAO.GetAllVisitors();
            dataGridView.DataSource = source;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
