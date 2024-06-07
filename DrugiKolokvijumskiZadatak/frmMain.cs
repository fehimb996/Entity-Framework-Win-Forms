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
            LoadComboBoxes();
            LoadOrders();
        }

        private void btnPorudzbina_Click(object sender, EventArgs e)
        {
            frmPorudzbina frmNovaPorudzbina = new frmPorudzbina();
            frmNovaPorudzbina.Show();
        }

        private void SearchOrders()
        {
            int? employeeID = null;
            if (cmbEmployee.SelectedIndex != -1 && cmbEmployee.SelectedValue is int)
            {
                employeeID = (int)cmbEmployee.SelectedValue;
            }

            string customerID = null;
            if (cmbCustomer.SelectedIndex != -1 && cmbCustomer.SelectedValue is string)
            {
                customerID = (string)cmbCustomer.SelectedValue;
            }

            int? productID = null;
            if (cmbProduct.SelectedIndex != -1 && cmbProduct.SelectedValue is int)
            {
                productID = (int)cmbProduct.SelectedValue;
            }

            var orders = orderBL.SearchOrders(employeeID, customerID, productID);
            dataGridView1.DataSource = orders;
        }

        private void LoadComboBoxes()
        {
            cmbEmployee.DataSource = employeeBL.GetEmployees();
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "EmployeeID";
            cmbEmployee.SelectedIndex = -1;

            cmbCustomer.DataSource = customerBL.GetCustomers();
            cmbCustomer.DisplayMember = "CompanyName";
            cmbCustomer.ValueMember = "CustomerID";
            cmbCustomer.SelectedIndex = -1;

            cmbProduct.DataSource = productBL.GetProducts();
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
            cmbProduct.SelectedIndex = -1;
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchOrders();
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchOrders();
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchOrders();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbEmployee.SelectedIndex = -1;
            cmbCustomer.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
            LoadOrders();
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedOrderID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                frmPregled frm = new frmPregled(selectedOrderID);
                frm.Show();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedOrderID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                frmIzmeni frm = new frmIzmeni(selectedOrderID);
                frm.Show();
            }
        }

        private void btnResetEmployee_Click(object sender, EventArgs e)
        {
            cmbEmployee.SelectedIndex = -1;
            SearchOrders();
        }

        private void btnResetCustomer_Click(object sender, EventArgs e)
        {
            cmbCustomer.SelectedIndex = -1;
            SearchOrders();
        }

        private void btnResetProduct_Click(object sender, EventArgs e)
        {
            cmbProduct.SelectedIndex = -1;
            SearchOrders();
        }
    }
}
