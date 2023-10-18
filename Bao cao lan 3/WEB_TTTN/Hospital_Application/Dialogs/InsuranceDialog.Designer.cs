namespace Hospital_Application.Dialogs
{
    partial class InsuranceDialog
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
            InsuranceID = new DataGridViewTextBoxColumn();
            HospitalName = new DataGridViewTextBoxColumn();
            Firstname = new DataGridViewTextBoxColumn();
            Lastname = new DataGridViewTextBoxColumn();
            Usedate = new DataGridViewTextBoxColumn();
            Birthday = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            label1 = new Label();
            id = new TextBox();
            hosname = new TextBox();
            label2 = new Label();
            label3 = new Label();
            nametext1 = new TextBox();
            label4 = new Label();
            nametext2 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ngaytao = new TextBox();
            btnshow = new Button();
            btnActive = new Button();
            btnIns = new Button();
            ngaysinh = new DateTimePicker();
            hansd = new DateTimePicker();
            trangthai = new TextBox();
            Cancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { InsuranceID, HospitalName, Firstname, Lastname, Usedate, Birthday, Status });
            dataGridView1.Location = new Point(17, 270);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(905, 278);
            dataGridView1.TabIndex = 34;
            // 
            // InsuranceID
            // 
            InsuranceID.HeaderText = "InsuranceID";
            InsuranceID.MinimumWidth = 6;
            InsuranceID.Name = "InsuranceID";
            InsuranceID.ReadOnly = true;
            InsuranceID.Width = 140;
            // 
            // HospitalName
            // 
            HospitalName.HeaderText = "HospitalName";
            HospitalName.MinimumWidth = 6;
            HospitalName.Name = "HospitalName";
            HospitalName.ReadOnly = true;
            HospitalName.Width = 140;
            // 
            // Firstname
            // 
            Firstname.HeaderText = "Firstname";
            Firstname.MinimumWidth = 6;
            Firstname.Name = "Firstname";
            Firstname.ReadOnly = true;
            Firstname.Width = 120;
            // 
            // Lastname
            // 
            Lastname.HeaderText = "Lastname";
            Lastname.MinimumWidth = 6;
            Lastname.Name = "Lastname";
            Lastname.ReadOnly = true;
            Lastname.Resizable = DataGridViewTriState.True;
            Lastname.SortMode = DataGridViewColumnSortMode.NotSortable;
            Lastname.Width = 120;
            // 
            // Usedate
            // 
            Usedate.HeaderText = "Usedate";
            Usedate.MinimumWidth = 6;
            Usedate.Name = "Usedate";
            Usedate.ReadOnly = true;
            Usedate.Width = 125;
            // 
            // Birthday
            // 
            Birthday.HeaderText = "Birthday";
            Birthday.MinimumWidth = 6;
            Birthday.Name = "Birthday";
            Birthday.ReadOnly = true;
            Birthday.Width = 125;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(348, 82);
            label1.Name = "label1";
            label1.Size = new Size(101, 23);
            label1.TabIndex = 35;
            label1.Text = "InsuranceID";
            // 
            // id
            // 
            id.Location = new Point(470, 82);
            id.Name = "id";
            id.ReadOnly = true;
            id.Size = new Size(180, 27);
            id.TabIndex = 36;
            id.TextChanged += textBox1_TextChanged;
            // 
            // hosname
            // 
            hosname.Location = new Point(472, 139);
            hosname.Name = "hosname";
            hosname.ReadOnly = true;
            hosname.Size = new Size(178, 27);
            hosname.TabIndex = 38;
            hosname.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(348, 140);
            label2.Name = "label2";
            label2.Size = new Size(118, 23);
            label2.TabIndex = 37;
            label2.Text = "HospitalName";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(348, 198);
            label3.Name = "label3";
            label3.Size = new Size(72, 23);
            label3.TabIndex = 39;
            label3.Text = "Usedate";
            // 
            // nametext1
            // 
            nametext1.Location = new Point(125, 83);
            nametext1.Name = "nametext1";
            nametext1.ReadOnly = true;
            nametext1.Size = new Size(178, 27);
            nametext1.TabIndex = 42;
            nametext1.TextChanged += textBox4_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(32, 84);
            label4.Name = "label4";
            label4.Size = new Size(87, 23);
            label4.TabIndex = 41;
            label4.Text = "FirstName";
            label4.Click += label4_Click;
            // 
            // nametext2
            // 
            nametext2.Location = new Point(125, 138);
            nametext2.Name = "nametext2";
            nametext2.ReadOnly = true;
            nametext2.Size = new Size(178, 27);
            nametext2.TabIndex = 44;
            nametext2.TextChanged += textBox5_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(32, 139);
            label5.Name = "label5";
            label5.Size = new Size(86, 23);
            label5.TabIndex = 43;
            label5.Text = "LastName";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(32, 204);
            label6.Name = "label6";
            label6.Size = new Size(73, 23);
            label6.TabIndex = 45;
            label6.Text = "Birthday";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(722, 69);
            label7.Name = "label7";
            label7.Size = new Size(56, 23);
            label7.TabIndex = 48;
            label7.Text = "Status";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(722, 150);
            label8.Name = "label8";
            label8.Size = new Size(87, 23);
            label8.TabIndex = 50;
            label8.Text = "Createday";
            label8.Click += label8_Click;
            // 
            // ngaytao
            // 
            ngaytao.Location = new Point(722, 187);
            ngaytao.Name = "ngaytao";
            ngaytao.ReadOnly = true;
            ngaytao.Size = new Size(193, 27);
            ngaytao.TabIndex = 51;
            // 
            // btnshow
            // 
            btnshow.BackColor = Color.DarkTurquoise;
            btnshow.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnshow.ForeColor = SystemColors.ButtonHighlight;
            btnshow.Location = new Point(722, 12);
            btnshow.Name = "btnshow";
            btnshow.Size = new Size(167, 41);
            btnshow.TabIndex = 54;
            btnshow.Text = "Xem Ảnh";
            btnshow.UseVisualStyleBackColor = false;
            btnshow.Visible = false;
            btnshow.Click += btnshow_Click;
            // 
            // btnActive
            // 
            btnActive.BackColor = Color.DarkTurquoise;
            btnActive.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnActive.ForeColor = SystemColors.ButtonHighlight;
            btnActive.Location = new Point(472, 12);
            btnActive.Name = "btnActive";
            btnActive.Size = new Size(167, 42);
            btnActive.TabIndex = 53;
            btnActive.Text = "Active";
            btnActive.UseVisualStyleBackColor = false;
            btnActive.Visible = false;
            btnActive.Click += btnActive_Click;
            // 
            // btnIns
            // 
            btnIns.BackColor = Color.DarkTurquoise;
            btnIns.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnIns.ForeColor = SystemColors.ButtonHighlight;
            btnIns.Location = new Point(27, 12);
            btnIns.Name = "btnIns";
            btnIns.Size = new Size(167, 41);
            btnIns.TabIndex = 52;
            btnIns.Text = "Thêm";
            btnIns.UseVisualStyleBackColor = false;
            btnIns.Click += btnIns_Click;
            // 
            // ngaysinh
            // 
            ngaysinh.CalendarFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ngaysinh.CustomFormat = "dd/MM/yyyy";
            ngaysinh.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            ngaysinh.Format = DateTimePickerFormat.Custom;
            ngaysinh.Location = new Point(125, 196);
            ngaysinh.Name = "ngaysinh";
            ngaysinh.Size = new Size(178, 32);
            ngaysinh.TabIndex = 55;
            ngaysinh.Value = new DateTime(2023, 8, 1, 0, 0, 0, 0);
            // 
            // hansd
            // 
            hansd.CalendarFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            hansd.CustomFormat = "dd/MM/yyyy";
            hansd.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            hansd.Format = DateTimePickerFormat.Custom;
            hansd.Location = new Point(472, 198);
            hansd.Name = "hansd";
            hansd.Size = new Size(178, 32);
            hansd.TabIndex = 56;
            hansd.Value = new DateTime(2023, 8, 1, 0, 0, 0, 0);
            // 
            // trangthai
            // 
            trangthai.Location = new Point(722, 104);
            trangthai.Name = "trangthai";
            trangthai.ReadOnly = true;
            trangthai.Size = new Size(193, 27);
            trangthai.TabIndex = 57;
            // 
            // Cancel
            // 
            Cancel.BackColor = Color.Gray;
            Cancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Cancel.ForeColor = SystemColors.ButtonHighlight;
            Cancel.Location = new Point(232, 12);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(167, 42);
            Cancel.TabIndex = 58;
            Cancel.Text = "Hủy";
            Cancel.UseVisualStyleBackColor = false;
            Cancel.Visible = false;
            Cancel.Click += Cancel_Click;
            // 
            // InsuranceDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(954, 560);
            Controls.Add(Cancel);
            Controls.Add(trangthai);
            Controls.Add(hansd);
            Controls.Add(ngaysinh);
            Controls.Add(btnshow);
            Controls.Add(btnActive);
            Controls.Add(btnIns);
            Controls.Add(ngaytao);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(nametext2);
            Controls.Add(label5);
            Controls.Add(nametext1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(hosname);
            Controls.Add(label2);
            Controls.Add(id);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "InsuranceDialog";
            Text = "InsuranceDialog";
            Load += InsuranceDialog_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn InsuranceID;
        private DataGridViewTextBoxColumn HospitalName;
        private DataGridViewTextBoxColumn Firstname;
        private DataGridViewTextBoxColumn Lastname;
        private DataGridViewTextBoxColumn Usedate;
        private DataGridViewTextBoxColumn Birthday;
        private DataGridViewTextBoxColumn Status;
        private Label label1;
        private TextBox id;
        private TextBox hosname;
        private Label label2;
        private Label label3;
        private TextBox nametext1;
        private Label label4;
        private TextBox nametext2;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox ngaytao;
        private Button btnshow;
        private Button btnActive;
        private Button btnIns;
        private DateTimePicker ngaysinh;
        private DateTimePicker hansd;
        private TextBox trangthai;
        private Button Cancel;
    }
}