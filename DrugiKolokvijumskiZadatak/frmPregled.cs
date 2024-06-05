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
        int orderDetailID;
        OrderDetailsBL orderDetailsBL;
        ProductBL productBL;

        public frmPregled(int orderDetailId)
        {
            InitializeComponent();
            orderDetailID = orderDetailId;
            orderDetailsBL = new OrderDetailsBL();
            productBL = new ProductBL();
        }

        public frmPregled()
        {
            InitializeComponent();
        }

        private void frmPregled_Load(object sender, EventArgs e)
        {
            OrderDetailsDTO orderDetail = new OrderDetailsBL().GetOrderDetail(orderDetailID);
            ProductDTO product = new ProductBL().getProduct(orderDetail.ProductID);
            
            dataGridView1.DataSource = orderDetailsBL.GetAllByOrder(orderDetailID);
        }

        private void frmPregled_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
