namespace Hospital_Application.Dialogs
{
    partial class information
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
            name = new Label();
            nametext = new TextBox();
            emailtext = new TextBox();
            Email = new Label();
            phonetext = new TextBox();
            phone = new Label();
            birthday = new Label();
            cccdtext = new TextBox();
            cccd = new Label();
            salarytext = new TextBox();
            salary = new Label();
            roletext = new TextBox();
            role = new Label();
            classtext = new TextBox();
            classname = new Label();
            destext = new TextBox();
            des = new Label();
            addresstext = new TextBox();
            address = new Label();
            btnUpdate = new Button();
            cancel = new Button();
            UpImg = new Button();
            accept = new Button();
            datetext = new DateTimePicker();
            SuspendLayout();
            // 
            // name
            // 
            name.AutoSize = true;
            name.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            name.Location = new Point(45, 91);
            name.Name = "name";
            name.Size = new Size(62, 23);
            name.TabIndex = 0;
            name.Text = "Họ tên";
            // 
            // nametext
            // 
            nametext.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            nametext.Location = new Point(156, 87);
            nametext.Name = "nametext";
            nametext.ReadOnly = true;
            nametext.Size = new Size(204, 30);
            nametext.TabIndex = 1;
            // 
            // emailtext
            // 
            emailtext.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            emailtext.Location = new Point(596, 91);
            emailtext.Name = "emailtext";
            emailtext.ReadOnly = true;
            emailtext.Size = new Size(238, 30);
            emailtext.TabIndex = 3;
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Email.Location = new Point(510, 94);
            Email.Name = "Email";
            Email.Size = new Size(51, 23);
            Email.TabIndex = 2;
            Email.Text = "Email";
            // 
            // phonetext
            // 
            phonetext.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            phonetext.Location = new Point(156, 138);
            phonetext.Name = "phonetext";
            phonetext.ReadOnly = true;
            phonetext.Size = new Size(204, 30);
            phonetext.TabIndex = 5;
            // 
            // phone
            // 
            phone.AutoSize = true;
            phone.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            phone.Location = new Point(45, 142);
            phone.Name = "phone";
            phone.Size = new Size(111, 23);
            phone.TabIndex = 4;
            phone.Text = "Số điện thoại";
            // 
            // birthday
            // 
            birthday.AutoSize = true;
            birthday.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            birthday.Location = new Point(504, 145);
            birthday.Name = "birthday";
            birthday.Size = new Size(86, 23);
            birthday.TabIndex = 6;
            birthday.Text = "Ngày sinh";
            // 
            // cccdtext
            // 
            cccdtext.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cccdtext.Location = new Point(156, 189);
            cccdtext.Name = "cccdtext";
            cccdtext.ReadOnly = true;
            cccdtext.Size = new Size(204, 30);
            cccdtext.TabIndex = 9;
            cccdtext.TextChanged += textBox5_TextChanged;
            // 
            // cccd
            // 
            cccd.AutoSize = true;
            cccd.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cccd.Location = new Point(45, 192);
            cccd.Name = "cccd";
            cccd.Size = new Size(55, 23);
            cccd.TabIndex = 8;
            cccd.Text = "CCCD";
            // 
            // salarytext
            // 
            salarytext.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            salarytext.Location = new Point(596, 192);
            salarytext.Name = "salarytext";
            salarytext.ReadOnly = true;
            salarytext.Size = new Size(238, 30);
            salarytext.TabIndex = 11;
            // 
            // salary
            // 
            salary.AutoSize = true;
            salary.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            salary.Location = new Point(510, 195);
            salary.Name = "salary";
            salary.Size = new Size(58, 23);
            salary.TabIndex = 10;
            salary.Text = "Lương";
            // 
            // roletext
            // 
            roletext.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            roletext.Location = new Point(596, 244);
            roletext.Name = "roletext";
            roletext.ReadOnly = true;
            roletext.Size = new Size(238, 30);
            roletext.TabIndex = 15;
            // 
            // role
            // 
            role.AutoSize = true;
            role.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            role.Location = new Point(510, 247);
            role.Name = "role";
            role.Size = new Size(60, 23);
            role.TabIndex = 14;
            role.Text = "Vai trò";
            role.Click += label1_Click;
            // 
            // classtext
            // 
            classtext.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            classtext.Location = new Point(156, 241);
            classtext.Name = "classtext";
            classtext.ReadOnly = true;
            classtext.Size = new Size(204, 30);
            classtext.TabIndex = 13;
            // 
            // classname
            // 
            classname.AutoSize = true;
            classname.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            classname.Location = new Point(28, 241);
            classname.Name = "classname";
            classname.Size = new Size(122, 23);
            classname.TabIndex = 12;
            classname.Text = "Chuyên ngành";
            classname.Click += classname_Click;
            // 
            // destext
            // 
            destext.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            destext.Location = new Point(596, 298);
            destext.Multiline = true;
            destext.Name = "destext";
            destext.ReadOnly = true;
            destext.Size = new Size(238, 121);
            destext.TabIndex = 19;
            // 
            // des
            // 
            des.AutoSize = true;
            des.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            des.Location = new Point(510, 301);
            des.Name = "des";
            des.Size = new Size(55, 23);
            des.TabIndex = 18;
            des.Text = "Mô tả";
            // 
            // addresstext
            // 
            addresstext.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            addresstext.Location = new Point(156, 295);
            addresstext.Multiline = true;
            addresstext.Name = "addresstext";
            addresstext.ReadOnly = true;
            addresstext.Size = new Size(204, 124);
            addresstext.TabIndex = 17;
            // 
            // address
            // 
            address.AutoSize = true;
            address.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            address.Location = new Point(46, 295);
            address.Name = "address";
            address.Size = new Size(62, 23);
            address.TabIndex = 16;
            address.Text = "Địa chỉ";
            address.Click += label2_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DarkTurquoise;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.ImageAlign = ContentAlignment.TopLeft;
            btnUpdate.Location = new Point(156, 12);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(162, 52);
            btnUpdate.TabIndex = 20;
            btnUpdate.Text = "Action cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // cancel
            // 
            cancel.BackColor = Color.DarkGray;
            cancel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cancel.ForeColor = Color.White;
            cancel.ImageAlign = ContentAlignment.TopLeft;
            cancel.Location = new Point(504, 447);
            cancel.Name = "cancel";
            cancel.Size = new Size(162, 52);
            cancel.TabIndex = 21;
            cancel.Text = "Hủy bỏ";
            cancel.UseVisualStyleBackColor = false;
            cancel.Visible = false;
            cancel.Click += cancel_Click;
            // 
            // UpImg
            // 
            UpImg.BackColor = Color.DarkTurquoise;
            UpImg.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            UpImg.ForeColor = Color.White;
            UpImg.ImageAlign = ContentAlignment.TopLeft;
            UpImg.Location = new Point(552, 12);
            UpImg.Name = "UpImg";
            UpImg.Size = new Size(162, 52);
            UpImg.TabIndex = 22;
            UpImg.Text = "Cập nhật ảnh";
            UpImg.UseVisualStyleBackColor = false;
            UpImg.Click += UpImg_Click;
            // 
            // accept
            // 
            accept.BackColor = Color.DarkTurquoise;
            accept.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            accept.ForeColor = Color.White;
            accept.ImageAlign = ContentAlignment.TopLeft;
            accept.Location = new Point(198, 447);
            accept.Name = "accept";
            accept.Size = new Size(162, 52);
            accept.TabIndex = 23;
            accept.Text = "Cập nhật";
            accept.UseVisualStyleBackColor = false;
            accept.Visible = false;
            accept.Click += accept_Click;
            // 
            // datetext
            // 
            datetext.CalendarFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            datetext.CustomFormat = "dd/MM/yyyy";
            datetext.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            datetext.Format = DateTimePickerFormat.Custom;
            datetext.Location = new Point(596, 145);
            datetext.Name = "datetext";
            datetext.Size = new Size(238, 32);
            datetext.TabIndex = 24;
            datetext.Value = new DateTime(2023, 8, 1, 0, 0, 0, 0);
            // 
            // information
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(954, 560);
            Controls.Add(datetext);
            Controls.Add(accept);
            Controls.Add(UpImg);
            Controls.Add(cancel);
            Controls.Add(btnUpdate);
            Controls.Add(destext);
            Controls.Add(des);
            Controls.Add(addresstext);
            Controls.Add(address);
            Controls.Add(roletext);
            Controls.Add(role);
            Controls.Add(classtext);
            Controls.Add(classname);
            Controls.Add(salarytext);
            Controls.Add(salary);
            Controls.Add(cccdtext);
            Controls.Add(cccd);
            Controls.Add(birthday);
            Controls.Add(phonetext);
            Controls.Add(phone);
            Controls.Add(emailtext);
            Controls.Add(Email);
            Controls.Add(nametext);
            Controls.Add(name);
            Name = "information";
            Text = "information";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label name;
        private TextBox nametext;
        private TextBox emailtext;
        private Label Email;
        private TextBox phonetext;
        private Label phone;
        private Label birthday;
        private TextBox cccdtext;
        private Label cccd;
        private TextBox salarytext;
        private Label salary;
        private TextBox roletext;
        private Label role;
        private TextBox classtext;
        private Label classname;
        private TextBox destext;
        private Label des;
        private TextBox addresstext;
        private Label address;
        private Button btnUpdate;
        private Button cancel;
        private Button UpImg;
        private Button accept;
        private DateTimePicker datetext;
    }
}