namespace Hospital_Application.Dialogs
{
    partial class MedicineDialog
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
            date = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            status = new TextBox();
            label2 = new Label();
            medicinename = new TextBox();
            label1 = new Label();
            credate = new DateTimePicker();
            sl = new TextBox();
            label5 = new Label();
            price = new TextBox();
            label6 = new Label();
            handleprice = new TextBox();
            label7 = new Label();
            label8 = new Label();
            des = new TextBox();
            label9 = new Label();
            nation = new ComboBox();
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            MedName = new DataGridViewTextBoxColumn();
            Count = new DataGridViewTextBoxColumn();
            HSD = new DataGridViewTextBoxColumn();
            MedicinePrice = new DataGridViewTextBoxColumn();
            nationname = new DataGridViewTextBoxColumn();
            TT = new DataGridViewTextBoxColumn();
            ins = new Button();
            cancel = new Button();
            del = new Button();
            update = new Button();
            img = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // date
            // 
            date.CustomFormat = "dd/MM/yyyy";
            date.Format = DateTimePickerFormat.Custom;
            date.Location = new Point(159, 164);
            date.Name = "date";
            date.Size = new Size(250, 27);
            date.TabIndex = 41;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(30, 290);
            label4.Name = "label4";
            label4.Size = new Size(96, 25);
            label4.TabIndex = 40;
            label4.Text = "Trạng thái";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(30, 232);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 38;
            label3.Text = "Ngày nhập";
            // 
            // status
            // 
            status.Location = new Point(159, 288);
            status.Name = "status";
            status.ReadOnly = true;
            status.Size = new Size(250, 27);
            status.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(30, 164);
            label2.Name = "label2";
            label2.Size = new Size(119, 25);
            label2.TabIndex = 36;
            label2.Text = "Hạn sử dụng";
            // 
            // medicinename
            // 
            medicinename.Location = new Point(159, 106);
            medicinename.Name = "medicinename";
            medicinename.ReadOnly = true;
            medicinename.Size = new Size(250, 27);
            medicinename.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(30, 105);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 34;
            label1.Text = "Tên thuốc";
            // 
            // credate
            // 
            credate.CustomFormat = "dd/MM/yyyy";
            credate.Format = DateTimePickerFormat.Custom;
            credate.Location = new Point(159, 232);
            credate.Name = "credate";
            credate.Size = new Size(250, 27);
            credate.TabIndex = 42;
            // 
            // sl
            // 
            sl.Location = new Point(608, 106);
            sl.Name = "sl";
            sl.ReadOnly = true;
            sl.Size = new Size(50, 27);
            sl.TabIndex = 44;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(499, 105);
            label5.Name = "label5";
            label5.Size = new Size(87, 25);
            label5.TabIndex = 43;
            label5.Text = "Số lượng";
            // 
            // price
            // 
            price.Location = new Point(831, 164);
            price.Name = "price";
            price.ReadOnly = true;
            price.Size = new Size(105, 27);
            price.TabIndex = 46;
            price.TextChanged += textBox2_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(748, 163);
            label6.Name = "label6";
            label6.Size = new Size(77, 25);
            label6.TabIndex = 45;
            label6.Text = "Giá tiền";
            // 
            // handleprice
            // 
            handleprice.Location = new Point(608, 166);
            handleprice.Name = "handleprice";
            handleprice.ReadOnly = true;
            handleprice.Size = new Size(113, 27);
            handleprice.TabIndex = 48;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(499, 165);
            label7.Name = "label7";
            label7.Size = new Size(88, 25);
            label7.TabIndex = 47;
            label7.Text = "Giá nhập";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(683, 105);
            label8.Name = "label8";
            label8.Size = new Size(88, 25);
            label8.TabIndex = 49;
            label8.Text = "Quốc gia";
            label8.Click += label8_Click;
            // 
            // des
            // 
            des.Location = new Point(608, 232);
            des.Multiline = true;
            des.Name = "des";
            des.ReadOnly = true;
            des.Size = new Size(328, 83);
            des.TabIndex = 52;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(499, 231);
            label9.Name = "label9";
            label9.Size = new Size(61, 25);
            label9.TabIndex = 51;
            label9.Text = "Mô tả";
            // 
            // nation
            // 
            nation.FormattingEnabled = true;
            nation.Location = new Point(771, 106);
            nation.Name = "nation";
            nation.Size = new Size(165, 28);
            nation.TabIndex = 53;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, MedName, Count, HSD, MedicinePrice, nationname, TT });
            dataGridView1.Location = new Point(30, 346);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(906, 201);
            dataGridView1.TabIndex = 54;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 60;
            // 
            // MedName
            // 
            MedName.HeaderText = "MedName";
            MedName.MinimumWidth = 6;
            MedName.Name = "MedName";
            MedName.ReadOnly = true;
            MedName.Width = 220;
            // 
            // Count
            // 
            Count.HeaderText = "Count";
            Count.MinimumWidth = 6;
            Count.Name = "Count";
            Count.ReadOnly = true;
            Count.Width = 80;
            // 
            // HSD
            // 
            HSD.HeaderText = "Usedate";
            HSD.MinimumWidth = 6;
            HSD.Name = "HSD";
            HSD.ReadOnly = true;
            HSD.Width = 125;
            // 
            // MedicinePrice
            // 
            MedicinePrice.HeaderText = "Price";
            MedicinePrice.MinimumWidth = 6;
            MedicinePrice.Name = "MedicinePrice";
            MedicinePrice.ReadOnly = true;
            MedicinePrice.Width = 125;
            // 
            // nationname
            // 
            nationname.HeaderText = "NationName";
            nationname.MinimumWidth = 6;
            nationname.Name = "nationname";
            nationname.ReadOnly = true;
            nationname.Width = 183;
            // 
            // TT
            // 
            TT.HeaderText = "Status";
            TT.MinimumWidth = 6;
            TT.Name = "TT";
            TT.ReadOnly = true;
            TT.Width = 60;
            // 
            // ins
            // 
            ins.BackColor = Color.DarkTurquoise;
            ins.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ins.ForeColor = Color.White;
            ins.ImageAlign = ContentAlignment.TopLeft;
            ins.Location = new Point(30, 28);
            ins.Name = "ins";
            ins.Size = new Size(134, 56);
            ins.TabIndex = 55;
            ins.Text = "Thêm";
            ins.UseVisualStyleBackColor = false;
            ins.Click += ins_Click;
            // 
            // cancel
            // 
            cancel.BackColor = Color.Gray;
            cancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cancel.ForeColor = Color.White;
            cancel.ImageAlign = ContentAlignment.TopLeft;
            cancel.Location = new Point(194, 28);
            cancel.Name = "cancel";
            cancel.Size = new Size(146, 56);
            cancel.TabIndex = 56;
            cancel.Text = "Hủy";
            cancel.UseVisualStyleBackColor = false;
            cancel.Visible = false;
            cancel.Click += cancel_Click;
            // 
            // del
            // 
            del.BackColor = Color.DarkTurquoise;
            del.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            del.ForeColor = Color.White;
            del.ImageAlign = ContentAlignment.TopLeft;
            del.Location = new Point(384, 28);
            del.Name = "del";
            del.Size = new Size(142, 56);
            del.TabIndex = 57;
            del.Text = "Xóa";
            del.UseVisualStyleBackColor = false;
            del.Visible = false;
            del.Click += del_Click;
            // 
            // update
            // 
            update.BackColor = Color.DarkTurquoise;
            update.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            update.ForeColor = Color.White;
            update.ImageAlign = ContentAlignment.TopLeft;
            update.Location = new Point(562, 28);
            update.Name = "update";
            update.Size = new Size(141, 56);
            update.TabIndex = 58;
            update.Text = "Sửa";
            update.UseVisualStyleBackColor = false;
            update.Visible = false;
            update.Click += update_Click;
            // 
            // img
            // 
            img.BackColor = Color.DarkTurquoise;
            img.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            img.ForeColor = Color.White;
            img.ImageAlign = ContentAlignment.TopLeft;
            img.Location = new Point(737, 28);
            img.Name = "img";
            img.Size = new Size(152, 56);
            img.TabIndex = 59;
            img.Text = "Image";
            img.UseVisualStyleBackColor = false;
            img.Visible = false;
            img.Click += img_Click;
            // 
            // MedicineDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(954, 560);
            Controls.Add(img);
            Controls.Add(update);
            Controls.Add(del);
            Controls.Add(cancel);
            Controls.Add(ins);
            Controls.Add(dataGridView1);
            Controls.Add(nation);
            Controls.Add(des);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(handleprice);
            Controls.Add(label7);
            Controls.Add(price);
            Controls.Add(label6);
            Controls.Add(sl);
            Controls.Add(label5);
            Controls.Add(credate);
            Controls.Add(date);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(status);
            Controls.Add(label2);
            Controls.Add(medicinename);
            Controls.Add(label1);
            Name = "MedicineDialog";
            Text = "Medicine Dialog";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker date;
        private Label label4;
        private Label label3;
        private TextBox status;
        private Label label2;
        private TextBox medicinename;
        private Label label1;
        private DateTimePicker credate;
        private TextBox sl;
        private Label label5;
        private TextBox price;
        private Label label6;
        private TextBox handleprice;
        private Label label7;
        private Label label8;
        private TextBox des;
        private Label label9;
        private ComboBox nation;
        private DataGridView dataGridView1;
        private Button ins;
        private Button cancel;
        private Button del;
        private Button update;
        private Button img;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn MedName;
        private DataGridViewTextBoxColumn Count;
        private DataGridViewTextBoxColumn HSD;
        private DataGridViewTextBoxColumn MedicinePrice;
        private DataGridViewTextBoxColumn nationname;
        private DataGridViewTextBoxColumn TT;
    }
}