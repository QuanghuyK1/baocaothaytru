namespace Hospital_Application.Dialogs
{
    partial class ScheduleEmp
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
            patevent = new DataGridViewTextBoxColumn();
            patime = new DataGridViewTextBoxColumn();
            patname = new DataGridViewTextBoxColumn();
            patdes = new DataGridViewTextBoxColumn();
            patphone = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            empschedule = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, patevent, patime, patname, patdes, patphone, status });
            dataGridView1.Location = new Point(12, 185);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(930, 363);
            dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 60;
            // 
            // patevent
            // 
            patevent.HeaderText = "Eventname";
            patevent.MinimumWidth = 6;
            patevent.Name = "patevent";
            patevent.ReadOnly = true;
            patevent.Width = 150;
            // 
            // patime
            // 
            patime.HeaderText = "Time";
            patime.MinimumWidth = 6;
            patime.Name = "patime";
            patime.ReadOnly = true;
            patime.Width = 125;
            // 
            // patname
            // 
            patname.HeaderText = "PatientName";
            patname.MinimumWidth = 6;
            patname.Name = "patname";
            patname.ReadOnly = true;
            patname.Width = 125;
            // 
            // patdes
            // 
            patdes.HeaderText = "Description";
            patdes.MinimumWidth = 6;
            patdes.Name = "patdes";
            patdes.ReadOnly = true;
            patdes.Width = 200;
            // 
            // patphone
            // 
            patphone.HeaderText = "Phonenumber";
            patphone.MinimumWidth = 6;
            patphone.Name = "patphone";
            patphone.ReadOnly = true;
            patphone.Width = 145;
            // 
            // status
            // 
            status.HeaderText = "Status";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.ReadOnly = true;
            status.Width = 72;
            // 
            // empschedule
            // 
            empschedule.BackColor = Color.DarkTurquoise;
            empschedule.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            empschedule.ForeColor = SystemColors.ButtonHighlight;
            empschedule.Location = new Point(46, 49);
            empschedule.Name = "empschedule";
            empschedule.Size = new Size(143, 61);
            empschedule.TabIndex = 1;
            empschedule.Text = "Lịch làm việc";
            empschedule.UseVisualStyleBackColor = false;
            empschedule.Click += empschedule_Click;
            // 
            // ScheduleEmp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(954, 560);
            Controls.Add(empschedule);
            Controls.Add(dataGridView1);
            Name = "ScheduleEmp";
            Text = "ScheduleEmp";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button empschedule;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn patevent;
        private DataGridViewTextBoxColumn patime;
        private DataGridViewTextBoxColumn patname;
        private DataGridViewTextBoxColumn patdes;
        private DataGridViewTextBoxColumn patphone;
        private DataGridViewTextBoxColumn status;
    }
}