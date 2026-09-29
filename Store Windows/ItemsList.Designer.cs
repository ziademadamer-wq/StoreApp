namespace Store_Windows
{
    partial class ItemsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgv = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 0);
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 51;
            dgv.Size = new Size(794, 367);
            dgv.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Location = new Point(6, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(793, 74);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgv);
            panel2.Location = new Point(5, 83);
            panel2.Name = "panel2";
            panel2.Size = new Size(794, 367);
            panel2.TabIndex = 2;
            // 
            // ItemsList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ItemsList";
            Text = "ItemsList";
            Load += ItemsList_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv;
        private Panel panel1;
        private Panel panel2;
    }
}