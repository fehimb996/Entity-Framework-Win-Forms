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
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "EmployeeID";
            cmbEmployee.SelectedValue = orderDTO.EmployeeID;

            cmbShipper.DataSource = shipperBL.GetShippers();
            cmbShipper.DisplayMember = "CompanyName";
            cmbShipper.ValueMember = "ShipperID";
            cmbShipper.SelectedValue = orderDTO.ShipVia;

            cmbCustomer.DataSource = customerBL.GetCustomers();
            cmbCustomer.DisplayMember = "CompanyName";
            cmbCustomer.ValueMember = "CustomerID";
            cmbCustomer.SelectedValue = orderDTO.CustomerID;

            cmbProduct.DataSource = productBL.GetProducts();
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
            cmbProduct.SelectedIndex = -1;
            cmbProduct.SelectedValue = detailsDTO.ProductID;

            if (orderDTO.OrderDate.HasValue)
            {
                lblDate.Text = orderDTO.OrderDate.Value.ToString("dd-MM-yyyy");
            }
            else
            {
                lblDate.Text = "";
            }

            RenderTable();
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                orderDTO.CustomerID = cmbCustomer.SelectedValue.ToString();
                orderDTO.EmployeeID = int.Parse(cmbEmployee.SelectedValue.ToString());
                orderDTO.ShipVia = int.Parse(cmbShipper.SelectedValue.ToString());

                if (string.IsNullOrEmpty(orderDTO.CustomerID) || orderDTO.EmployeeID == 0 || orderDTO.ShipVia == 0)
                {
                    MessageBox.Show("Molimo popunite sve potrebne podatke!");
                    return;
                }

                orderBL.Save(orderDTO);
                RenderTable();

                MessageBox.Show("Narudžbina je uspešno ažurirana!");
            }
            catch (Exception err)
            {
                MessageBox.Show("Došlo je do greške prilikom ažuriranja narudžbine: \r\n\r\n" + err.Message);
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
            if (dataGrid.SelectedRows.Count > 0)
            {
                var selectedRow = dataGrid.SelectedRows[0];

                var oldProductId = int.Parse(selectedRow.Cells["ProductID"].Value.ToString());
                var newProductId = int.Parse(cmbProduct.SelectedValue.ToString());
                var quantity = txtQuantity.Text;
                var unitPrice = txtPrice.Text;
                var discount = txtDiscount.Text;

                if (string.IsNullOrEmpty(quantity) || string.IsNullOrEmpty(unitPrice) || string.IsNullOrEmpty(discount))
                {
                    MessageBox.Show("Sva polja su obavezna!");
                    return;
                }

                try
                {
                    detailsDTO.OrderID = orderID;
                    detailsDTO.Quantity = short.Parse(quantity);
                    detailsDTO.UnitPrice = decimal.Parse(unitPrice);
                    detailsDTO.Discount = float.Parse(discount);

                    if (oldProductId != newProductId)
                    {
                        orderDetailsBL.UpdateProduct(orderID, oldProductId, newProductId);
                    }
                    else
                    {
                        detailsDTO.ProductID = oldProductId;
                        orderDetailsBL.Save(detailsDTO);
                    }

                    MessageBox.Show("Stavka je uspešno ažurirana!");
                    dataGrid.Refresh();
                    RenderTable();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Greška: \r\n\r\n" + err.Message);
                }
            }
            else
            {
                MessageBox.Show("Nijedna stavka nije izabrana!");
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
