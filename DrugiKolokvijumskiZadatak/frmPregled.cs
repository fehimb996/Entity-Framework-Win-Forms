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
    public partial class frmPregled : Form
    {
        int orderID;
        OrderDTO orderDTO;
        OrderDetailsBL orderDetailsBL;
        ProductBL productBL;
        CustomerBL customerBL;
        EmployeeBL employeeBL;
        ShipperBL shipperBL;

        public frmPregled(int orderId)
        {
            InitializeComponent();
            orderID = orderId;
            orderDetailsBL = new OrderDetailsBL();
            productBL = new ProductBL();
            customerBL = new CustomerBL();
            employeeBL = new EmployeeBL();
            shipperBL = new ShipperBL();
        }

        public frmPregled()
        {
            InitializeComponent();
        }

        private void frmPregled_Load(object sender, EventArgs e)
        {
            orderDTO = new OrderBL().GetOrder(orderID);
            List<OrderDetailsDTO> orderDetails = orderDetailsBL.GetAllByOrder(orderID);

            dataGridView1.DataSource = orderDetails;

            if (orderDTO.EmployeeID.HasValue)
            {
                EmployeeDTO employee = employeeBL.GetEmployee(orderDTO.EmployeeID.Value);
                txtEmployee.Text = employee.FullName;
            }
            else
            {
                txtEmployee.Text = "";
            }

            if (orderDTO.CustomerID != null)
            {
                CustomerDTO customer = customerBL.GetCustomer(orderDTO.CustomerID);
                txtCustomer.Text = customer.CompanyName;
            }
            else
            {
                txtCustomer.Text = "";
            }

            if (orderDTO.ShipVia.HasValue)
            {
                ShipperDTO shipper = shipperBL.GetShipper(orderDTO.ShipVia.Value);
                txtShipper.Text = shipper.CompanyName;
            }
            else
            {
                txtShipper.Text = "";
            }
            if (orderDTO.OrderDate.HasValue)
            {
                lblDate.Text = orderDTO.OrderDate.Value.ToString("dd-MM-yyyy");
            }
            else
            {
                lblDate.Text = "";
            }

            txtEmployee.ReadOnly = true;
            txtCustomer.ReadOnly = true;
            txtShipper.ReadOnly = true;
            txtProduct.ReadOnly = true;
            txtPrice.ReadOnly = true;
            txtQuantity.ReadOnly = true;
            txtDiscount.ReadOnly = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                var productId = selectedRow.Cells["ProductID"].Value.ToString();
                var quantity = selectedRow.Cells["Quantity"].Value.ToString();
                var unitPrice = selectedRow.Cells["UnitPrice"].Value.ToString();
                var discount = selectedRow.Cells["Discount"].Value.ToString();

                ProductDTO product = productBL.getProduct(int.Parse(productId));

                txtProduct.Text = product.ProductName;
                txtPrice.Text = unitPrice;
                txtQuantity.Text = quantity;
                txtDiscount.Text = discount;
            }
        }
    }
}
