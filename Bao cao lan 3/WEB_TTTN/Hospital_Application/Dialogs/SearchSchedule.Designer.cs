namespace Hospital_Application.Dialogs
{
    partial class SearchSchedule
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
            textBox1 = new TextBox();
            destext = new Label();
            emailText = new TextBox();
            label5 = new Label();
            dateschedule = new DateTimePicker();
            label4 = new Label();
            nameschedule = new TextBox();
            label3 = new Label();
            phoneschedule = new TextBox();
            label2 = new Label();
            eventname = new TextBox();
            label1 = new Label();
            namesearch = new TextBox();
            label6 = new Label();
            datesearch = new DateTimePicker();
            label8 = new Label();
            label9 = new Label();
            phoneSearch = new TextBox();
            searchclick = new Button();
            active = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(646, 388);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 126);
            textBox1.TabIndex = 59;
            // 
            // destext
            // 
            destext.AutoSize = true;
            destext.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            destext.Location = new Point(517, 388);
            destext.Name = "destext";
            destext.Size = new Size(61, 25);
            destext.TabIndex = 58;
            destext.Text = "Mô tả";
            // 
            // emailText
            // 
            emailText.Location = new Point(646, 318);
            emailText.Name = "emailText";
            emailText.Size = new Size(250, 27);
            emailText.TabIndex = 57;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(517, 317);
            label5.Name = "label5";
            label5.Size = new Size(58, 25);
            label5.TabIndex = 56;
            label5.Text = "Email";
            // 
            // dateschedule
            // 
            dateschedule.CustomFormat = "dd/MM/yyyy HH:mm";
            dateschedule.Format = DateTimePickerFormat.Custom;
            dateschedule.Location = new Point(646, 140);
            dateschedule.Name = "dateschedule";
            dateschedule.Size = new Size(250, 27);
            dateschedule.TabIndex = 55;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(517, 266);
            label4.Name = "label4";
            label4.Size = new Size(123, 25);
            label4.TabIndex = 54;
            label4.Text = "Số điện thoại";
            // 
            // nameschedule
            // 
            nameschedule.Location = new Point(646, 209);
            nameschedule.Name = "nameschedule";
            nameschedule.ReadOnly = true;
            nameschedule.Size = new Size(250, 27);
            nameschedule.TabIndex = 53;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(517, 208);
            label3.Name = "label3";
            label3.Size = new Size(68, 25);
            label3.TabIndex = 52;
            label3.Text = "Họ tên";
            // 
            // phoneschedule
            // 
            phoneschedule.Location = new Point(646, 264);
            phoneschedule.Name = "phoneschedule";
            phoneschedule.ReadOnly = true;
            phoneschedule.Size = new Size(250, 27);
            phoneschedule.TabIndex = 51;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(517, 140);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 50;
            label2.Text = "Ngày tháng";
            // 
            // eventname
            // 
            eventname.Location = new Point(646, 82);
            eventname.Name = "eventname";
            eventname.ReadOnly = true;
            eventname.Size = new Size(250, 27);
            eventname.TabIndex = 49;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(517, 81);
            label1.Name = "label1";
            label1.Size = new Size(113, 25);
            label1.TabIndex = 48;
            label1.Text = "Tên lịch hẹn";
            // 
            // namesearch
            // 
            namesearch.Location = new Point(203, 82);
            namesearch.Name = "namesearch";
            namesearch.Size = new Size(176, 27);
            namesearch.TabIndex = 61;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(38, 81);
            label6.Name = "label6";
            label6.Size = new Size(70, 25);
            label6.TabIndex = 60;
            label6.Text = "Họ Tên";
            // 
            // datesearch
            // 
            datesearch.CustomFormat = "dd/MM/yyyy HH:mm";
            datesearch.Format = DateTimePickerFormat.Custom;
            datesearch.Location = new Point(203, 151);
            datesearch.Name = "datesearch";
            datesearch.Size = new Size(176, 27);
            datesearch.TabIndex = 65;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(36, 150);
            label8.Name = "label8";
            label8.Size = new Size(110, 25);
            label8.TabIndex = 64;
            label8.Text = "Ngày tháng";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(36, 210);
            label9.Name = "label9";
            label9.Size = new Size(123, 25);
            label9.TabIndex = 67;
            label9.Text = "Số điện thoại";
            // 
            // phoneSearch
            // 
            phoneSearch.Location = new Point(203, 206);
            phoneSearch.Name = "phoneSearch";
            phoneSearch.Size = new Size(176, 27);
            phoneSearch.TabIndex = 66;
            // 
            // searchclick
            // 
            searchclick.BackColor = Color.DarkTurquoise;
            searchclick.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            searchclick.ForeColor = SystemColors.ButtonHighlight;
            searchclick.Location = new Point(127, 302);
            searchclick.Name = "searchclick";
            searchclick.Size = new Size(171, 53);
            searchclick.TabIndex = 68;
            searchclick.Text = "Tìm kiếm";
            searchclick.UseVisualStyleBackColor = false;
            searchclick.Click += searchclick_Click;
            // 
            // active
            // 
            active.BackColor = Color.DarkTurquoise;
            active.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            active.ForeColor = SystemColors.ButtonHighlight;
            active.Location = new Point(127, 384);
            active.Name = "active";
            active.Size = new Size(171, 55);
            active.TabIndex = 69;
            active.Text = "Khách đúng lịch";
            active.UseVisualStyleBackColor = false;
            active.Visible = false;
            active.Click += active_Click;
            // 
            // SearchSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(954, 560);
            Controls.Add(active);
            Controls.Add(searchclick);
            Controls.Add(label9);
            Controls.Add(phoneSearch);
            Controls.Add(datesearch);
            Controls.Add(label8);
            Controls.Add(namesearch);
            Controls.Add(label6);
            Controls.Add(textBox1);
            Controls.Add(destext);
            Controls.Add(emailText);
            Controls.Add(label5);
            Controls.Add(dateschedule);
            Controls.Add(label4);
            Controls.Add(nameschedule);
            Controls.Add(label3);
            Controls.Add(phoneschedule);
            Controls.Add(label2);
            Controls.Add(eventname);
            Controls.Add(label1);
            Name = "SearchSchedule";
            Text = "SearchSchedule";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label destext;
        private TextBox emailText;
        private Label label5;
        private DateTimePicker dateschedule;
        private Label label4;
        private TextBox nameschedule;
        private Label label3;
        private TextBox phoneschedule;
        private Label label2;
        private TextBox eventname;
        private Label label1;
        private TextBox namesearch;
        private Label label6;
        private DateTimePicker datesearch;
        private Label label8;
        private Label label9;
        private TextBox phoneSearch;
        private Button searchclick;
        private Button active;
    }
}