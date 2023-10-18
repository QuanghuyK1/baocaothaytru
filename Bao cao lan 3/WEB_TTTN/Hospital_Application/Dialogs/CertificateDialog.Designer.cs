namespace Hospital_Application.Dialogs
{
    partial class CertificateDialog
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
            btnIns = new Button();
            btnUps = new Button();
            btnDel = new Button();
            upimg = new Button();
            datetext = new DateTimePicker();
            birthday = new Label();
            destext = new TextBox();
            Email = new Label();
            nametext = new TextBox();
            name = new Label();
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            CertificateName = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Usedate = new DataGridViewTextBoxColumn();
            Image = new DataGridViewTextBoxColumn();
            cancel = new Button();
            accept = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnIns
            // 
            btnIns.BackColor = Color.DarkTurquoise;
            btnIns.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnIns.ForeColor = SystemColors.ButtonHighlight;
            btnIns.Location = new Point(23, 25);
            btnIns.Name = "btnIns";
            btnIns.Size = new Size(167, 41);
            btnIns.TabIndex = 0;
            btnIns.Text = "Thêm";
            btnIns.UseVisualStyleBackColor = false;
            btnIns.Click += btnIns_Click;
            // 
            // btnUps
            // 
            btnUps.BackColor = Color.DarkTurquoise;
            btnUps.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUps.ForeColor = SystemColors.ButtonHighlight;
            btnUps.Location = new Point(220, 25);
            btnUps.Name = "btnUps";
            btnUps.Size = new Size(167, 42);
            btnUps.TabIndex = 1;
            btnUps.Text = "Sửa";
            btnUps.UseVisualStyleBackColor = false;
            btnUps.Visible = false;
            btnUps.Click += btnUps_Click;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.DarkTurquoise;
            btnDel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDel.ForeColor = SystemColors.ButtonHighlight;
            btnDel.Location = new Point(507, 26);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(167, 41);
            btnDel.TabIndex = 2;
            btnDel.Text = "Xóa";
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Visible = false;
            btnDel.Click += btnDel_Click;
            // 
            // upimg
            // 
            upimg.BackColor = Color.DarkTurquoise;
            upimg.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            upimg.ForeColor = SystemColors.ButtonHighlight;
            upimg.Location = new Point(725, 26);
            upimg.Name = "upimg";
            upimg.Size = new Size(167, 41);
            upimg.TabIndex = 3;
            upimg.Text = "Tải ảnh";
            upimg.UseVisualStyleBackColor = false;
            upimg.Visible = false;
            upimg.Click += up_Click;
            // 
            // datetext
            // 
            datetext.CalendarFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            datetext.CustomFormat = "dd/MM/yyyy";
            datetext.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            datetext.Format = DateTimePickerFormat.Custom;
            datetext.Location = new Point(153, 141);
            datetext.Name = "datetext";
            datetext.Size = new Size(204, 32);
            datetext.TabIndex = 32;
            datetext.Value = new DateTime(2023, 8, 1, 0, 0, 0, 0);
            // 
            // birthday
            // 
            birthday.AutoSize = true;
            birthday.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            birthday.Location = new Point(27, 149);
            birthday.Name = "birthday";
            birthday.Size = new Size(108, 23);
            birthday.TabIndex = 31;
            birthday.Text = "Hạn sử dụng";
            birthday.Click += birthday_Click;
            // 
            // destext
            // 
            destext.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            destext.Location = new Point(493, 99);
            destext.Multiline = true;
            destext.Name = "destext";
            destext.ReadOnly = true;
            destext.Size = new Size(181, 74);
            destext.TabIndex = 28;
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Email.Location = new Point(421, 95);
            Email.Name = "Email";
            Email.Size = new Size(55, 23);
            Email.TabIndex = 27;
            Email.Text = "Mô tả";
            Email.Click += Email_Click;
            // 
            // nametext
            // 
            nametext.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            nametext.Location = new Point(153, 95);
            nametext.Name = "nametext";
            nametext.ReadOnly = true;
            nametext.Size = new Size(204, 30);
            nametext.TabIndex = 26;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            name.Location = new Point(23, 99);
            name.Name = "name";
            name.Size = new Size(116, 23);
            name.TabIndex = 25;
            name.Text = "Tên chứng chỉ";
            name.Click += name_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, CertificateName, Description, Usedate, Image });
            dataGridView1.Location = new Point(23, 270);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(901, 278);
            dataGridView1.TabIndex = 33;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 60;
            // 
            // CertificateName
            // 
            CertificateName.HeaderText = "CertificateName";
            CertificateName.MinimumWidth = 6;
            CertificateName.Name = "CertificateName";
            CertificateName.ReadOnly = true;
            CertificateName.Width = 200;
            // 
            // Description
            // 
            Description.HeaderText = "Description";
            Description.MinimumWidth = 6;
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Width = 300;
            // 
            // Usedate
            // 
            Usedate.HeaderText = "Usedate";
            Usedate.MinimumWidth = 6;
            Usedate.Name = "Usedate";
            Usedate.ReadOnly = true;
            Usedate.Width = 125;
            // 
            // Image
            // 
            Image.HeaderText = "Image";
            Image.MinimumWidth = 6;
            Image.Name = "Image";
            Image.ReadOnly = true;
            Image.Resizable = DataGridViewTriState.True;
            Image.SortMode = DataGridViewColumnSortMode.NotSortable;
            Image.Width = 168;
            // 
            // cancel
            // 
            cancel.BackColor = Color.LightSlateGray;
            cancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cancel.ForeColor = SystemColors.ButtonHighlight;
            cancel.Location = new Point(359, 209);
            cancel.Name = "cancel";
            cancel.Size = new Size(167, 42);
            cancel.TabIndex = 35;
            cancel.Text = "Hủy bỏ";
            cancel.UseVisualStyleBackColor = false;
            cancel.Visible = false;
            cancel.Click += cancel_Click;
            // 
            // accept
            // 
            accept.BackColor = Color.DarkTurquoise;
            accept.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            accept.ForeColor = SystemColors.ButtonHighlight;
            accept.Location = new Point(140, 209);
            accept.Name = "accept";
            accept.Size = new Size(167, 41);
            accept.TabIndex = 34;
            accept.Text = "Đồng ý";
            accept.UseVisualStyleBackColor = false;
            accept.Visible = false;
            accept.Click += accept_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(725, 95);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(199, 155);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 36;
            pictureBox1.TabStop = false;
            // 
            // CertificateDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(954, 560);
            Controls.Add(pictureBox1);
            Controls.Add(cancel);
            Controls.Add(accept);
            Controls.Add(dataGridView1);
            Controls.Add(datetext);
            Controls.Add(birthday);
            Controls.Add(destext);
            Controls.Add(Email);
            Controls.Add(nametext);
            Controls.Add(name);
            Controls.Add(upimg);
            Controls.Add(btnDel);
            Controls.Add(btnUps);
            Controls.Add(btnIns);
            Name = "CertificateDialog";
            Text = "CertificateDialog";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIns;
        private Button btnUps;
        private Button btnDel;
        private Button upimg;
        private DateTimePicker datetext;
        private Label birthday;
        private TextBox destext;
        private Label Email;
        private TextBox nametext;
        private Label name;
        private DataGridView dataGridView1;
        private Button cancel;
        private Button accept;
        private PictureBox pictureBox1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn CertificateName;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Usedate;
        private DataGridViewTextBoxColumn Image;
    }
}