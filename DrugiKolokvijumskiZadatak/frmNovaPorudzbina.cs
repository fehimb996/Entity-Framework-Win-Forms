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
    public partial class frmPorudzbina : Form
    {
        OrderDTO oDTO = new OrderDTO();
        List<OrderDetailsDTO> odDTOList = new List<OrderDetailsDTO>();
        OrderBL orderBL;
        ProductBL productBL;
        CustomerBL customerBL;
        EmployeeBL employeeBL;
        ShipperBL shipperBL;

        public frmPorudzbina()
        {
            InitializeComponent();
            orderBL = new OrderBL();
            productBL = new ProductBL();
            customerBL = new CustomerBL();
            employeeBL = new EmployeeBL();
            shipperBL = new ShipperBL();
            btnDodajStavku.Enabled = false;
            btnSacuvaj.Enabled = false;
        }

        private void btnKreirajOrder_Click(object sender, EventArgs e)
        {
            oDTO.OrderDate = DateTime.Parse(lblDate.Text);
            oDTO.EmployeeID = (Int32)cmbEmployee.SelectedValue;
            oDTO.ShipVia = (Int32)cmbShipper.SelectedValue;
            oDTO.CustomerID = cmbCustomer.SelectedValue.ToString();

            btnDodajStavku.Enabled = true;
            cmbProduct.Enabled = true;
            txtDiscount.Enabled = true;
            txtPrice.Enabled = true;
            txtQuantity.Enabled = true;
        }

        private void btnDodajStavku_Click(object sender, EventArgs e)
        {
            OrderDetailsDTO odDTO = new OrderDetailsDTO();
            odDTO.ProductID = (int)cmbProduct.SelectedValue;
            odDTO.UnitPrice = Convert.ToDecimal(txtPrice.Text);
            odDTO.Quantity = Convert.ToInt16(txtQuantity.Text);
            odDTO.Discount = Convert.ToSingle(txtDiscount.Text);

            odDTOList.Add(odDTO);

            dgvOrderDetails.DataSource = null;
            dgvOrderDetails.DataSource = odDTOList;

            txtDiscount.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";

            if (odDTOList.Count > 0)
            {
                btnSacuvaj.Enabled = true;
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (odDTOList.Count == 0)
            {
                MessageBox.Show("Morate dodati barem jednu stavku pre nego što sačuvate porudžbinu.");
                return;
            }

            OrderBL oBL = new OrderBL();
            OrderDetailsBL odBL = new OrderDetailsBL();

            try
            {
                int OrderID = oBL.Insert(oDTO);
                foreach (OrderDetailsDTO odDTP in odDTOList)
                {
                    odDTP.OrderID = OrderID;
                    odBL.Insert(odDTP);
                }

                oDTO = new OrderDTO();
                odDTOList = new List<OrderDetailsDTO>();
                dgvOrderDetails.DataSource = null;

                txtDiscount.Text = "";
                txtPrice.Text = "";
                txtQuantity.Text = "";
                cmbProduct.Enabled = false;
                txtDiscount.Enabled = false;
                txtPrice.Enabled = false;
                txtQuantity.Enabled = false;
                btnSacuvaj.Enabled = false;
                btnDodajStavku.Enabled = false;

                MessageBox.Show("Porudzbina je uspesno sacuvana!");
            }
            catch (Exception ex)
            {
                odBL.Delete(oDTO.OrderID);
                oBL.Delete(oDTO.OrderID);

                MessageBox.Show("Greska:\r\n\r\n" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPorudzbina_Load(object sender, EventArgs e)
        {
            cmbEmployee.DataSource = employeeBL.GetEmployees();
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "EmployeeID";

            cmbShipper.DataSource = shipperBL.GetShippers();
            cmbShipper.DisplayMember = "CompanyName";
            cmbShipper.ValueMember = "ShipperID";

            cmbCustomer.DataSource = customerBL.GetCustomers();
            cmbCustomer.DisplayMember = "CompanyName";
            cmbCustomer.ValueMember = "CustomerID";

            cmbProduct.DataSource = productBL.GetProducts();
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";

            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");

            txtDiscount.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            cmbProduct.Enabled = false;
            txtDiscount.Enabled = false;
            txtPrice.Enabled = false;
            txtQuantity.Enabled = false;
        }

        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbShppers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
