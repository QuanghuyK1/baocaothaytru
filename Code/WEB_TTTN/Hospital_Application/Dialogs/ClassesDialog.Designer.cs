namespace Hospital_Application.Dialogs
{
    partial class ClassesDialog
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
            image = new Button();
            nametext = new TextBox();
            label3 = new Label();
            cancel = new Button();
            ins = new Button();
            update = new Button();
            accept = new Button();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            classname = new DataGridViewTextBoxColumn();
            img = new DataGridViewTextBoxColumn();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // image
            // 
            image.BackColor = Color.DarkTurquoise;
            image.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            image.ForeColor = SystemColors.ButtonHighlight;
            image.Location = new Point(24, 116);
            image.Name = "image";
            image.Size = new Size(121, 36);
            image.TabIndex = 74;
            image.Text = "Ảnh";
            image.UseVisualStyleBackColor = false;
            image.Visible = false;
            image.Click += image_Click;
            // 
            // nametext
            // 
            nametext.Location = new Point(18, 69);
            nametext.Name = "nametext";
            nametext.ReadOnly = true;
            nametext.Size = new Size(201, 27);
            nametext.TabIndex = 71;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 33);
            label3.Name = "label3";
            label3.Size = new Size(127, 20);
            label3.TabIndex = 70;
            label3.Text = "Tên chuyên ngành";
            // 
            // cancel
            // 
            cancel.BackColor = Color.DarkGray;
            cancel.Location = new Point(659, 101);
            cancel.Name = "cancel";
            cancel.Size = new Size(121, 36);
            cancel.TabIndex = 69;
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
            ins.Location = new Point(517, 39);
            ins.Name = "ins";
            ins.Size = new Size(121, 36);
            ins.TabIndex = 68;
            ins.Text = "Thêm";
            ins.UseVisualStyleBackColor = false;
            ins.Click += ins_Click;
            // 
            // update
            // 
            update.BackColor = Color.DarkTurquoise;
            update.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            update.ForeColor = SystemColors.ButtonHighlight;
            update.Location = new Point(517, 101);
            update.Name = "update";
            update.Size = new Size(121, 36);
            update.TabIndex = 67;
            update.Text = "Cập nhật";
            update.UseVisualStyleBackColor = false;
            update.Visible = false;
            update.Click += update_Click;
            // 
            // accept
            // 
            accept.BackColor = Color.Lime;
            accept.ForeColor = SystemColors.ActiveCaptionText;
            accept.Location = new Point(659, 40);
            accept.Name = "accept";
            accept.Size = new Size(121, 36);
            accept.TabIndex = 66;
            accept.Text = "Đồng ý";
            accept.UseVisualStyleBackColor = false;
            accept.Visible = false;
            accept.Click += accept_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, classname, img });
            dataGridView1.Location = new Point(12, 185);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(776, 249);
            dataGridView1.TabIndex = 65;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 125;
            // 
            // classname
            // 
            classname.HeaderText = "Classes Name";
            classname.MinimumWidth = 6;
            classname.Name = "classname";
            classname.ReadOnly = true;
            classname.Width = 400;
            // 
            // img
            // 
            img.HeaderText = "Img";
            img.MinimumWidth = 6;
            img.Name = "img";
            img.ReadOnly = true;
            img.Width = 200;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(264, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(198, 134);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 75;
            pictureBox1.TabStop = false;
            // 
            // ClassesDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(image);
            Controls.Add(nametext);
            Controls.Add(label3);
            Controls.Add(cancel);
            Controls.Add(ins);
            Controls.Add(update);
            Controls.Add(accept);
            Controls.Add(dataGridView1);
            Name = "ClassesDialog";
            Text = "ClassesDialog";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button image;
        private TextBox nametext;
        private Label label3;
        private Button cancel;
        private Button ins;
        private Button update;
        private Button accept;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn classname;
        private DataGridViewTextBoxColumn img;
        private PictureBox pictureBox1;
    }
}