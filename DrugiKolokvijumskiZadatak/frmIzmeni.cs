using BusinessLogic;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrugiKolokvijumskiZadatak
{
    public partial class frmIzmeni : Form
    {
        int orderID;
        OrderDTO orderDTO;
        OrderDetailsDTO detailsDTO;
        OrderBL orderBL;
        ProductBL productBL;
        CustomerBL customerBL;
        EmployeeBL employeeBL;
        ShipperBL shipperBL;
        OrderDetailsBL orderDetailsBL;

        public frmIzmeni()
        {
            InitializeComponent();
        }

        public frmIzmeni(int orderId)
        {
            InitializeComponent();
            orderID = orderId;

            orderDTO = new OrderBL().GetOrder(orderId);
            detailsDTO = new OrderDetailsBL().GetOrderDetail(orderId);
            orderBL = new OrderBL();
            productBL = new ProductBL();
            customerBL = new CustomerBL();
            employeeBL = new EmployeeBL();
            shipperBL = new ShipperBL();
            orderDetailsBL = new OrderDetailsBL();
        }

        private void RenderTable()
        {
            dataGrid.DataSource = orderDetailsBL.GetAllByOrder(orderID);
        }

        private void frmIzmeni_Load(object sender, EventArgs e)
        {
            cmbEmployee.DataSource = employeeBL.GetEmployees();
            cmbEmployee.DisplayMember = "FirstName";
            cmbEmployee.ValueMember = "EmployeeID";
            cmbEmployee.SelectedValue = orderDTO.EmployeeID;

            cmbShipper.DataSource = shipperBL.GetShippers();
            cmbShipper.DisplayMember = "CompanyName";
            cmbShipper.ValueMember = "ShipperID";


            cmbCustomer.DataSource = customerBL.GetCustomers();
            cmbCustomer.DisplayMember = "CompanyName";
            cmbCustomer.ValueMember = "CustomerID";

            cmbProduct.DataSource = productBL.GetProducts();
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
            cmbProduct.SelectedIndex = -1;

            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            RenderTable();
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            OrderBL orderBl = new OrderBL();

            try
            {
                orderDTO.CustomerID = cmbCustomer.SelectedValue.ToString();
                orderDTO.EmployeeID = int.Parse(cmbEmployee.SelectedValue.ToString());
                orderBl.Save(orderDTO);

                dataGrid.Refresh();
                RenderTable();

                MessageBox.Show("Porudzbina je uspesno azurirana!");
            }
            catch (Exception err)
            {
                MessageBox.Show("Greska: \r\n\r\n" + err.Message);
            }
        }

        private void dataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                var selectedRow = dataGrid.SelectedRows[0];

                var productId = selectedRow.Cells["ProductID"].Value;
                var quantity = selectedRow.Cells["Quantity"].Value.ToString();
                var unitPrice = selectedRow.Cells["UnitPrice"].Value.ToString();
                var discount = selectedRow.Cells["Discount"].Value.ToString();

                txtDiscount.Text = discount;
                txtPrice.Text = unitPrice;
                txtQuantity.Text = quantity;
                cmbProduct.SelectedValue = productId;
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGrid.SelectedRows[0];

            var productId = selectedRow.Cells["ProductID"].Value.ToString();
            var quantity = selectedRow.Cells["Quantity"].Value.ToString();
            var unitPrice = selectedRow.Cells["UnitPrice"].Value.ToString();
            var discount = selectedRow.Cells["Discount"].Value.ToString();

            if (string.IsNullOrEmpty(productId) || string.IsNullOrEmpty(quantity) || string.IsNullOrEmpty(unitPrice) || string.IsNullOrEmpty(discount))
            {
                MessageBox.Show("Sva polja su obavezna!");
                return;
            }
            OrderDetailsBL orderDetailsBl = new OrderDetailsBL();

            try
            {
                detailsDTO.ProductID = int.Parse(cmbProduct.SelectedValue.ToString());
                detailsDTO.Quantity = short.Parse(txtQuantity.Text);
                detailsDTO.UnitPrice = decimal.Parse(txtPrice.Text);
                detailsDTO.Discount = float.Parse(txtDiscount.Text);
                orderDetailsBl.Save(detailsDTO);


                MessageBox.Show("Stavka je uspesno azurirana!");
                dataGrid.Refresh();
                RenderTable();

            }
            catch (Exception err)
            {
                MessageBox.Show("Greska: \r\n\r\n" + err.Message);
            }
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbShipper_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
