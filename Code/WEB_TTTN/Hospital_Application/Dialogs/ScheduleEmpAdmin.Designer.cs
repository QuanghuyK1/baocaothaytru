namespace Hospital_Application.Dialogs
{
    partial class ScheduleEmpAdmin
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
            empevent = new DataGridViewTextBoxColumn();
            emptime = new DataGridViewTextBoxColumn();
            username = new DataGridViewTextBoxColumn();
            empname = new DataGridViewTextBoxColumn();
            empdes = new DataGridViewTextBoxColumn();
            locationname = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { empevent, emptime, username, empname, empdes, locationname, status });
            dataGridView1.Location = new Point(17, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1075, 436);
            dataGridView1.TabIndex = 2;
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
            empname.HeaderText = "Employee Name";
            empname.MinimumWidth = 6;
            empname.Name = "empname";
            empname.ReadOnly = true;
            empname.Width = 155;
            // 
            // empdes
            // 
            empdes.HeaderText = "Description";
            empdes.MinimumWidth = 6;
            empdes.Name = "empdes";
            empdes.ReadOnly = true;
            empdes.Width = 200;
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
            // ScheduleEmpAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(1108, 464);
            Controls.Add(dataGridView1);
            Name = "ScheduleEmpAdmin";
            Text = "ScheduleEmpAdmin";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn empevent;
        private DataGridViewTextBoxColumn emptime;
        private DataGridViewTextBoxColumn username;
        private DataGridViewTextBoxColumn empname;
        private DataGridViewTextBoxColumn empdes;
        private DataGridViewTextBoxColumn locationname;
        private DataGridViewTextBoxColumn status;
    }
}