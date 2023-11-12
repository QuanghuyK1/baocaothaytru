namespace Hospital_Application.Dialogs
{
    partial class BlogDialog
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
            blogname = new DataGridViewTextBoxColumn();
            blogdate = new DataGridViewTextBoxColumn();
            blogdes = new DataGridViewTextBoxColumn();
            cancel = new Button();
            ins = new Button();
            del = new Button();
            accept = new Button();
            update = new Button();
            destext = new Label();
            datelabel = new Label();
            nametext = new TextBox();
            label1 = new Label();
            blogdescription = new TextBox();
            date = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, blogname, blogdate, blogdes });
            dataGridView1.Location = new Point(12, 274);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(930, 274);
            dataGridView1.TabIndex = 0;
            // 
            // Id
            // 
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 80;
            // 
            // blogname
            // 
            blogname.HeaderText = "Name";
            blogname.MinimumWidth = 6;
            blogname.Name = "blogname";
            blogname.ReadOnly = true;
            blogname.Width = 262;
            // 
            // blogdate
            // 
            blogdate.HeaderText = "Create Date";
            blogdate.MinimumWidth = 6;
            blogdate.Name = "blogdate";
            blogdate.ReadOnly = true;
            blogdate.Width = 125;
            // 
            // blogdes
            // 
            blogdes.HeaderText = "Description";
            blogdes.MinimumWidth = 6;
            blogdes.Name = "blogdes";
            blogdes.ReadOnly = true;
            blogdes.Width = 410;
            // 
            // cancel
            // 
            cancel.BackColor = Color.DarkGray;
            cancel.Location = new Point(818, 203);
            cancel.Name = "cancel";
            cancel.Size = new Size(121, 36);
            cancel.TabIndex = 21;
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
            ins.Location = new Point(676, 83);
            ins.Name = "ins";
            ins.Size = new Size(121, 36);
            ins.TabIndex = 20;
            ins.Text = "Thêm";
            ins.UseVisualStyleBackColor = false;
            ins.Click += ins_Click;
            // 
            // del
            // 
            del.BackColor = Color.DarkTurquoise;
            del.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            del.ForeColor = SystemColors.ButtonHighlight;
            del.Location = new Point(676, 203);
            del.Name = "del";
            del.Size = new Size(121, 36);
            del.TabIndex = 19;
            del.Text = "Xóa";
            del.UseVisualStyleBackColor = false;
            del.Visible = false;
            del.Click += del_Click;
            // 
            // accept
            // 
            accept.BackColor = Color.Lime;
            accept.ForeColor = SystemColors.ActiveCaptionText;
            accept.Location = new Point(818, 142);
            accept.Name = "accept";
            accept.Size = new Size(121, 36);
            accept.TabIndex = 18;
            accept.Text = "Đồng ý";
            accept.UseVisualStyleBackColor = false;
            accept.Visible = false;
            accept.Click += accept_Click;
            // 
            // update
            // 
            update.BackColor = Color.DarkTurquoise;
            update.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            update.ForeColor = SystemColors.ButtonHighlight;
            update.Location = new Point(676, 142);
            update.Name = "update";
            update.Size = new Size(121, 36);
            update.TabIndex = 17;
            update.Text = "Sửa";
            update.UseVisualStyleBackColor = false;
            update.Visible = false;
            update.Click += update_Click;
            // 
            // destext
            // 
            destext.AutoSize = true;
            destext.Location = new Point(32, 92);
            destext.Name = "destext";
            destext.Size = new Size(71, 20);
            destext.TabIndex = 30;
            destext.Text = "Nội dung";
            destext.Click += destext_Click;
            // 
            // datelabel
            // 
            datelabel.AutoSize = true;
            datelabel.Location = new Point(358, 38);
            datelabel.Name = "datelabel";
            datelabel.Size = new Size(69, 20);
            datelabel.TabIndex = 24;
            datelabel.Text = "Ngày lập";
            datelabel.Click += date_Click;
            // 
            // nametext
            // 
            nametext.Location = new Point(135, 38);
            nametext.Name = "nametext";
            nametext.ReadOnly = true;
            nametext.Size = new Size(162, 27);
            nametext.TabIndex = 23;
            nametext.TextChanged += nametext_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 38);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 22;
            label1.Text = "Tên bài viết";
            // 
            // blogdescription
            // 
            blogdescription.Location = new Point(135, 92);
            blogdescription.Multiline = true;
            blogdescription.Name = "blogdescription";
            blogdescription.ReadOnly = true;
            blogdescription.Size = new Size(498, 147);
            blogdescription.TabIndex = 31;
            // 
            // date
            // 
            date.CustomFormat = "dd/MM/yyyy";
            date.Format = DateTimePickerFormat.Custom;
            date.Location = new Point(433, 40);
            date.Name = "date";
            date.Size = new Size(200, 27);
            date.TabIndex = 42;
            // 
            // BlogDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(954, 560);
            Controls.Add(date);
            Controls.Add(blogdescription);
            Controls.Add(destext);
            Controls.Add(datelabel);
            Controls.Add(nametext);
            Controls.Add(label1);
            Controls.Add(cancel);
            Controls.Add(ins);
            Controls.Add(del);
            Controls.Add(accept);
            Controls.Add(update);
            Controls.Add(dataGridView1);
            Name = "BlogDialog";
            Text = "BlogDialog";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button cancel;
        private Button ins;
        private Button del;
        private Button accept;
        private Button update;
        private TextBox address;
        private Label destext;
        private TextBox BHYT;
        private Label label6;
        private TextBox email;
        private Label TT;
        private TextBox phone;
        private Label datelabel;
        private TextBox nametext;
        private Label label1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn blogname;
        private DataGridViewTextBoxColumn blogdate;
        private DataGridViewTextBoxColumn blogdes;
        private TextBox blogdescription;
        private DateTimePicker date;
    }
}