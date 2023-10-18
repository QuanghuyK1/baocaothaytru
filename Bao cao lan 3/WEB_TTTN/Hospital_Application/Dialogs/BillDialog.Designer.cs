namespace Hospital_Application.Dialogs
{
    partial class BillDialog
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
            cancel = new Button();
            ins = new Button();
            update = new Button();
            accept = new Button();
            medicine = new ComboBox();
            label8 = new Label();
            count = new TextBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            price = new TextBox();
            label2 = new Label();
            printbill = new Button();
            del = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, medname, medprice, medcount, medtotalprice, status });
            dataGridView1.Location = new Point(12, 207);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(776, 231);
            dataGridView1.TabIndex = 0;
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
            // cancel
            // 
            cancel.BackColor = Color.DarkGray;
            cancel.Location = new Point(656, 124);
            cancel.Name = "cancel";
            cancel.Size = new Size(121, 36);
            cancel.TabIndex = 26;
            cancel.Text = "Hủy";
            cancel.UseVisualStyleBackColor = false;
            cancel.Visible = false;
            cancel.Click += cancel_Click;
            // 
            // ins
            // 
            ins.BackColor = Color.DarkTurquoise;
            ins.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ins.ForeColor = SystemColors.ButtonHighlight;
            ins.Location = new Point(514, 60);
            ins.Name = "ins";
            ins.Size = new Size(121, 36);
            ins.TabIndex = 25;
            ins.Text = "Thêm";
            ins.UseVisualStyleBackColor = false;
            ins.Click += ins_Click;
            // 
            // update
            // 
            update.BackColor = Color.DarkTurquoise;
            update.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            update.ForeColor = SystemColors.ButtonHighlight;
            update.Location = new Point(514, 102);
            update.Name = "update";
            update.Size = new Size(121, 36);
            update.TabIndex = 24;
            update.Text = "Sửa";
            update.UseVisualStyleBackColor = false;
            update.Visible = false;
            update.Click += update_Click;
            // 
            // accept
            // 
            accept.BackColor = Color.Lime;
            accept.ForeColor = SystemColors.ActiveCaptionText;
            accept.Location = new Point(656, 82);
            accept.Name = "accept";
            accept.Size = new Size(121, 36);
            accept.TabIndex = 23;
            accept.Text = "Đồng ý";
            accept.UseVisualStyleBackColor = false;
            accept.Visible = false;
            accept.Click += accept_Click;
            // 
            // medicine
            // 
            medicine.FormattingEnabled = true;
            medicine.Location = new Point(137, 62);
            medicine.Name = "medicine";
            medicine.Size = new Size(165, 28);
            medicine.TabIndex = 57;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(26, 60);
            label8.Name = "label8";
            label8.Size = new Size(85, 23);
            label8.TabIndex = 56;
            label8.Text = "Tên thuốc";
            // 
            // count
            // 
            count.Location = new Point(207, 111);
            count.Name = "count";
            count.ReadOnly = true;
            count.Size = new Size(95, 27);
            count.TabIndex = 59;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 114);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 58;
            label1.Text = "Số lượng";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(345, 50);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(144, 126);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 60;
            pictureBox1.TabStop = false;
            // 
            // price
            // 
            price.Location = new Point(154, 153);
            price.Name = "price";
            price.ReadOnly = true;
            price.Size = new Size(152, 27);
            price.TabIndex = 62;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 156);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 61;
            label2.Text = "Giá";
            // 
            // printbill
            // 
            printbill.BackColor = Color.DarkTurquoise;
            printbill.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            printbill.ForeColor = SystemColors.ButtonHighlight;
            printbill.Location = new Point(514, 6);
            printbill.Name = "printbill";
            printbill.Size = new Size(263, 36);
            printbill.TabIndex = 63;
            printbill.Text = "Xuất hóa đơn";
            printbill.UseVisualStyleBackColor = false;
            printbill.Click += printbill_Click;
            // 
            // del
            // 
            del.BackColor = Color.DarkTurquoise;
            del.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            del.ForeColor = SystemColors.ButtonHighlight;
            del.Location = new Point(514, 147);
            del.Name = "del";
            del.Size = new Size(121, 36);
            del.TabIndex = 64;
            del.Text = "Xóa";
            del.UseVisualStyleBackColor = false;
            del.Visible = false;
            del.Click += del_Click;
            // 
            // BillDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(800, 450);
            Controls.Add(del);
            Controls.Add(printbill);
            Controls.Add(price);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(count);
            Controls.Add(label1);
            Controls.Add(medicine);
            Controls.Add(label8);
            Controls.Add(cancel);
            Controls.Add(ins);
            Controls.Add(update);
            Controls.Add(accept);
            Controls.Add(dataGridView1);
            Name = "BillDialog";
            Text = "BillDialog";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button cancel;
        private Button ins;
        private Button update;
        private Button accept;
        private ComboBox medicine;
        private Label label8;
        private TextBox count;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox price;
        private Label label2;
        private Button printbill;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn medname;
        private DataGridViewTextBoxColumn medprice;
        private DataGridViewTextBoxColumn medcount;
        private DataGridViewTextBoxColumn medtotalprice;
        private DataGridViewTextBoxColumn status;
        private Button del;
    }
}