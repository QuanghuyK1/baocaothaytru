namespace Hospital_Application.Dialogs
{
    partial class TypeServiceDialog
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
            nametext = new TextBox();
            label3 = new Label();
            cancel = new Button();
            ins = new Button();
            update = new Button();
            accept = new Button();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            sername = new DataGridViewTextBoxColumn();
            serprice = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            pricetext = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tt = new TextBox();
            del = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // nametext
            // 
            nametext.Location = new Point(18, 61);
            nametext.Name = "nametext";
            nametext.ReadOnly = true;
            nametext.Size = new Size(201, 27);
            nametext.TabIndex = 81;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 25);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 80;
            label3.Text = "Tên dịch vụ";
            // 
            // cancel
            // 
            cancel.BackColor = Color.DarkGray;
            cancel.Location = new Point(659, 93);
            cancel.Name = "cancel";
            cancel.Size = new Size(121, 36);
            cancel.TabIndex = 79;
            cancel.Text = "Hủy";
            cancel.UseVisualStyleBackColor = false;
            cancel.Visible = false;
            // 
            // ins
            // 
            ins.BackColor = Color.DarkTurquoise;
            ins.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            ins.ForeColor = SystemColors.ButtonHighlight;
            ins.Location = new Point(517, 16);
            ins.Name = "ins";
            ins.Size = new Size(121, 36);
            ins.TabIndex = 78;
            ins.Text = "Thêm";
            ins.UseVisualStyleBackColor = false;
            // 
            // update
            // 
            update.BackColor = Color.DarkTurquoise;
            update.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            update.ForeColor = SystemColors.ButtonHighlight;
            update.Location = new Point(517, 61);
            update.Name = "update";
            update.Size = new Size(121, 36);
            update.TabIndex = 77;
            update.Text = "Cập nhật";
            update.UseVisualStyleBackColor = false;
            update.Click += update_Click_1;
            // 
            // accept
            // 
            accept.BackColor = Color.Lime;
            accept.ForeColor = SystemColors.ActiveCaptionText;
            accept.Location = new Point(659, 32);
            accept.Name = "accept";
            accept.Size = new Size(121, 36);
            accept.TabIndex = 76;
            accept.Text = "Đồng ý";
            accept.UseVisualStyleBackColor = false;
            accept.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, sername, serprice, status });
            dataGridView1.Location = new Point(12, 177);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(776, 249);
            dataGridView1.TabIndex = 75;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 125;
            // 
            // sername
            // 
            sername.HeaderText = "Service Name";
            sername.MinimumWidth = 6;
            sername.Name = "sername";
            sername.ReadOnly = true;
            sername.Width = 350;
            // 
            // serprice
            // 
            serprice.HeaderText = "Price";
            serprice.MinimumWidth = 6;
            serprice.Name = "serprice";
            serprice.ReadOnly = true;
            serprice.Width = 125;
            // 
            // status
            // 
            status.HeaderText = "Status";
            status.MinimumWidth = 6;
            status.Name = "status";
            status.ReadOnly = true;
            status.Width = 125;
            // 
            // pricetext
            // 
            pricetext.Location = new Point(266, 61);
            pricetext.Name = "pricetext";
            pricetext.ReadOnly = true;
            pricetext.Size = new Size(201, 27);
            pricetext.TabIndex = 84;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(266, 25);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 83;
            label1.Text = "Giá tiền";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 120);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 85;
            label2.Text = "Trạng thái";
            // 
            // tt
            // 
            tt.Location = new Point(111, 117);
            tt.Name = "tt";
            tt.ReadOnly = true;
            tt.Size = new Size(201, 27);
            tt.TabIndex = 86;
            // 
            // del
            // 
            del.BackColor = Color.DarkTurquoise;
            del.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            del.ForeColor = SystemColors.ButtonHighlight;
            del.Location = new Point(517, 108);
            del.Name = "del";
            del.Size = new Size(121, 36);
            del.TabIndex = 87;
            del.Text = "Xoá";
            del.UseVisualStyleBackColor = false;
            del.Click += del_Click;
            // 
            // TypeServiceDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(800, 450);
            Controls.Add(del);
            Controls.Add(tt);
            Controls.Add(label2);
            Controls.Add(pricetext);
            Controls.Add(label1);
            Controls.Add(nametext);
            Controls.Add(label3);
            Controls.Add(cancel);
            Controls.Add(ins);
            Controls.Add(update);
            Controls.Add(accept);
            Controls.Add(dataGridView1);
            Name = "TypeServiceDialog";
            Text = "TypeServiceDialog";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nametext;
        private Label label3;
        private Button cancel;
        private Button ins;
        private Button update;
        private Button accept;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn sername;
        private DataGridViewTextBoxColumn serprice;
        private DataGridViewTextBoxColumn status;
        private TextBox pricetext;
        private Label label1;
        private Label label2;
        private TextBox tt;
        private Button del;
    }
}