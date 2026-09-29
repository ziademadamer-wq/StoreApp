using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Store_Windows
{
    public partial class ItemsList : Form
    {
        public ItemsList()
        {
            InitializeComponent();
          
        }

        private async void ItemsList_Load(object sender, EventArgs e)
        {
            dgv.DataSource = await MainClass.itemBL.GetData();
        }
    }
}
