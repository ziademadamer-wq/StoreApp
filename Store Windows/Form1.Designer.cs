namespace Store_Windows
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            itemsToolStripMenuItem = new ToolStripMenuItem();
            listToolStripMenuItem = new ToolStripMenuItem();
            addNewItemToolStripMenuItem = new ToolStripMenuItem();
            getItemByIdToolStripMenuItem = new ToolStripMenuItem();
            updateItemToolStripMenuItem = new ToolStripMenuItem();
            deleteItemToolStripMenuItem = new ToolStripMenuItem();
            customersToolStripMenuItem = new ToolStripMenuItem();
            addNewCustomerToolStripMenuItem = new ToolStripMenuItem();
            getCustomerByIdToolStripMenuItem = new ToolStripMenuItem();
            updateCustomerToolStripMenuItem = new ToolStripMenuItem();
            deleteCustomerToolStripMenuItem = new ToolStripMenuItem();
            ordersToolStripMenuItem = new ToolStripMenuItem();
            addNewOrderToolStripMenuItem = new ToolStripMenuItem();
            getOrderByIdToolStripMenuItem = new ToolStripMenuItem();
            updateOrderToolStripMenuItem = new ToolStripMenuItem();
            deleteOrdToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            salesByCustomerToolStripMenuItem = new ToolStripMenuItem();
            salesByItemToolStripMenuItem = new ToolStripMenuItem();
            topCustomersToolStripMenuItem = new ToolStripMenuItem();
            topItemsToolStripMenuItem = new ToolStripMenuItem();
            totalSalesSummaryToolStripMenuItem = new ToolStripMenuItem();
            listToolStripMenuItem1 = new ToolStripMenuItem();
            listToolStripMenuItem2 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.RosyBrown;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { itemsToolStripMenuItem, customersToolStripMenuItem, ordersToolStripMenuItem, reportsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // itemsToolStripMenuItem
            // 
            itemsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listToolStripMenuItem, addNewItemToolStripMenuItem, getItemByIdToolStripMenuItem, updateItemToolStripMenuItem, deleteItemToolStripMenuItem });
            itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            itemsToolStripMenuItem.Size = new Size(59, 24);
            itemsToolStripMenuItem.Text = "Items";
            // 
            // listToolStripMenuItem
            // 
            listToolStripMenuItem.Name = "listToolStripMenuItem";
            listToolStripMenuItem.Size = new Size(224, 26);
            listToolStripMenuItem.Text = "List";
            listToolStripMenuItem.Click += listToolStripMenuItem_Click;
            // 
            // addNewItemToolStripMenuItem
            // 
            addNewItemToolStripMenuItem.Name = "addNewItemToolStripMenuItem";
            addNewItemToolStripMenuItem.Size = new Size(224, 26);
            addNewItemToolStripMenuItem.Text = "Add New Item";
            addNewItemToolStripMenuItem.Click += addNewItemToolStripMenuItem_Click;
            // 
            // getItemByIdToolStripMenuItem
            // 
            getItemByIdToolStripMenuItem.Name = "getItemByIdToolStripMenuItem";
            getItemByIdToolStripMenuItem.Size = new Size(224, 26);
            getItemByIdToolStripMenuItem.Text = "Get Item By Id";
            // 
            // updateItemToolStripMenuItem
            // 
            updateItemToolStripMenuItem.Name = "updateItemToolStripMenuItem";
            updateItemToolStripMenuItem.Size = new Size(224, 26);
            updateItemToolStripMenuItem.Text = "Update Item";
            // 
            // deleteItemToolStripMenuItem
            // 
            deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            deleteItemToolStripMenuItem.Size = new Size(224, 26);
            deleteItemToolStripMenuItem.Text = "Delete Item";
            // 
            // customersToolStripMenuItem
            // 
            customersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listToolStripMenuItem1, addNewCustomerToolStripMenuItem, getCustomerByIdToolStripMenuItem, updateCustomerToolStripMenuItem, deleteCustomerToolStripMenuItem });
            customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            customersToolStripMenuItem.Size = new Size(92, 24);
            customersToolStripMenuItem.Text = "Customers";
            customersToolStripMenuItem.Click += customersToolStripMenuItem_Click;
            // 
            // addNewCustomerToolStripMenuItem
            // 
            addNewCustomerToolStripMenuItem.Name = "addNewCustomerToolStripMenuItem";
            addNewCustomerToolStripMenuItem.Size = new Size(221, 26);
            addNewCustomerToolStripMenuItem.Text = "Add New Customer";
            // 
            // getCustomerByIdToolStripMenuItem
            // 
            getCustomerByIdToolStripMenuItem.Name = "getCustomerByIdToolStripMenuItem";
            getCustomerByIdToolStripMenuItem.Size = new Size(221, 26);
            getCustomerByIdToolStripMenuItem.Text = "Get Customer By Id";
            // 
            // updateCustomerToolStripMenuItem
            // 
            updateCustomerToolStripMenuItem.Name = "updateCustomerToolStripMenuItem";
            updateCustomerToolStripMenuItem.Size = new Size(221, 26);
            updateCustomerToolStripMenuItem.Text = "Update Customer";
            // 
            // deleteCustomerToolStripMenuItem
            // 
            deleteCustomerToolStripMenuItem.Name = "deleteCustomerToolStripMenuItem";
            deleteCustomerToolStripMenuItem.Size = new Size(221, 26);
            deleteCustomerToolStripMenuItem.Text = "Delete Customer";
            // 
            // ordersToolStripMenuItem
            // 
            ordersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listToolStripMenuItem2, addNewOrderToolStripMenuItem, getOrderByIdToolStripMenuItem, updateOrderToolStripMenuItem, deleteOrdToolStripMenuItem });
            ordersToolStripMenuItem.Name = "ordersToolStripMenuItem";
            ordersToolStripMenuItem.Size = new Size(67, 24);
            ordersToolStripMenuItem.Text = "Orders";
            ordersToolStripMenuItem.Click += ordersToolStripMenuItem_Click;
            // 
            // addNewOrderToolStripMenuItem
            // 
            addNewOrderToolStripMenuItem.Name = "addNewOrderToolStripMenuItem";
            addNewOrderToolStripMenuItem.Size = new Size(196, 26);
            addNewOrderToolStripMenuItem.Text = "Add New Order";
            // 
            // getOrderByIdToolStripMenuItem
            // 
            getOrderByIdToolStripMenuItem.Name = "getOrderByIdToolStripMenuItem";
            getOrderByIdToolStripMenuItem.Size = new Size(196, 26);
            getOrderByIdToolStripMenuItem.Text = "Get Order By Id";
            // 
            // updateOrderToolStripMenuItem
            // 
            updateOrderToolStripMenuItem.Name = "updateOrderToolStripMenuItem";
            updateOrderToolStripMenuItem.Size = new Size(196, 26);
            updateOrderToolStripMenuItem.Text = "Update Order";
            // 
            // deleteOrdToolStripMenuItem
            // 
            deleteOrdToolStripMenuItem.Name = "deleteOrdToolStripMenuItem";
            deleteOrdToolStripMenuItem.Size = new Size(196, 26);
            deleteOrdToolStripMenuItem.Text = "Delete Order";
            deleteOrdToolStripMenuItem.Click += deleteOrdToolStripMenuItem_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salesByCustomerToolStripMenuItem, salesByItemToolStripMenuItem, topCustomersToolStripMenuItem, topItemsToolStripMenuItem, totalSalesSummaryToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(74, 24);
            reportsToolStripMenuItem.Text = "Reports";
            // 
            // salesByCustomerToolStripMenuItem
            // 
            salesByCustomerToolStripMenuItem.Name = "salesByCustomerToolStripMenuItem";
            salesByCustomerToolStripMenuItem.Size = new Size(229, 26);
            salesByCustomerToolStripMenuItem.Text = "Sales By Customer";
            // 
            // salesByItemToolStripMenuItem
            // 
            salesByItemToolStripMenuItem.Name = "salesByItemToolStripMenuItem";
            salesByItemToolStripMenuItem.Size = new Size(229, 26);
            salesByItemToolStripMenuItem.Text = "Sales By Item";
            // 
            // topCustomersToolStripMenuItem
            // 
            topCustomersToolStripMenuItem.Name = "topCustomersToolStripMenuItem";
            topCustomersToolStripMenuItem.Size = new Size(229, 26);
            topCustomersToolStripMenuItem.Text = "Top Customers";
            // 
            // topItemsToolStripMenuItem
            // 
            topItemsToolStripMenuItem.Name = "topItemsToolStripMenuItem";
            topItemsToolStripMenuItem.Size = new Size(229, 26);
            topItemsToolStripMenuItem.Text = "Top Items";
            // 
            // totalSalesSummaryToolStripMenuItem
            // 
            totalSalesSummaryToolStripMenuItem.Name = "totalSalesSummaryToolStripMenuItem";
            totalSalesSummaryToolStripMenuItem.Size = new Size(229, 26);
            totalSalesSummaryToolStripMenuItem.Text = "Total Sales Summary";
            // 
            // listToolStripMenuItem1
            // 
            listToolStripMenuItem1.Name = "listToolStripMenuItem1";
            listToolStripMenuItem1.Size = new Size(221, 26);
            listToolStripMenuItem1.Text = "List";
            // 
            // listToolStripMenuItem2
            // 
            listToolStripMenuItem2.Name = "listToolStripMenuItem2";
            listToolStripMenuItem2.Size = new Size(196, 26);
            listToolStripMenuItem2.Text = "List";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem itemsToolStripMenuItem;
        private ToolStripMenuItem addNewItemToolStripMenuItem;
        private ToolStripMenuItem getItemByIdToolStripMenuItem;
        private ToolStripMenuItem updateItemToolStripMenuItem;
        private ToolStripMenuItem deleteItemToolStripMenuItem;
        private ToolStripMenuItem customersToolStripMenuItem;
        private ToolStripMenuItem ordersToolStripMenuItem;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem addNewCustomerToolStripMenuItem;
        private ToolStripMenuItem getCustomerByIdToolStripMenuItem;
        private ToolStripMenuItem updateCustomerToolStripMenuItem;
        private ToolStripMenuItem deleteCustomerToolStripMenuItem;
        private ToolStripMenuItem addNewOrderToolStripMenuItem;
        private ToolStripMenuItem getOrderByIdToolStripMenuItem;
        private ToolStripMenuItem updateOrderToolStripMenuItem;
        private ToolStripMenuItem deleteOrdToolStripMenuItem;
        private ToolStripMenuItem salesByCustomerToolStripMenuItem;
        private ToolStripMenuItem salesByItemToolStripMenuItem;
        private ToolStripMenuItem topCustomersToolStripMenuItem;
        private ToolStripMenuItem topItemsToolStripMenuItem;
        private ToolStripMenuItem totalSalesSummaryToolStripMenuItem;
        private ToolStripMenuItem listToolStripMenuItem;
        private ToolStripMenuItem listToolStripMenuItem1;
        private ToolStripMenuItem listToolStripMenuItem2;
    }
}
