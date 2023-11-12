namespace Hospital_Application.Dialogs
{
    partial class ConfirmSchedule
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
            eventname = new TextBox();
            label1 = new Label();
            phone = new TextBox();
            label2 = new Label();
            name = new TextBox();
            label3 = new Label();
            label4 = new Label();
            date = new DateTimePicker();
            button2 = new Button();
            pictureBox = new PictureBox();
            emailText = new TextBox();
            label5 = new Label();
            textBox1 = new TextBox();
            destext = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // eventname
            // 
            eventname.Location = new Point(177, 42);
            eventname.Name = "eventname";
            eventname.ReadOnly = true;
            eventname.Size = new Size(250, 27);
            eventname.TabIndex = 25;
            eventname.TextChanged += textBox1_TextChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(48, 41);
            label1.Name = "label1";
            label1.Size = new Size(113, 25);
            label1.TabIndex = 24;
            label1.Text = "Tên lịch hẹn";
            // 
            // phone
            // 
            phone.Location = new Point(177, 224);
            phone.Name = "phone";
            phone.ReadOnly = true;
            phone.Size = new Size(250, 27);
            phone.TabIndex = 27;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(48, 100);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 26;
            label2.Text = "Ngày tháng";
            // 
            // name
            // 
            name.Location = new Point(177, 169);
            name.Name = "name";
            name.ReadOnly = true;
            name.Size = new Size(250, 27);
            name.TabIndex = 29;
            name.TextChanged += textBox3_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(48, 168);
            label3.Name = "label3";
            label3.Size = new Size(68, 25);
            label3.TabIndex = 28;
            label3.Text = "Họ tên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(48, 226);
            label4.Name = "label4";
            label4.Size = new Size(123, 25);
            label4.TabIndex = 30;
            label4.Text = "Số điện thoại";
            // 
            // date
            // 
            date.CustomFormat = "dd/MM/yyyy HH:mm";
            date.Format = DateTimePickerFormat.Custom;
            date.Location = new Point(177, 100);
            date.Name = "date";
            date.Size = new Size(250, 27);
            date.TabIndex = 33;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkTurquoise;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.ImageAlign = ContentAlignment.TopLeft;
            button2.Location = new Point(587, 91);
            button2.Name = "button2";
            button2.Size = new Size(199, 42);
            button2.TabIndex = 34;
            button2.Text = "Scan Qr desktop";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(519, 179);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(402, 355);
            pictureBox.TabIndex = 35;
            pictureBox.TabStop = false;
            // 
            // emailText
            // 
            emailText.Location = new Point(177, 278);
            emailText.Name = "emailText";
            emailText.Size = new Size(250, 27);
            emailText.TabIndex = 45;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(48, 277);
            label5.Name = "label5";
            label5.Size = new Size(58, 25);
            label5.TabIndex = 44;
            label5.Text = "Email";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(177, 348);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 126);
            textBox1.TabIndex = 47;
            // 
            // destext
            // 
            destext.AutoSize = true;
            destext.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            destext.Location = new Point(48, 348);
            destext.Name = "destext";
            destext.Size = new Size(61, 25);
            destext.TabIndex = 46;
            destext.Text = "Mô tả";
            // 
            // ConfirmSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(954, 560);
            Controls.Add(textBox1);
            Controls.Add(destext);
            Controls.Add(emailText);
            Controls.Add(label5);
            Controls.Add(pictureBox);
            Controls.Add(button2);
            Controls.Add(date);
            Controls.Add(label4);
            Controls.Add(name);
            Controls.Add(label3);
            Controls.Add(phone);
            Controls.Add(label2);
            Controls.Add(eventname);
            Controls.Add(label1);
            Name = "ConfirmSchedule";
            Text = "ConfirmSchedule";
            Load += ConfirmSchedule_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox eventname;
        private Label label1;
        private TextBox phone;
        private Label label2;
        private TextBox name;
        private Label label3;
        private Label label4;
        private DateTimePicker date;
        private Button button2;
        private PictureBox pictureBox;
        private TextBox emailText;
        private Label label5;
        private TextBox textBox1;
        private Label destext;
    }
}