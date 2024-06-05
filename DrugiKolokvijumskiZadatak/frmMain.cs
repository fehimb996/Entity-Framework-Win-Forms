using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using BusinessLogic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DrugiKolokvijumskiZadatak
{
    public partial class frmMain : Form
    {
        OrderBL orderBL;
        ProductBL productBL;
        CustomerBL customerBL;
        EmployeeBL employeeBL;

        public frmMain()
        {
            InitializeComponent();
            orderBL = new OrderBL();
            productBL = new ProductBL();
            customerBL = new CustomerBL();
            employeeBL = new EmployeeBL();
        }

        public void LoadOrders()
        {
            var orders = orderBL.GetAllOrders();
            dataGridView1.DataSource = orders;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnPorudzbina_Click(object sender, EventArgs e)
        {
            frmPorudzbina frmNovaPorudzbina = new frmPorudzbina();
            frmNovaPorudzbina.Show();
        }

        private void btnPregled_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedOrderID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["OrderID"].Value);

                frmPregled frm = new frmPregled(selectedOrderID);
                frm.Show();
            }
            else
            {
                btnPregled.Enabled = false;
            }
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbEmployee.SelectedIndex = -1;
            cmbCustomer.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
        }
    }
}
