namespace Hospital_Application.Dialogs
{
    partial class ShowInforSchedule
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
            name = new TextBox();
            label3 = new Label();
            phone = new TextBox();
            label2 = new Label();
            eventname = new TextBox();
            label1 = new Label();
            emailText = new TextBox();
            label5 = new Label();
            destext = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // date
            // 
            date.CustomFormat = "dd/MM/yyyy HH:mm";
            date.Format = DateTimePickerFormat.Custom;
            date.Location = new Point(164, 151);
            date.Name = "date";
            date.Size = new Size(250, 27);
            date.TabIndex = 41;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(35, 277);
            label4.Name = "label4";
            label4.Size = new Size(123, 25);
            label4.TabIndex = 40;
            label4.Text = "Số điện thoại";
            // 
            // name
            // 
            name.Location = new Point(164, 220);
            name.Name = "name";
            name.Size = new Size(250, 27);
            name.TabIndex = 39;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(35, 219);
            label3.Name = "label3";
            label3.Size = new Size(68, 25);
            label3.TabIndex = 38;
            label3.Text = "Họ tên";
            // 
            // phone
            // 
            phone.Location = new Point(164, 275);
            phone.Name = "phone";
            phone.Size = new Size(250, 27);
            phone.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(35, 151);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 36;
            label2.Text = "Ngày tháng";
            // 
            // eventname
            // 
            eventname.Location = new Point(164, 93);
            eventname.Name = "eventname";
            eventname.Size = new Size(250, 27);
            eventname.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(35, 92);
            label1.Name = "label1";
            label1.Size = new Size(113, 25);
            label1.TabIndex = 34;
            label1.Text = "Tên lịch hẹn";
            // 
            // emailText
            // 
            emailText.Location = new Point(164, 342);
            emailText.Name = "emailText";
            emailText.Size = new Size(250, 27);
            emailText.TabIndex = 43;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(35, 341);
            label5.Name = "label5";
            label5.Size = new Size(58, 25);
            label5.TabIndex = 42;
            label5.Text = "Email";
            // 
            // destext
            // 
            destext.AutoSize = true;
            destext.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            destext.Location = new Point(489, 93);
            destext.Name = "destext";
            destext.Size = new Size(61, 25);
            destext.TabIndex = 44;
            destext.Text = "Mô tả";
            destext.Click += label6_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(489, 132);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 234);
            textBox1.TabIndex = 45;
            // 
            // ShowInforSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(954, 560);
            Controls.Add(textBox1);
            Controls.Add(destext);
            Controls.Add(emailText);
            Controls.Add(label5);
            Controls.Add(date);
            Controls.Add(label4);
            Controls.Add(name);
            Controls.Add(label3);
            Controls.Add(phone);
            Controls.Add(label2);
            Controls.Add(eventname);
            Controls.Add(label1);
            Name = "ShowInforSchedule";
            Text = "ShowInforSchedule";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker date;
        private Label label4;
        private TextBox name;
        private Label label3;
        private TextBox phone;
        private Label label2;
        private TextBox eventname;
        private Label label1;
        private TextBox emailText;
        private Label label5;
        private Label destext;
        private TextBox textBox1;
    }
}