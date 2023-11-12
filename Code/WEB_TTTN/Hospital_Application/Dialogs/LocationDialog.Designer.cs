namespace Hospital_Application.Dialogs
{
    partial class LocationDialog
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
            locationname = new DataGridViewTextBoxColumn();
            des = new DataGridViewTextBoxColumn();
            img = new DataGridViewTextBoxColumn();
            cancel = new Button();
            ins = new Button();
            update = new Button();
            accept = new Button();
            nametext = new TextBox();
            label3 = new Label();
            destext = new TextBox();
            label5 = new Label();
            image = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, locationname, des, img });
            dataGridView1.Location = new Point(12, 189);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(776, 249);
            dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 125;
            // 
            // locationname
            // 
            locationname.HeaderText = "Location Name";
            locationname.MinimumWidth = 6;
            locationname.Name = "locationname";
            locationname.ReadOnly = true;
            locationname.Width = 180;
            // 
            // des
            // 
            des.HeaderText = "Description";
            des.MinimumWidth = 6;
            des.Name = "des";
            des.ReadOnly = true;
            des.Width = 292;
            // 
            // img
            // 
            img.HeaderText = "Img";
            img.MinimumWidth = 6;
            img.Name = "img";
            img.ReadOnly = true;
            img.Width = 125;
            // 
            // cancel
            // 
            cancel.BackColor = Color.DarkGray;
            cancel.Location = new Point(659, 105);
            cancel.Name = "cancel";
            cancel.Size = new Size(121, 36);
            cancel.TabIndex = 26;
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
            ins.Location = new Point(517, 18);
            ins.Name = "ins";
            ins.Size = new Size(121, 36);
            ins.TabIndex = 25;
            ins.Text = "Thêm";
            ins.UseVisualStyleBackColor = false;
            ins.Click += ins_Click;
            // 
            // update
            // 
            update.BackColor = Color.DarkTurquoise;
            update.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            update.ForeColor = SystemColors.ButtonHighlight;
            update.Location = new Point(517, 73);
            update.Name = "update";
            update.Size = new Size(121, 36);
            update.TabIndex = 24;
            update.Text = "Cập nhật";
            update.UseVisualStyleBackColor = false;
            update.Visible = false;
            update.Click += update_Click;
            // 
            // accept
            // 
            accept.BackColor = Color.Lime;
            accept.ForeColor = SystemColors.ActiveCaptionText;
            accept.Location = new Point(659, 44);
            accept.Name = "accept";
            accept.Size = new Size(121, 36);
            accept.TabIndex = 23;
            accept.Text = "Đồng ý";
            accept.UseVisualStyleBackColor = false;
            accept.Visible = false;
            accept.Click += accept_Click;
            // 
            // nametext
            // 
            nametext.Location = new Point(121, 27);
            nametext.Name = "nametext";
            nametext.ReadOnly = true;
            nametext.Size = new Size(162, 27);
            nametext.TabIndex = 61;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 27);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 60;
            label3.Text = "Tên phòng ban";
            // 
            // destext
            // 
            destext.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            destext.Location = new Point(121, 73);
            destext.Multiline = true;
            destext.Name = "destext";
            destext.ReadOnly = true;
            destext.Size = new Size(162, 100);
            destext.TabIndex = 63;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(18, 71);
            label5.Name = "label5";
            label5.Size = new Size(55, 23);
            label5.TabIndex = 62;
            label5.Text = "Mô tả";
            // 
            // image
            // 
            image.BackColor = Color.DarkTurquoise;
            image.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            image.ForeColor = SystemColors.ButtonHighlight;
            image.Location = new Point(517, 127);
            image.Name = "image";
            image.Size = new Size(121, 36);
            image.TabIndex = 64;
            image.Text = "Ảnh";
            image.UseVisualStyleBackColor = false;
            image.Click += image_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(310, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(191, 146);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 65;
            pictureBox1.TabStop = false;
            // 
            // LocationDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(image);
            Controls.Add(destext);
            Controls.Add(label5);
            Controls.Add(nametext);
            Controls.Add(label3);
            Controls.Add(cancel);
            Controls.Add(ins);
            Controls.Add(update);
            Controls.Add(accept);
            Controls.Add(dataGridView1);
            Name = "LocationDialog";
            Text = "LocationDialog";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn locationname;
        private DataGridViewTextBoxColumn des;
        private DataGridViewTextBoxColumn img;
        private Button cancel;
        private Button ins;
        private Button update;
        private Button accept;
        private TextBox nametext;
        private Label label3;
        private TextBox destext;
        private Label label5;
        private Button image;
        private PictureBox pictureBox1;
    }
}