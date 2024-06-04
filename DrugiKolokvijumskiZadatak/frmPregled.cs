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
        private int orderID;

        public frmPregled(int orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
        }

        public frmPregled()
        {
            InitializeComponent();
        }

        private void frmPregled_Load(object sender, EventArgs e)
        {
            lblOrderDetails.Text = "Order details for Order: " + orderID.ToString();
        }
    }
}
