namespace Hospital_Application.Dialogs
{
    partial class ServicePatientDialog
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
            getdate = new DataGridViewTextBoxColumn();
            servicename = new DataGridViewTextBoxColumn();
            empname = new DataGridViewTextBoxColumn();
            empid = new DataGridViewTextBoxColumn();
            servicedes = new DataGridViewTextBoxColumn();
            cancel = new Button();
            bill = new Button();
            ins = new Button();
            search = new Button();
            accept = new Button();
            des = new TextBox();
            label5 = new Label();
            label2 = new Label();
            credate = new DateTimePicker();
            type = new ComboBox();
            label8 = new Label();
            manvtext = new TextBox();
            label1 = new Label();
            nametext = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, getdate, servicename, empname, empid, servicedes });
            dataGridView1.Location = new Point(12, 281);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(930, 267);
            dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 80;
            // 
            // getdate
            // 
            getdate.HeaderText = "GetDate";
            getdate.MinimumWidth = 6;
            getdate.Name = "getdate";
            getdate.ReadOnly = true;
            getdate.Width = 125;
            // 
            // servicename
            // 
            servicename.HeaderText = "Type Service Name";
            servicename.MinimumWidth = 6;
            servicename.Name = "servicename";
            servicename.ReadOnly = true;
            servicename.Width = 170;
            // 
            // empname
            // 
            empname.HeaderText = "Employee Name";
            empname.MinimumWidth = 6;
            empname.Name = "empname";
            empname.ReadOnly = true;
            empname.Width = 170;
            // 
            // empid
            // 
            empid.HeaderText = "EmpID";
            empid.MinimumWidth = 6;
            empid.Name = "empid";
            empid.ReadOnly = true;
            empid.Width = 112;
            // 
            // servicedes
            // 
            servicedes.HeaderText = "Description";
            servicedes.MinimumWidth = 6;
            servicedes.Name = "servicedes";
            servicedes.ReadOnly = true;
            servicedes.Width = 220;
            // 
            // cancel
            // 
            cancel.BackColor = Color.DarkGray;
            cancel.Location = new Point(810, 159);
            cancel.Name = "cancel";
            cancel.Size = new Size(121, 36);
            cancel.TabIndex = 22;
            cancel.Text = "Hủy";
            cancel.UseVisualStyleBackColor = false;
            cancel.Visible = false;
            cancel.Click += cancel_Click;
            // 
            // bill
            // 
            bill.BackColor = Color.DarkTurquoise;
            bill.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            bill.ForeColor = SystemColors.ButtonHighlight;
            bill.Location = new Point(703, 218);
            bill.Name = "bill";
            bill.Size = new Size(196, 36);
            bill.TabIndex = 21;
            bill.Text = "Đơn thuốc";
            bill.UseVisualStyleBackColor = false;
            bill.Visible = false;
            bill.Click += bill_Click;
            // 
            // ins
            // 
            ins.BackColor = Color.DarkTurquoise;
            ins.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ins.ForeColor = SystemColors.ButtonHighlight;
            ins.Location = new Point(668, 97);
            ins.Name = "ins";
            ins.Size = new Size(121, 36);
            ins.TabIndex = 20;
            ins.Text = "Thêm";
            ins.UseVisualStyleBackColor = false;
            ins.Click += ins_Click;
            // 
            // search
            // 
            search.BackColor = Color.DarkTurquoise;
            search.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            search.ForeColor = SystemColors.ButtonHighlight;
            search.Location = new Point(668, 159);
            search.Name = "search";
            search.Size = new Size(121, 36);
            search.TabIndex = 19;
            search.Text = "Tìm kiếm";
            search.UseVisualStyleBackColor = false;
            search.Click += search_Click;
            // 
            // accept
            // 
            accept.BackColor = Color.Lime;
            accept.ForeColor = SystemColors.ActiveCaptionText;
            accept.Location = new Point(810, 98);
            accept.Name = "accept";
            accept.Size = new Size(121, 36);
            accept.TabIndex = 18;
            accept.Text = "Đồng ý";
            accept.UseVisualStyleBackColor = false;
            accept.Visible = false;
            accept.Click += accept_Click;
            // 
            // des
            // 
            des.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            des.Location = new Point(135, 115);
            des.Multiline = true;
            des.Name = "des";
            des.ReadOnly = true;
            des.Size = new Size(499, 139);
            des.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(32, 113);
            label5.Name = "label5";
            label5.Size = new Size(55, 23);
            label5.TabIndex = 31;
            label5.Text = "Mô tả";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(32, 49);
            label2.Name = "label2";
            label2.Size = new Size(97, 23);
            label2.TabIndex = 25;
            label2.Text = "Ngày khám";
            // 
            // credate
            // 
            credate.CustomFormat = "dd/MM/yyyy";
            credate.Format = DateTimePickerFormat.Custom;
            credate.Location = new Point(135, 49);
            credate.Name = "credate";
            credate.Size = new Size(162, 27);
            credate.TabIndex = 43;
            // 
            // type
            // 
            type.FormattingEnabled = true;
            type.Location = new Point(469, 51);
            type.Name = "type";
            type.Size = new Size(165, 28);
            type.TabIndex = 55;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(358, 49);
            label8.Name = "label8";
            label8.Size = new Size(101, 23);
            label8.TabIndex = 54;
            label8.Text = "Loại dịch vụ";
            // 
            // manvtext
            // 
            manvtext.Location = new Point(769, 12);
            manvtext.Name = "manvtext";
            manvtext.ReadOnly = true;
            manvtext.Size = new Size(162, 27);
            manvtext.TabIndex = 57;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(666, 12);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 56;
            label1.Text = "Mã nhân viên";
            // 
            // nametext
            // 
            nametext.Location = new Point(769, 52);
            nametext.Name = "nametext";
            nametext.ReadOnly = true;
            nametext.Size = new Size(162, 27);
            nametext.TabIndex = 59;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(666, 52);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 58;
            label3.Text = "Tên nhân viên";
            // 
            // ServicePatientDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(954, 560);
            Controls.Add(nametext);
            Controls.Add(label3);
            Controls.Add(manvtext);
            Controls.Add(label1);
            Controls.Add(type);
            Controls.Add(label8);
            Controls.Add(credate);
            Controls.Add(des);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(cancel);
            Controls.Add(bill);
            Controls.Add(ins);
            Controls.Add(search);
            Controls.Add(accept);
            Controls.Add(dataGridView1);
            Name = "ServicePatientDialog";
            Text = "ServicePatientDialog";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button cancel;
        private Button bill;
        private Button ins;
        private Button search;
        private Button accept;
        private TextBox des;
        private Label label5;
        private Label label2;
        private DateTimePicker credate;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn getdate;
        private DataGridViewTextBoxColumn servicename;
        private DataGridViewTextBoxColumn empname;
        private DataGridViewTextBoxColumn empid;
        private DataGridViewTextBoxColumn servicedes;
        private ComboBox type;
        private Label label8;
        private TextBox manvtext;
        private Label label1;
        private TextBox nametext;
        private Label label3;
    }
}