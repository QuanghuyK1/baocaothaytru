namespace Hospital_Application.Dialogs
{
    partial class ScheduleEmpPerson
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
            eventname = new ComboBox();
            ca = new Label();
            da = new Label();
            starttime = new DateTimePicker();
            diadiem = new ComboBox();
            label1 = new Label();
            des = new TextBox();
            label9 = new Label();
            cancel = new Button();
            ins = new Button();
            accept = new Button();
            Id = new DataGridViewTextBoxColumn();
            empevent = new DataGridViewTextBoxColumn();
            emptime = new DataGridViewTextBoxColumn();
            empdes = new DataGridViewTextBoxColumn();
            locationname = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, empevent, emptime, empdes, locationname, status });
            dataGridView1.Location = new Point(12, 185);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(930, 363);
            dataGridView1.TabIndex = 1;
            // 
            // eventname
            // 
            eventname.FormattingEnabled = true;
            eventname.Items.AddRange(new object[] { "Ca Sáng", "Ca Chiều", "Ca Tối" });
            eventname.Location = new Point(119, 33);
            eventname.Name = "eventname";
            eventname.Size = new Size(165, 28);
            eventname.TabIndex = 55;
            // 
            // ca
            // 
            ca.AutoSize = true;
            ca.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            ca.Location = new Point(31, 32);
            ca.Name = "ca";
            ca.Size = new Size(70, 25);
            ca.TabIndex = 54;
            ca.Text = "Ca làm";
            // 
            // da
            // 
            da.AutoSize = true;
            da.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            da.Location = new Point(25, 94);
            da.Name = "da";
            da.Size = new Size(92, 25);
            da.TabIndex = 56;
            da.Text = "Ngày làm";
            // 
            // starttime
            // 
            starttime.Format = DateTimePickerFormat.Custom;
            starttime.Location = new Point(119, 94);
            starttime.Name = "starttime";
            starttime.Size = new Size(165, 27);
            starttime.TabIndex = 57;
            // 
            // diadiem
            // 
            diadiem.FormattingEnabled = true;
            diadiem.Location = new Point(439, 33);
            diadiem.Name = "diadiem";
            diadiem.Size = new Size(165, 28);
            diadiem.TabIndex = 59;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(351, 32);
            label1.Name = "label1";
            label1.Size = new Size(87, 25);
            label1.TabIndex = 58;
            label1.Text = "Địa điểm";
            // 
            // des
            // 
            des.Location = new Point(439, 94);
            des.Multiline = true;
            des.Name = "des";
            des.ReadOnly = true;
            des.Size = new Size(202, 64);
            des.TabIndex = 61;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(353, 93);
            label9.Name = "label9";
            label9.Size = new Size(61, 25);
            label9.TabIndex = 60;
            label9.Text = "Mô tả";
            // 
            // cancel
            // 
            cancel.BackColor = Color.DarkGray;
            cancel.Location = new Point(821, 105);
            cancel.Name = "cancel";
            cancel.Size = new Size(121, 36);
            cancel.TabIndex = 65;
            cancel.Text = "Hủy";
            cancel.UseVisualStyleBackColor = false;
            cancel.Visible = false;
            cancel.Click += cancel_Click;
            // 
            // ins
            // 
            ins.BackColor = Color.DarkTurquoise;
            ins.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ins.ForeColor = SystemColors.ButtonHighlight;
            ins.Location = new Point(679, 43);
            ins.Name = "ins";
            ins.Size = new Size(121, 36);
            ins.TabIndex = 64;
            ins.Text = "Thêm";
            ins.UseVisualStyleBackColor = false;
            ins.Click += ins_Click;
            // 
            // accept
            // 
            accept.BackColor = Color.Lime;
            accept.ForeColor = SystemColors.ActiveCaptionText;
            accept.Location = new Point(821, 44);
            accept.Name = "accept";
            accept.Size = new Size(121, 36);
            accept.TabIndex = 62;
            accept.Text = "Đồng ý";
            accept.UseVisualStyleBackColor = false;
            accept.Visible = false;
            accept.Click += accept_Click;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 60;
            // 
            // empevent
            // 
            empevent.HeaderText = "Eventname";
            empevent.MinimumWidth = 6;
            empevent.Name = "empevent";
            empevent.ReadOnly = true;
            empevent.Width = 150;
            // 
            // emptime
            // 
            emptime.HeaderText = "Time";
            emptime.MinimumWidth = 6;
            emptime.Name = "emptime";
            emptime.ReadOnly = true;
            emptime.Width = 125;
            // 
            // empdes
            // 
            empdes.HeaderText = "Description";
            empdes.MinimumWidth = 6;
            empdes.Name = "empdes";
            empdes.ReadOnly = true;
            empdes.Width = 270;
            // 
            // locationname
            // 
            locationname.HeaderText = "LocationName";
            locationname.MinimumWidth = 6;
            locationname.Name = "locationname";
            locationname.ReadOnly = true;
            locationname.Width = 150;
            // 
            // status
            // 
            status.HeaderText = "Status";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.ReadOnly = true;
            status.Width = 120;
            // 
            // ScheduleEmpPerson
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(954, 560);
            Controls.Add(cancel);
            Controls.Add(ins);
            Controls.Add(accept);
            Controls.Add(des);
            Controls.Add(label9);
            Controls.Add(diadiem);
            Controls.Add(label1);
            Controls.Add(starttime);
            Controls.Add(da);
            Controls.Add(eventname);
            Controls.Add(ca);
            Controls.Add(dataGridView1);
            Name = "ScheduleEmpPerson";
            Text = "ScheduleEmpPerson";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox eventname;
        private ComboBox nation;
        private Label ca;
        private ComboBox comboBox1;
        private Label da;
        private DateTimePicker starttime;
        private ComboBox diadiem;
        private Label label1;
        private TextBox des;
        private Label label9;
        private Button cancel;
        private Button ins;
        private Button accept;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn empevent;
        private DataGridViewTextBoxColumn emptime;
        private DataGridViewTextBoxColumn empdes;
        private DataGridViewTextBoxColumn locationname;
        private DataGridViewTextBoxColumn status;
    }
}