namespace Hospital_Application.Dialogs
{
    partial class AdminEmp
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
            username = new DataGridViewTextBoxColumn();
            empname = new DataGridViewTextBoxColumn();
            empemail = new DataGridViewTextBoxColumn();
            empphone = new DataGridViewTextBoxColumn();
            salary = new DataGridViewTextBoxColumn();
            role = new DataGridViewTextBoxColumn();
            classname = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            ins = new Button();
            del = new Button();
            update = new Button();
            accept = new Button();
            cancel = new Button();
            label1 = new Label();
            nametext = new TextBox();
            emailtext = new TextBox();
            label2 = new Label();
            phonetext = new TextBox();
            label3 = new Label();
            salarytext = new TextBox();
            label4 = new Label();
            label5 = new Label();
            emproletext = new ComboBox();
            classtext = new ComboBox();
            label6 = new Label();
            roletext = new ComboBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { username, empname, empemail, empphone, salary, role, classname, status });
            dataGridView1.Location = new Point(12, 196);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1053, 336);
            dataGridView1.TabIndex = 0;
            // 
            // username
            // 
            username.HeaderText = "EmpID";
            username.MinimumWidth = 6;
            username.Name = "username";
            username.ReadOnly = true;
            username.Width = 125;
            // 
            // empname
            // 
            empname.HeaderText = "EmpName";
            empname.MinimumWidth = 6;
            empname.Name = "empname";
            empname.ReadOnly = true;
            empname.Width = 125;
            // 
            // empemail
            // 
            empemail.HeaderText = "Email";
            empemail.MinimumWidth = 6;
            empemail.Name = "empemail";
            empemail.ReadOnly = true;
            empemail.Width = 125;
            // 
            // empphone
            // 
            empphone.HeaderText = "Phone";
            empphone.MinimumWidth = 6;
            empphone.Name = "empphone";
            empphone.ReadOnly = true;
            empphone.Width = 125;
            // 
            // salary
            // 
            salary.HeaderText = "Salary";
            salary.MinimumWidth = 6;
            salary.Name = "salary";
            salary.ReadOnly = true;
            salary.Width = 125;
            // 
            // role
            // 
            role.HeaderText = "RoleName";
            role.MinimumWidth = 6;
            role.Name = "role";
            role.ReadOnly = true;
            role.Width = 125;
            // 
            // classname
            // 
            classname.HeaderText = "Classname";
            classname.MinimumWidth = 6;
            classname.Name = "classname";
            classname.ReadOnly = true;
            classname.Width = 125;
            // 
            // status
            // 
            status.HeaderText = "Status";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.ReadOnly = true;
            status.Width = 125;
            // 
            // ins
            // 
            ins.Location = new Point(12, 12);
            ins.Name = "ins";
            ins.Size = new Size(121, 38);
            ins.TabIndex = 1;
            ins.Text = "Thêm";
            ins.UseVisualStyleBackColor = true;
            ins.Click += ins_Click;
            // 
            // del
            // 
            del.Location = new Point(172, 12);
            del.Name = "del";
            del.Size = new Size(121, 38);
            del.TabIndex = 2;
            del.Text = "Xóa";
            del.UseVisualStyleBackColor = true;
            del.Visible = false;
            del.Click += del_Click;
            // 
            // update
            // 
            update.Location = new Point(341, 12);
            update.Name = "update";
            update.Size = new Size(121, 38);
            update.TabIndex = 3;
            update.Text = "Sửa";
            update.UseVisualStyleBackColor = true;
            update.Visible = false;
            update.Click += update_Click;
            // 
            // accept
            // 
            accept.Location = new Point(509, 12);
            accept.Name = "accept";
            accept.Size = new Size(121, 38);
            accept.TabIndex = 4;
            accept.Text = "Lưu";
            accept.UseVisualStyleBackColor = true;
            accept.Visible = false;
            accept.Click += accept_Click;
            // 
            // cancel
            // 
            cancel.Location = new Point(658, 12);
            cancel.Name = "cancel";
            cancel.Size = new Size(121, 38);
            cancel.TabIndex = 5;
            cancel.Text = "Hủy";
            cancel.UseVisualStyleBackColor = true;
            cancel.Visible = false;
            cancel.Click += cancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 74);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 6;
            label1.Text = "Họ tên";
            // 
            // nametext
            // 
            nametext.Location = new Point(86, 74);
            nametext.Name = "nametext";
            nametext.ReadOnly = true;
            nametext.Size = new Size(143, 27);
            nametext.TabIndex = 7;
            // 
            // emailtext
            // 
            emailtext.Location = new Point(86, 128);
            emailtext.Name = "emailtext";
            emailtext.ReadOnly = true;
            emailtext.Size = new Size(143, 27);
            emailtext.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 131);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 8;
            label2.Text = "Email";
            label2.Click += label2_Click;
            // 
            // phonetext
            // 
            phonetext.Location = new Point(366, 74);
            phonetext.Name = "phonetext";
            phonetext.ReadOnly = true;
            phonetext.Size = new Size(143, 27);
            phonetext.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(292, 77);
            label3.Name = "label3";
            label3.Size = new Size(31, 20);
            label3.TabIndex = 10;
            label3.Text = "Sdt";
            // 
            // salarytext
            // 
            salarytext.Location = new Point(366, 131);
            salarytext.Name = "salarytext";
            salarytext.ReadOnly = true;
            salarytext.Size = new Size(143, 27);
            salarytext.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(292, 134);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 12;
            label4.Text = "Lương";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(889, 94);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 14;
            label5.Text = "Vai trò";
            label5.Click += label5_Click;
            // 
            // emproletext
            // 
            emproletext.FormattingEnabled = true;
            emproletext.Location = new Point(689, 71);
            emproletext.Name = "emproletext";
            emproletext.Size = new Size(151, 28);
            emproletext.TabIndex = 15;
            // 
            // classtext
            // 
            classtext.FormattingEnabled = true;
            classtext.Location = new Point(689, 139);
            classtext.Name = "classtext";
            classtext.Size = new Size(151, 28);
            classtext.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(565, 139);
            label6.Name = "label6";
            label6.Size = new Size(102, 20);
            label6.TabIndex = 16;
            label6.Text = "Chuyên ngành";
            // 
            // roletext
            // 
            roletext.FormattingEnabled = true;
            roletext.Location = new Point(889, 127);
            roletext.Name = "roletext";
            roletext.Size = new Size(151, 28);
            roletext.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(569, 74);
            label7.Name = "label7";
            label7.Size = new Size(61, 20);
            label7.TabIndex = 18;
            label7.Text = "Chức vụ";
            // 
            // AdminEmp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(1075, 571);
            Controls.Add(roletext);
            Controls.Add(label7);
            Controls.Add(classtext);
            Controls.Add(label6);
            Controls.Add(emproletext);
            Controls.Add(label5);
            Controls.Add(salarytext);
            Controls.Add(label4);
            Controls.Add(phonetext);
            Controls.Add(label3);
            Controls.Add(emailtext);
            Controls.Add(label2);
            Controls.Add(nametext);
            Controls.Add(label1);
            Controls.Add(cancel);
            Controls.Add(accept);
            Controls.Add(update);
            Controls.Add(del);
            Controls.Add(ins);
            Controls.Add(dataGridView1);
            Name = "AdminEmp";
            Text = "v";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button ins;
        private Button del;
        private Button update;
        private Button accept;
        private Button cancel;
        private Label label1;
        private TextBox nametext;
        private TextBox emailtext;
        private Label label2;
        private TextBox phonetext;
        private Label label3;
        private TextBox salarytext;
        private Label label4;
        private Label label5;
        private ComboBox emproletext;
        private ComboBox classtext;
        private Label label6;
        private ComboBox roletext;
        private Label label7;
        private DataGridViewTextBoxColumn username;
        private DataGridViewTextBoxColumn empname;
        private DataGridViewTextBoxColumn empemail;
        private DataGridViewTextBoxColumn empphone;
        private DataGridViewTextBoxColumn salary;
        private DataGridViewTextBoxColumn role;
        private DataGridViewTextBoxColumn classname;
        private DataGridViewTextBoxColumn status;
    }
}