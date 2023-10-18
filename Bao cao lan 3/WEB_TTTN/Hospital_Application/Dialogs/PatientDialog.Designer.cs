namespace Hospital_Application.Dialogs
{
    partial class PatientDialog
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
            id = new DataGridViewTextBoxColumn();
            patname = new DataGridViewTextBoxColumn();
            patphone = new DataGridViewTextBoxColumn();
            patemail = new DataGridViewTextBoxColumn();
            patinsurance = new DataGridViewTextBoxColumn();
            pataddress = new DataGridViewTextBoxColumn();
            label1 = new Label();
            nametext = new TextBox();
            phone = new TextBox();
            label2 = new Label();
            email = new TextBox();
            label3 = new Label();
            address = new TextBox();
            label5 = new Label();
            BHYT = new TextBox();
            label6 = new Label();
            update = new Button();
            accept = new Button();
            search = new Button();
            ins = new Button();
            service = new Button();
            cancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, patname, patphone, patemail, patinsurance, pataddress });
            dataGridView1.Location = new Point(12, 280);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(930, 268);
            dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Width = 80;
            // 
            // patname
            // 
            patname.HeaderText = "Patient Name";
            patname.MinimumWidth = 6;
            patname.Name = "patname";
            patname.ReadOnly = true;
            patname.Width = 200;
            // 
            // patphone
            // 
            patphone.HeaderText = "phone";
            patphone.MinimumWidth = 6;
            patphone.Name = "patphone";
            patphone.ReadOnly = true;
            patphone.Width = 125;
            // 
            // patemail
            // 
            patemail.HeaderText = "Email";
            patemail.MinimumWidth = 6;
            patemail.Name = "patemail";
            patemail.ReadOnly = true;
            patemail.Width = 147;
            // 
            // patinsurance
            // 
            patinsurance.HeaderText = "InsuranceID";
            patinsurance.MinimumWidth = 6;
            patinsurance.Name = "patinsurance";
            patinsurance.ReadOnly = true;
            patinsurance.Width = 125;
            // 
            // pataddress
            // 
            pataddress.HeaderText = "Address";
            pataddress.MinimumWidth = 6;
            pataddress.Name = "pataddress";
            pataddress.ReadOnly = true;
            pataddress.Width = 200;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 86);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 1;
            label1.Text = "Họ tên";
            // 
            // nametext
            // 
            nametext.Location = new Point(137, 86);
            nametext.Name = "nametext";
            nametext.ReadOnly = true;
            nametext.Size = new Size(162, 27);
            nametext.TabIndex = 2;
            // 
            // phone
            // 
            phone.Location = new Point(137, 152);
            phone.Name = "phone";
            phone.ReadOnly = true;
            phone.Size = new Size(162, 27);
            phone.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 152);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 3;
            label2.Text = "Số điện thoại";
            // 
            // email
            // 
            email.Location = new Point(137, 212);
            email.Name = "email";
            email.ReadOnly = true;
            email.Size = new Size(162, 27);
            email.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 212);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 5;
            label3.Text = "Email";
            // 
            // address
            // 
            address.Location = new Point(473, 152);
            address.Multiline = true;
            address.Name = "address";
            address.ReadOnly = true;
            address.Size = new Size(162, 80);
            address.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(370, 152);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 9;
            label5.Text = "Địa chỉ";
            // 
            // BHYT
            // 
            BHYT.Location = new Point(473, 86);
            BHYT.Name = "BHYT";
            BHYT.ReadOnly = true;
            BHYT.Size = new Size(162, 27);
            BHYT.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(370, 86);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 7;
            label6.Text = "Mã BHYT";
            // 
            // update
            // 
            update.BackColor = Color.DarkTurquoise;
            update.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            update.ForeColor = SystemColors.ButtonHighlight;
            update.Location = new Point(679, 104);
            update.Name = "update";
            update.Size = new Size(121, 36);
            update.TabIndex = 11;
            update.Text = "Sửa";
            update.UseVisualStyleBackColor = false;
            update.Visible = false;
            update.Click += button1_Click;
            // 
            // accept
            // 
            accept.BackColor = Color.Lime;
            accept.ForeColor = SystemColors.ActiveCaptionText;
            accept.Location = new Point(821, 104);
            accept.Name = "accept";
            accept.Size = new Size(121, 36);
            accept.TabIndex = 12;
            accept.Text = "Đồng ý";
            accept.UseVisualStyleBackColor = false;
            accept.Visible = false;
            accept.Click += accept_Click;
            // 
            // search
            // 
            search.BackColor = Color.DarkTurquoise;
            search.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            search.ForeColor = SystemColors.ButtonHighlight;
            search.Location = new Point(679, 165);
            search.Name = "search";
            search.Size = new Size(121, 36);
            search.TabIndex = 13;
            search.Text = "Tìm kiếm";
            search.UseVisualStyleBackColor = false;
            search.Click += button3_Click;
            // 
            // ins
            // 
            ins.BackColor = Color.DarkTurquoise;
            ins.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ins.ForeColor = SystemColors.ButtonHighlight;
            ins.Location = new Point(679, 45);
            ins.Name = "ins";
            ins.Size = new Size(121, 36);
            ins.TabIndex = 14;
            ins.Text = "Thêm";
            ins.UseVisualStyleBackColor = false;
            ins.Click += ins_Click;
            // 
            // service
            // 
            service.BackColor = Color.DarkTurquoise;
            service.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            service.ForeColor = SystemColors.ButtonHighlight;
            service.Location = new Point(714, 224);
            service.Name = "service";
            service.Size = new Size(196, 36);
            service.TabIndex = 15;
            service.Text = "Bệnh án";
            service.UseVisualStyleBackColor = false;
            service.Visible = false;
            service.Click += service_Click;
            // 
            // cancel
            // 
            cancel.BackColor = Color.DarkGray;
            cancel.Location = new Point(821, 165);
            cancel.Name = "cancel";
            cancel.Size = new Size(121, 36);
            cancel.TabIndex = 16;
            cancel.Text = "Hủy";
            cancel.UseVisualStyleBackColor = false;
            cancel.Visible = false;
            cancel.Click += cancel_Click;
            // 
            // PatientDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(954, 560);
            Controls.Add(cancel);
            Controls.Add(service);
            Controls.Add(ins);
            Controls.Add(search);
            Controls.Add(accept);
            Controls.Add(update);
            Controls.Add(address);
            Controls.Add(label5);
            Controls.Add(BHYT);
            Controls.Add(label6);
            Controls.Add(email);
            Controls.Add(label3);
            Controls.Add(phone);
            Controls.Add(label2);
            Controls.Add(nametext);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "PatientDialog";
            Text = "ServiceDialog";
            Load += ServiceDialog_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox nametext;
        private TextBox phone;
        private Label label2;
        private TextBox email;
        private Label label3;
        private TextBox address;
        private Label label5;
        private TextBox BHYT;
        private Label label6;
        private Button update;
        private Button accept;
        private Button search;
        private Button ins;
        private Button service;
        private Button cancel;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn patname;
        private DataGridViewTextBoxColumn patphone;
        private DataGridViewTextBoxColumn patemail;
        private DataGridViewTextBoxColumn patinsurance;
        private DataGridViewTextBoxColumn pataddress;
    }
}