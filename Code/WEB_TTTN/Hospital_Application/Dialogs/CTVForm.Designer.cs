namespace Hospital_Application.Dialogs
{
    partial class CTVForm
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
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            medname = new DataGridViewTextBoxColumn();
            medprice = new DataGridViewTextBoxColumn();
            medcount = new DataGridViewTextBoxColumn();
            medtotalprice = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            billcode = new TextBox();
            label1 = new Label();
            del = new Button();
            accept = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, medname, medprice, medcount, medtotalprice, status });
            dataGridView1.Location = new Point(12, 171);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(776, 267);
            dataGridView1.TabIndex = 1;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 60;
            // 
            // medname
            // 
            medname.HeaderText = "Medicine Name";
            medname.MinimumWidth = 6;
            medname.Name = "medname";
            medname.ReadOnly = true;
            medname.Width = 180;
            // 
            // medprice
            // 
            medprice.HeaderText = "Price";
            medprice.MinimumWidth = 6;
            medprice.Name = "medprice";
            medprice.ReadOnly = true;
            medprice.Width = 140;
            // 
            // medcount
            // 
            medcount.HeaderText = "Count";
            medcount.MinimumWidth = 6;
            medcount.Name = "medcount";
            medcount.ReadOnly = true;
            medcount.Width = 60;
            // 
            // medtotalprice
            // 
            medtotalprice.HeaderText = "Totalprice";
            medtotalprice.MinimumWidth = 6;
            medtotalprice.Name = "medtotalprice";
            medtotalprice.ReadOnly = true;
            medtotalprice.Width = 158;
            // 
            // status
            // 
            status.HeaderText = "Status";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.ReadOnly = true;
            status.Width = 125;
            // 
            // billcode
            // 
            billcode.Location = new Point(187, 39);
            billcode.Name = "billcode";
            billcode.Size = new Size(250, 27);
            billcode.TabIndex = 37;
            billcode.TextChanged += billcode_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(29, 39);
            label1.Name = "label1";
            label1.Size = new Size(130, 25);
            label1.TabIndex = 36;
            label1.Text = "Mã đơn thuốc";
            label1.Click += label1_Click;
            // 
            // del
            // 
            del.BackColor = Color.DarkTurquoise;
            del.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            del.ForeColor = Color.White;
            del.ImageAlign = ContentAlignment.TopLeft;
            del.Location = new Point(29, 91);
            del.Name = "del";
            del.Size = new Size(214, 56);
            del.TabIndex = 58;
            del.Text = "Tìm kiếm";
            del.UseVisualStyleBackColor = false;
            del.Click += del_Click;
            // 
            // accept
            // 
            accept.BackColor = Color.DarkTurquoise;
            accept.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            accept.ForeColor = Color.White;
            accept.ImageAlign = ContentAlignment.TopLeft;
            accept.Location = new Point(539, 91);
            accept.Name = "accept";
            accept.Size = new Size(214, 56);
            accept.TabIndex = 60;
            accept.Text = "Xác nhận thanh toán";
            accept.UseVisualStyleBackColor = false;
            accept.Click += accept_Click;
            // 
            // button7
            // 
            button7.Location = new Point(292, 91);
            button7.Name = "button7";
            button7.Size = new Size(186, 56);
            button7.TabIndex = 61;
            button7.Text = "logout";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // CTVForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(800, 450);
            Controls.Add(button7);
            Controls.Add(accept);
            Controls.Add(del);
            Controls.Add(billcode);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "CTVForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn medname;
        private DataGridViewTextBoxColumn medprice;
        private DataGridViewTextBoxColumn medcount;
        private DataGridViewTextBoxColumn medtotalprice;
        private DataGridViewTextBoxColumn status;
        private TextBox billcode;
        private Label label1;
        private Button del;
        private Button accept;
        private Button button7;
    }
}